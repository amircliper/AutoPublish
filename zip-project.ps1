param(
    [string]$RootPath = $PSScriptRoot
)

Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem

# اسم zip را از روی sln می‌سازیم؛ اگر sln نبود از اسم فولدر
$slnFile = Get-ChildItem -Path $RootPath -Filter *.sln -File | Select-Object -First 1
if ($slnFile) {
    $zipBaseName = [System.IO.Path]::GetFileNameWithoutExtension($slnFile.Name)
}
else {
    $zipBaseName = Split-Path $RootPath -Leaf
}

$zipPath = Join-Path $RootPath ($zipBaseName + ".zip")

# مواردی که باید حذف شوند
$excludedFolders = @(
    "bin",
    "obj",
    ".git",
    ".vs"
)

$excludedFilePatterns = @(
    "*.zip",
    "*.user",
    "*.suo",
    "*.tmp",
    "*.cache",
    ".gitignore",
    ".gitattributes"
)

# اگر zip قبلی وجود داشت حذفش کن
if (Test-Path $zipPath) {
    Remove-Item $zipPath -Force
}

# ساخت فایل zip
$zipFile = [System.IO.Compression.ZipFile]::Open($zipPath, [System.IO.Compression.ZipArchiveMode]::Create)

try {
    $files = Get-ChildItem -Path $RootPath -Recurse -File

    foreach ($file in $files) {
        $fullPath = $file.FullName
        $relativePath = $fullPath.Substring($RootPath.Length).TrimStart('\','/')

        # خود فایل ps1 و zip خروجی را اگر خواستی می‌توانی حذف کنی
        if ($fullPath -eq $zipPath) { continue }

        # بررسی فولدرهای excluded
        $pathParts = $relativePath -split '[\\/]'
        $skipBecauseFolder = $false
        foreach ($part in $pathParts) {
            if ($excludedFolders -contains $part) {
                $skipBecauseFolder = $true
                break
            }
        }
        if ($skipBecauseFolder) { continue }

        # بررسی الگوی فایل‌های excluded
        $skipBecauseFile = $false
        foreach ($pattern in $excludedFilePatterns) {
            if ($file.Name -like $pattern) {
                $skipBecauseFile = $true
                break
            }
        }
        if ($skipBecauseFile) { continue }

        # افزودن فایل به zip
        [System.IO.Compression.ZipFileExtensions]::CreateEntryFromFile(
            $zipFile,
            $fullPath,
            $relativePath,
            [System.IO.Compression.CompressionLevel]::Optimal
        ) | Out-Null
    }
}
finally {
    $zipFile.Dispose()
}

Write-Host "ZIP created successfully:"
Write-Host $zipPath