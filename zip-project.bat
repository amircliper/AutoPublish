@echo off
cd /d "%~dp0"

powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0zip-project.ps1"

if errorlevel 1 (
    echo.
    echo ================================
    echo ERROR: Zip generation failed.
    echo ================================
    pause
    exit /b 1
)

exit /b 0