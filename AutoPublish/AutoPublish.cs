using System.Diagnostics;

namespace AutoPublish;

public partial class AutoPublish : Form
{
    public AutoPublish()
    {
        InitializeComponent();
        LoadFormData();
    }

    /// <summary>
    /// Append Log On Log Text Box
    /// </summary>
    /// <param name="logMessage"></param>
    private void AppendLog(string logMessage)
    {
        textBox1.AppendText(logMessage + "\r\n");
    }

    /// <summary>
    /// Clear Log In Text Box
    /// </summary>
    private void ClearLog()
    {
        textBox1.Text = string.Empty;
    }

    private void Submit_Click(object sender, EventArgs e)
    {
        // Disable All Controls In Form
        DisableAllControls();

        // Save And Cache The Input Data
        SaveFormData();

        // Clearing The Logs
        ClearLog();

        // Pull New Changes From git
        AppendLog("Pulling The Changes From git ...");
        ExecuteCommandOnDirection("git pull", ProjectDirectionText.Text);

        // Clean Project Using dotnet
        AppendLog("Cleaning Project Using dotnet ...");
        ExecuteCommandOnDirection("dotnet clean", ProjectDirectionText.Text);

        // Build Project Using dotnet
        AppendLog("Building Project Using dotnet ...");
        ExecuteCommandOnDirection("dotnet build", ProjectDirectionText.Text);

        if (buildNoOne.Checked)
        {
            OnBuildModeNoOne();
        }

        // Enable All Controls In Form
        EnableAllControls();
    }

    /// <summary>
    /// Execute Mode Of OnBuildModeNoOne
    /// </summary>
    private void OnBuildModeNoOne()
    {
        // Delete Appsettings Foler From bin
        AppendLog("Deleting Appsettings Folder ...");
        ExecuteCommandOnDirection($"rmdir / s / q {ProjectbinDirectionText.Text}\\Appsettings", ProjectbinDirectionText.Text);

        // Delete web.config Foler From bin
        AppendLog("Deleting web.config Folder ...");
        ExecuteCommandOnDirection($"del /F \"{ProjectbinDirectionText.Text}\\web.config\"\r\n", ProjectbinDirectionText.Text);

        // Stopping IIS Project
        AppendLog("Stopping IIS Project ...");
        ExecuteCommandOnDirection($"%windir%\\system32\\inetsrv\\appcmd stop site \"{ProjectName.Text}\"", ProjectDirectionText.Text);

        Task.Delay(5000);

        // Clear All Folders And Files In wwwroot Folder Because Of Appsettings And web.config
        AppendLog("Clear All Folders And Files In wwwroot Folder Because Of Appsettings And web.config ...");
        ExecuteCommandOnDirection($@"for /f ""delims="" %I in ('dir ""{wwwrootDirection.Text}"" /s /b ^| findstr /v /i /c:""Appsettings"" /c:""web.config""') do (
                                                del /f /s /q ""%~I""
                                                rd /s /q ""%~I""
                                            )
                                            ", wwwrootDirection.Text);

        // Copy All Builded Files From Project Into wwwroot
        AppendLog("Copy All Builded Files From Project Into wwwroot ...");
        ExecuteCommandOnDirection($@"xcopy ""{ProjectbinDirectionText.Text}"" ""{wwwrootDirection.Text}"" /E /I /Y /H", wwwrootDirection.Text);

        Task.Delay(10000);

        // Starting IIS Project
        AppendLog("Starting IIS Project ...");
        ExecuteCommandOnDirection($"%windir%\\system32\\inetsrv\\appcmd start site \"{ProjectName.Text}\"", ProjectDirectionText.Text);

        // Restarting IIS Project
        AppendLog("Restarting IIS Project ...");
        ExecuteCommandOnDirection($"IISRESET", ProjectDirectionText.Text);

    }

    /// <summary>
    /// Execute Any Command On Windows Cmd
    /// </summary>
    /// <param name="command"></param>
    /// <param name="direction"></param>
    private void ExecuteCommandOnDirection(string command, string direction)
    {
        // Set the desired directory path
        var directoryPath = direction;

        // Create a new process to execute the command
        var process = new Process();

        try
        {
            // Set the process start information
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // Specify the command prompt
                RedirectStandardInput = true, // Redirect the standard input
                UseShellExecute = false, // Do not use the shell execute
                CreateNoWindow = true, // Do not create a window for the process
                WorkingDirectory = directoryPath // Set the working directory
            };

            // Start the process
            process.StartInfo = startInfo;
            process.Start();

            // Execute the git pull command
            process.StandardInput.WriteLine(command);
            process.StandardInput.Flush();
            process.StandardInput.Close();

            // Wait for the process to complete
            process.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            // Close the process
            process.Close();
            process.Dispose();
        }
    }

    /// <summary>
    ///     For Disable All Controls In Form
    /// </summary>
    private void DisableAllControls()
    {
        // Disable Submit Button
        Submit.Enabled = false;

        // Find All Controls Because Of Submit Button
        foreach (Control control in Controls)
            // Check And Disable All Control Because Of Submit Button
            if (control != Submit && control != textBox1)
                control.Enabled = false;
    }

    /// <summary>
    ///     For Enable All Controls In Form
    /// </summary>
    private void EnableAllControls()
    {
        // Enable Submit Button
        Submit.Enabled = true;

        // Find All Controls Because Of Submit Button
        foreach (Control control in Controls)
            // Check And Enable All Control Because Of Submit Button
            if (control != Submit)
                control.Enabled = true;
    }

    /// <summary>
    ///     For Save And Cache Controls Data
    /// </summary>
    private void SaveFormData()
    {
        using (var writer = new StreamWriter("form_data.txt"))
        {
            writer.WriteLine(ProjectDirectionText.Text); // Save the value of the ProjectDirectionText TextBox
            writer.WriteLine(ProjectbinDirectionText.Text); // Save the value of the ProjectbinDirectionText TextBox
            writer.WriteLine(wwwrootDirection.Text); // Save the value of the wwwrootDirection TextBox
            writer.WriteLine(ProjectName.Text); // Save the value of the ProjectName TextBox
            writer.WriteLine(buildConfig.Checked); // Save the state of the buildConfig RadioButton
            writer.WriteLine(buildAppsettings.Checked); // Save the state of the buildAppsettings RadioButton
            writer.WriteLine(publishConfig.Checked); // Save the state of the publishConfig RadioButton
            writer.WriteLine(publishAppsettings.Checked); // Save the state of the publishAppsettings RadioButton
            writer.WriteLine(buildBoth.Checked); // Save the state of the buildBoth RadioButton
            writer.WriteLine(publishBoth.Checked); // Save the state of the publishBoth RadioButton
            writer.WriteLine(buildNoOne.Checked); // Save the state of the buildNoOne RadioButton
            writer.WriteLine(publishNoOne.Checked); // Save the state of the publishNoOne RadioButton
        }
    }

    /// <summary>
    ///     For Load The Saved Cache Controls Data
    /// </summary>
    private void LoadFormData()
    {
        if (!File.Exists("form_data.txt")) return;

        using (var reader = new StreamReader("form_data.txt"))
        {
            ProjectDirectionText.Text =
                reader.ReadLine(); // Retrieve the value for the ProjectDirectionText TextBox
            ProjectbinDirectionText.Text =
                reader.ReadLine(); // Retrieve the value for the ProjectbinDirectionText TextBox
            wwwrootDirection.Text = reader.ReadLine(); // Retrieve the value for the wwwrootDirection TextBox
            ProjectName.Text = reader.ReadLine(); // Retrieve the value for the ProjectName TextBox
            buildConfig.Checked =
                bool.Parse(reader.ReadLine()); // Retrieve the state for the buildConfig RadioButton
            buildAppsettings.Checked =
                bool.Parse(reader.ReadLine()); // Retrieve the state for the buildAppsettings RadioButton
            publishConfig.Checked =
                bool.Parse(reader.ReadLine()); // Retrieve the state for the publishConfig RadioButton
            publishAppsettings.Checked =
                bool.Parse(reader.ReadLine()); // Retrieve the state for the publishAppsettings RadioButton
            buildBoth.Checked = bool.Parse(reader.ReadLine()); // Retrieve the state for the buildBoth RadioButton
            publishBoth.Checked =
                bool.Parse(reader.ReadLine()); // Retrieve the state for the publishBoth RadioButton
            buildNoOne.Checked =
                bool.Parse(reader.ReadLine()); // Retrieve the state for the buildNoOne RadioButton
            publishNoOne.Checked =
                bool.Parse(reader.ReadLine()); // Retrieve the state for the publishNoOne RadioButton
        }
    }
}