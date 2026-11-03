using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AutoPublish;

public partial class AutoPublish : Form
{
    private static readonly string FormDataFilePath = Path.Combine(AppContext.BaseDirectory, "form_data.txt");
    private readonly HttpClient _httpClient = new();
    private readonly SemaphoreSlim _publishLock = new(1, 1);
    private HttpListener? _httpListener;
    private CancellationTokenSource? _listenerCts;

    public AutoPublish()
    {
        InitializeComponent();
        LoadFormData();
        this.ApplyModernTheme();

        if (string.IsNullOrWhiteSpace(ApiListenerUrlText.Text))
            ApiListenerUrlText.Text = "http://localhost:5057/";

        if (string.IsNullOrWhiteSpace(UnderMaintenanceBaseUrlText.Text))
            UnderMaintenanceBaseUrlText.Text = "https://localhost:7216/";

        RestartLocalApiListener(ApiListenerUrlText.Text);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        StopLocalApiListener();
        base.OnFormClosing(e);
    }

    private void AppendLog(string logMessage)
    {
        var message = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} - {logMessage}{Environment.NewLine}";
        if (textBox1.InvokeRequired)
        {
            textBox1.BeginInvoke(new Action(() => textBox1.AppendText(message)));
            return;
        }

        textBox1.AppendText(message);
    }

    private void ClearLog()
    {
        textBox1.Text = string.Empty;
    }


    private void ApplyApiListenerUrlButton_Click(object? sender, EventArgs e)
    {
        SaveFormData();
        RestartLocalApiListener(ApiListenerUrlText.Text);
    }

    private async void Submit_Click(object? sender, EventArgs e)
    {
        if (!await _publishLock.WaitAsync(0))
        {
            AppendLog("A publish task is already running.");
            return;
        }

        try
        {
            DisableAllControls();
            SaveFormData();
            ClearLog();

            var request = BuildRequestFromForm();
            var result = await ExecutePublishWorkflowAsync(request, CancellationToken.None);

            if (result.Success)
                AppendLog("The project has been deployed successfully.");
            else
                AppendLog("Publish finished with errors: " + result.Message);
        }
        finally
        {
            EnableAllControls();
            _publishLock.Release();
        }
    }

    private PublishExecutionRequest BuildRequestFromForm()
    {
        return new PublishExecutionRequest
        {
            ProjectName = ProjectName.Text.Trim(),
            ProjectDirectory = ProjectDirectionText.Text.Trim(),
            ProjectBinDirectory = ProjectbinDirectionText.Text.Trim(),
            PublishTargetDirectory = wwwrootDirection.Text.Trim(),
            Mode = ResolveSelectedMode(),
            CallUnderMaintenanceBeforePublish = CallUnderMaintenanceApiCheckBox.Checked,
            PublishDelayMinutes = (int)DelayMinutesNumeric.Value,
            UnderMaintenanceBaseUrl = UnderMaintenanceBaseUrlText.Text.Trim()
        };
    }

    private string ResolveSelectedMode()
    {
        if (publishWithDelay.Checked) return PublishModeNames.PublishWithDelay;
        if (publishBoth.Checked) return PublishModeNames.PublishBoth;
        if (buildNoOne.Checked) return PublishModeNames.BuildNoOne;
        if (buildConfig.Checked || buildAppsettings.Checked || buildBoth.Checked) return PublishModeNames.BuildNoOne;
        if (publishConfig.Checked || publishAppsettings.Checked || publishNoOne.Checked) return PublishModeNames.PublishBoth;
        return PublishModeNames.PublishBoth;
    }

    private async Task<ExecutionResult> ExecutePublishWorkflowAsync(PublishExecutionRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.ProjectDirectory) || string.IsNullOrWhiteSpace(request.PublishTargetDirectory))
            return ExecutionResult.Fail("Project directory and publish target directory are required.");

        AppendLog("Pulling the latest changes from git ...");
        await ExecuteCommandOnDirectionAsync("git pull", request.ProjectDirectory);

        AppendLog("Cleaning project using dotnet ...");
        await ExecuteCommandOnDirectionAsync("dotnet clean", request.ProjectDirectory);

        AppendLog("Building project using dotnet ...");
        await ExecuteCommandOnDirectionAsync("dotnet build", request.ProjectDirectory);

        switch (request.Mode)
        {
            case PublishModeNames.BuildNoOne:
                await MaybeCallUnderMaintenanceApiAsync(request, cancellationToken);
                await OnBuildModeNoOneAsync(request);
                return ExecutionResult.Ok("BuildNoOne executed.");

            case PublishModeNames.PublishWithDelay:
                await OnPublishWithDelayAsync(request, cancellationToken);
                return ExecutionResult.Ok("PublishWithDelay executed.");

            case PublishModeNames.PublishBoth:
            default:
                await MaybeCallUnderMaintenanceApiAsync(request, cancellationToken);
                await OnPublishBothAsync(request);
                return ExecutionResult.Ok("PublishBoth executed.");
        }
    }

    private async Task OnPublishWithDelayAsync(PublishExecutionRequest request, CancellationToken cancellationToken)
    {
        await MaybeCallUnderMaintenanceApiAsync(request, cancellationToken);

        if (request.PublishDelayMinutes > 0)
        {
            AppendLog($"Waiting {request.PublishDelayMinutes} minute(s) before publish ...");
            await Task.Delay(TimeSpan.FromMinutes(request.PublishDelayMinutes), cancellationToken);
        }

        await OnPublishBothAsync(request);
    }

    private async Task MaybeCallUnderMaintenanceApiAsync(PublishExecutionRequest request, CancellationToken cancellationToken)
    {
        if (!request.CallUnderMaintenanceBeforePublish)
            return;

        if (string.IsNullOrWhiteSpace(request.UnderMaintenanceBaseUrl))
        {
            AppendLog("Under maintenance API is enabled but base url is empty.");
            return;
        }

        var baseUrl = request.UnderMaintenanceBaseUrl.TrimEnd('/');
        var expectedValue = $"12345678990-=QWERTYUIOPasdfghjkl;ZXCVBNM<>?{DateTime.Now:MHd}";
        var payload = JsonSerializer.Serialize(new
        {
            userName = expectedValue,
            password = expectedValue
        });

        using var httpRequest = new HttpRequestMessage(HttpMethod.Post, baseUrl + "/api/v1/General/set-under-maintenance");
        httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        httpRequest.Headers.Add("language", "1");
        httpRequest.Content = new StringContent(payload, Encoding.UTF8, "application/json-patch+json");

        AppendLog("Calling under maintenance API ...");
        using var response = await _httpClient.SendAsync(httpRequest, cancellationToken);
        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        AppendLog($"Under maintenance response: {(int)response.StatusCode} {response.StatusCode}");
        if (!string.IsNullOrWhiteSpace(body))
            AppendLog(body);
    }

    private async Task OnBuildModeNoOneAsync(PublishExecutionRequest request)
    {
        AppendLog("Deleting Appsettings folder from bin ...");
        await ExecuteCommandOnDirectionAsync($"rmdir /s /q \"{request.ProjectBinDirectory}\\Appsettings\"", request.ProjectBinDirectory);

        AppendLog("Deleting web.config from bin ...");
        await ExecuteCommandOnDirectionAsync($"del /F \"{request.ProjectBinDirectory}\\web.config\"", request.ProjectBinDirectory);

        AppendLog("Stopping IIS site ...");
        await ExecuteCommandOnDirectionAsync($"%windir%\\system32\\inetsrv\\appcmd stop site \"{request.ProjectName}\"", request.ProjectDirectory);

        await Task.Delay(5000);

        AppendLog("Clearing publish target except special files ...");
        await ExecuteCommandOnDirectionAsync(
            $@"for /f ""delims="" %I in ('dir ""{request.PublishTargetDirectory}"" /s /b ^| findstr /v /i /c:""Appsettings"" /c:""web.config""') do (
                    del /f /s /q ""%~I""
                    rd /s /q ""%~I""
                )", request.PublishTargetDirectory);

        AppendLog("Copying built files to publish target ...");
        await ExecuteCommandOnDirectionAsync($@"xcopy ""{request.ProjectBinDirectory}"" ""{request.PublishTargetDirectory}"" /E /I /Y /H", request.PublishTargetDirectory);

        await Task.Delay(3000);

        AppendLog("Starting IIS site ...");
        await ExecuteCommandOnDirectionAsync($"%windir%\\system32\\inetsrv\\appcmd start site \"{request.ProjectName}\"", request.ProjectDirectory);

        AppendLog("Restarting IIS ...");
        await ExecuteCommandOnDirectionAsync("IISRESET", request.ProjectDirectory);
    }

    private async Task OnPublishBothAsync(PublishExecutionRequest request)
    {
        AppendLog("Stopping IIS ...");
        await ExecuteCommandAsync("net stop W3SVC");

        if (!string.IsNullOrWhiteSpace(request.ProjectBinDirectory))
        {
            AppendLog("Creating publish folder ...");
            Directory.CreateDirectory(request.ProjectBinDirectory);

            AppendLog("Publishing project using dotnet publish ...");
            await ExecuteCommandOnDirectionAsync($"dotnet publish -c Release -o \"{request.ProjectBinDirectory}\"", request.ProjectDirectory);
        }

        AppendLog("Resetting target directory ...");
        ForceDeleteDirectory(request.PublishTargetDirectory);

        AppendLog("Copying published files to target ...");
        await ExecuteCommandOnDirectionAsync($@"xcopy ""{request.ProjectBinDirectory}"" ""{request.PublishTargetDirectory}"" /E /I /Y /H", request.PublishTargetDirectory);

        AppendLog("Starting IIS ...");
        await ExecuteCommandAsync("net start W3SVC");
    }

    private async Task ExecuteCommandOnDirectionAsync(string command, string directory)
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + command,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = string.IsNullOrWhiteSpace(directory) ? Environment.CurrentDirectory : directory
            };

            using var process = new Process { StartInfo = startInfo };
            process.Start();

            var outputTask = process.StandardOutput.ReadToEndAsync();
            var errorTask = process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();

            var output = await outputTask;
            var error = await errorTask;

            if (!string.IsNullOrWhiteSpace(output))
                AppendLog(output.Trim());
            if (!string.IsNullOrWhiteSpace(error))
                AppendLog("ERROR: " + error.Trim());
        }
        catch (Exception ex)
        {
            AppendLog("EXCEPTION: " + ex.Message);
        }
    }

    private async Task ExecuteCommandAsync(string command)
    {
        var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
        {
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        using var process = Process.Start(processInfo)!;
        var output = await process.StandardOutput.ReadToEndAsync();
        var error = await process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        if (!string.IsNullOrWhiteSpace(output))
            AppendLog(output.Trim());
        if (!string.IsNullOrWhiteSpace(error))
            AppendLog("ERROR: " + error.Trim());
    }

    private void ForceDeleteDirectory(string path)
    {
        try
        {
            if (Directory.Exists(path))
            {
                var di = new DirectoryInfo(path)
                {
                    Attributes = FileAttributes.Normal
                };

                foreach (var info in di.GetFileSystemInfos("*", SearchOption.AllDirectories))
                    info.Attributes = FileAttributes.Normal;

                Directory.Delete(path, true);
            }

            Directory.CreateDirectory(path);
            AppendLog("Directory reset successfully.");
        }
        catch (Exception ex)
        {
            AppendLog("ERROR while deleting directory: " + ex.Message);
        }
    }

    private void DisableAllControls()
    {
        Submit.Enabled = false;
        foreach (Control control in Controls)
            if (control != Submit && control != textBox1)
                control.Enabled = false;
    }

    private void EnableAllControls()
    {
        Submit.Enabled = true;
        foreach (Control control in Controls)
            if (control != Submit)
                control.Enabled = true;
    }

    private void SaveFormData()
    {
        using var writer = new StreamWriter(FormDataFilePath, false, Encoding.UTF8);
        writer.WriteLine(ProjectDirectionText.Text);
        writer.WriteLine(ProjectbinDirectionText.Text);
        writer.WriteLine(wwwrootDirection.Text);
        writer.WriteLine(ProjectName.Text);
        writer.WriteLine(buildConfig.Checked);
        writer.WriteLine(buildAppsettings.Checked);
        writer.WriteLine(publishConfig.Checked);
        writer.WriteLine(publishAppsettings.Checked);
        writer.WriteLine(buildBoth.Checked);
        writer.WriteLine(publishBoth.Checked);
        writer.WriteLine(buildNoOne.Checked);
        writer.WriteLine(publishNoOne.Checked);
        writer.WriteLine(publishWithDelay.Checked);
        writer.WriteLine(CallUnderMaintenanceApiCheckBox.Checked);
        writer.WriteLine(UnderMaintenanceBaseUrlText.Text);
        writer.WriteLine(DelayMinutesNumeric.Value);
        writer.WriteLine(ApiListenerUrlText.Text);
    }

    private void LoadFormData()
    {
        if (!File.Exists(FormDataFilePath)) return;

        using var reader = new StreamReader(FormDataFilePath, Encoding.UTF8);
        ProjectDirectionText.Text = reader.ReadLine() ?? string.Empty;
        ProjectbinDirectionText.Text = reader.ReadLine() ?? string.Empty;
        wwwrootDirection.Text = reader.ReadLine() ?? string.Empty;
        ProjectName.Text = reader.ReadLine() ?? string.Empty;
        buildConfig.Checked = bool.TryParse(reader.ReadLine(), out var buildConfigValue) && buildConfigValue;
        buildAppsettings.Checked = bool.TryParse(reader.ReadLine(), out var buildAppsettingsValue) && buildAppsettingsValue;
        publishConfig.Checked = bool.TryParse(reader.ReadLine(), out var publishConfigValue) && publishConfigValue;
        publishAppsettings.Checked = bool.TryParse(reader.ReadLine(), out var publishAppsettingsValue) && publishAppsettingsValue;
        buildBoth.Checked = bool.TryParse(reader.ReadLine(), out var buildBothValue) && buildBothValue;
        publishBoth.Checked = bool.TryParse(reader.ReadLine(), out var publishBothValue) && publishBothValue;
        buildNoOne.Checked = bool.TryParse(reader.ReadLine(), out var buildNoOneValue) && buildNoOneValue;
        publishNoOne.Checked = bool.TryParse(reader.ReadLine(), out var publishNoOneValue) && publishNoOneValue;
        publishWithDelay.Checked = bool.TryParse(reader.ReadLine(), out var publishWithDelayValue) && publishWithDelayValue;
        CallUnderMaintenanceApiCheckBox.Checked = bool.TryParse(reader.ReadLine(), out var callApiValue) && callApiValue;
        UnderMaintenanceBaseUrlText.Text = reader.ReadLine() ?? string.Empty;

        if (decimal.TryParse(reader.ReadLine(), out var delay))
            DelayMinutesNumeric.Value = Math.Max(DelayMinutesNumeric.Minimum, Math.Min(DelayMinutesNumeric.Maximum, delay));

        ApiListenerUrlText.Text = reader.ReadLine() ?? string.Empty;
    }

    private void RestartLocalApiListener(string? listenerUrl)
    {
        var prefix = NormalizeListenerPrefix(listenerUrl);
        StopLocalApiListener();

        try
        {
            _listenerCts = new CancellationTokenSource();
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(prefix);
            _httpListener.Start();
            _ = Task.Run(() => ListenLoopAsync(_listenerCts.Token));
            AppendLog("AutoPublisher API started on " + prefix);
        }
        catch (HttpListenerException ex)
        {
            AppendLog("Could not start API listener: " + ex.Message);
            AppendLog("If this URL uses a server IP, make sure the app is running with enough permissions and the URL is reserved for HttpListener.");
        }
        catch (Exception ex)
        {
            AppendLog("Could not start API listener: " + ex.Message);
        }
    }

    private void StopLocalApiListener()
    {
        try
        {
            _listenerCts?.Cancel();

            if (_httpListener is { IsListening: true })
                _httpListener.Stop();

            _httpListener?.Close();
        }
        catch
        {
            // Ignore shutdown errors.
        }
        finally
        {
            _httpListener = null;
            _listenerCts?.Dispose();
            _listenerCts = null;
        }
    }

    private async Task ListenLoopAsync(CancellationToken cancellationToken)
    {
        while (_httpListener is { IsListening: true } && !cancellationToken.IsCancellationRequested)
        {
            try
            {
                var context = await _httpListener.GetContextAsync();
                _ = Task.Run(() => HandleRequestAsync(context, cancellationToken), cancellationToken);
            }
            catch (Exception ex)
            {
                if (!cancellationToken.IsCancellationRequested)
                    AppendLog("API listener error: " + ex.Message);
            }
        }
    }

    private async Task HandleRequestAsync(HttpListenerContext context, CancellationToken cancellationToken)
    {
        try
        {
            var path = context.Request.Url?.AbsolutePath?.TrimEnd('/').ToLowerInvariant() ?? string.Empty;

            if (context.Request.HttpMethod == "GET" && path == "/api/health")
            {
                await WriteJsonAsync(context, 200, new { success = true, message = "AutoPublisher is running." });
                return;
            }

            if (context.Request.HttpMethod == "POST" && path == "/api/publish")
            {
                using var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding ?? Encoding.UTF8);
                var body = await reader.ReadToEndAsync(cancellationToken);
                var request = JsonSerializer.Deserialize<PublishExecutionRequest>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                request.ProjectBinDirectory = request.ProjectBinDirectory.Replace("/", "\\");
                request.PublishTargetDirectory = request.PublishTargetDirectory.Replace("/", "\\");
                request.ProjectDirectory = request.ProjectDirectory.Replace("/", "\\");
                if (request is null)
                {
                    await WriteJsonAsync(context, 400, new { success = false, message = "Invalid request body." });
                    return;
                }

                if (!await _publishLock.WaitAsync(0, cancellationToken))
                {
                    await WriteJsonAsync(context, 409, new { success = false, message = "Another publish is already running." });
                    return;
                }

                try
                {
                    AppendLog("Publish request received via API for project: " + request.ProjectName);
                    var result = await ExecutePublishWorkflowAsync(request, cancellationToken);
                    await WriteJsonAsync(context, result.Success ? 200 : 500, new { success = result.Success, message = result.Message });
                }
                finally
                {
                    _publishLock.Release();
                }

                return;
            }

            await WriteJsonAsync(context, 404, new { success = false, message = "Route not found." });
        }
        catch (Exception ex)
        {
            await WriteJsonAsync(context, 500, new { success = false, message = ex.Message });
        }
    }

    private static string NormalizeListenerPrefix(string value)
    {
        var prefix = string.IsNullOrWhiteSpace(value) ? "http://localhost:5057/" : value.Trim();
        if (!prefix.EndsWith('/')) prefix += "/";
        return prefix;
    }

    private static async Task WriteJsonAsync(HttpListenerContext context, int statusCode, object payload)
    {
        var json = JsonSerializer.Serialize(payload);
        var buffer = Encoding.UTF8.GetBytes(json);
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = Encoding.UTF8;
        context.Response.ContentLength64 = buffer.Length;
        await context.Response.OutputStream.WriteAsync(buffer);
        context.Response.OutputStream.Close();
    }

    private sealed class ExecutionResult
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;

        public static ExecutionResult Ok(string message) => new() { Success = true, Message = message };
        public static ExecutionResult Fail(string message) => new() { Success = false, Message = message };
    }

    private sealed class PublishExecutionRequest
    {
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDirectory { get; set; } = string.Empty;
        public string ProjectBinDirectory { get; set; } = string.Empty;
        public string PublishTargetDirectory { get; set; } = string.Empty;
        public string Mode { get; set; } = PublishModeNames.PublishBoth;
        public bool CallUnderMaintenanceBeforePublish { get; set; }
        public int PublishDelayMinutes { get; set; }
        public string UnderMaintenanceBaseUrl { get; set; } = string.Empty;
    }

    private static class PublishModeNames
    {
        public const string BuildNoOne = "BuildNoOne";
        public const string PublishBoth = "PublishBoth";
        public const string PublishWithDelay = "PublishWithDelay";
    }
}
