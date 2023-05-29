using System.Diagnostics;

namespace AutoPublish;

public partial class AutoPublish : Form
{
    public AutoPublish()
    {
        InitializeComponent();
        LoadFormData();
    }

    private void AppendLog(string logMessage)
    {
        textBox1.AppendText(logMessage + "\r\n");
    }

    private void Submit_Click(object sender, EventArgs e)
    {
        // Disable All Controls In Form
        DisableAllControls();
        // Save And Cache The Input Data
        SaveFormData();

        // Pull New Changes From git
        AppendLog("Pulling The Changes From git ...");
        ExecuteCommandOnDirection("git pull", ProjectDirectionText.Text);

        // Clean Project Using dotnet
        AppendLog("Cleaning Project Using dotnet ...");
        ExecuteCommandOnDirection("dotnet clean", ProjectDirectionText.Text);

        // Build Project Using dotnet
        AppendLog("Building Project Using dotnet ...");
        ExecuteCommandOnDirection("dotnet build", ProjectDirectionText.Text);

        // Enable All Controls In Form
        EnableAllControls();
    }

    public void ExecuteCommandOnDirection(string command, string direction)
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
            writer.WriteLine(wwwrootDirection.Text); // Save the value of the wwwrootDirection TextBox
            writer.WriteLine(ProjectName.Text); // Save the value of the ProjectName TextBox
            writer.WriteLine(buildConfig.Checked); // Save the state of the buildConfig RadioButton
            writer.WriteLine(buildAppsettings.Checked); // Save the state of the buildAppsettings RadioButton
            writer.WriteLine(publishConfig.Checked); // Save the state of the publishConfig RadioButton
            writer.WriteLine(publishAppsettings.Checked); // Save the state of the publishAppsettings RadioButton
            writer.WriteLine(buildBoth.Checked); // Save the state of the buildBoth RadioButton
            writer.WriteLine(publishBoth.Checked); // Save the state of the publishBoth RadioButton
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
        }
    }
}