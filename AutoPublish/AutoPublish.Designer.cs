namespace AutoPublish
{
    partial class AutoPublish
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ProjectDirectionLabel = new Label();
            ProjectDirectionText = new TextBox();
            ProjectbinDirectionLabel = new Label();
            ProjectbinDirectionText = new TextBox();
            wwwrootDirectionLabel = new Label();
            wwwrootDirection = new TextBox();
            ProjectNameLabel = new Label();
            ProjectName = new TextBox();
            Submit = new Button();
            buildConfig = new RadioButton();
            buildAppsettings = new RadioButton();
            publishConfig = new RadioButton();
            publishAppsettings = new RadioButton();
            buildBoth = new RadioButton();
            publishBoth = new RadioButton();
            buildNoOne = new RadioButton();
            publishNoOne = new RadioButton();
            publishWithDelay = new RadioButton();
            CallUnderMaintenanceApiCheckBox = new CheckBox();
            UnderMaintenanceBaseUrlLabel = new Label();
            UnderMaintenanceBaseUrlText = new TextBox();
            DelayMinutesLabel = new Label();
            DelayMinutesNumeric = new NumericUpDown();
            ApiListenerUrlLabel = new Label();
            ApiListenerUrlText = new TextBox();
            ApplyApiListenerUrlButton = new Button();
            textBox1 = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)DelayMinutesNumeric).BeginInit();
            SuspendLayout();
            // 
            // ProjectDirectionLabel
            // 
            ProjectDirectionLabel.AutoSize = true;
            ProjectDirectionLabel.Location = new Point(12, 19);
            ProjectDirectionLabel.Name = "ProjectDirectionLabel";
            ProjectDirectionLabel.Size = new Size(111, 20);
            ProjectDirectionLabel.TabIndex = 0;
            ProjectDirectionLabel.Text = "Project Folder :";
            // 
            // ProjectDirectionText
            // 
            ProjectDirectionText.Location = new Point(180, 16);
            ProjectDirectionText.Name = "ProjectDirectionText";
            ProjectDirectionText.Size = new Size(760, 27);
            ProjectDirectionText.TabIndex = 1;
            // 
            // ProjectbinDirectionLabel
            // 
            ProjectbinDirectionLabel.AutoSize = true;
            ProjectbinDirectionLabel.Location = new Point(12, 54);
            ProjectbinDirectionLabel.Name = "ProjectbinDirectionLabel";
            ProjectbinDirectionLabel.Size = new Size(136, 20);
            ProjectbinDirectionLabel.TabIndex = 2;
            ProjectbinDirectionLabel.Text = "Project Bin Folder :";
            // 
            // ProjectbinDirectionText
            // 
            ProjectbinDirectionText.Location = new Point(180, 51);
            ProjectbinDirectionText.Name = "ProjectbinDirectionText";
            ProjectbinDirectionText.Size = new Size(760, 27);
            ProjectbinDirectionText.TabIndex = 3;
            // 
            // wwwrootDirectionLabel
            // 
            wwwrootDirectionLabel.AutoSize = true;
            wwwrootDirectionLabel.Location = new Point(12, 89);
            wwwrootDirectionLabel.Name = "wwwrootDirectionLabel";
            wwwrootDirectionLabel.Size = new Size(151, 20);
            wwwrootDirectionLabel.TabIndex = 4;
            wwwrootDirectionLabel.Text = "Publish Target Folder :";
            // 
            // wwwrootDirection
            // 
            wwwrootDirection.Location = new Point(180, 86);
            wwwrootDirection.Name = "wwwrootDirection";
            wwwrootDirection.Size = new Size(760, 27);
            wwwrootDirection.TabIndex = 5;
            // 
            // ProjectNameLabel
            // 
            ProjectNameLabel.AutoSize = true;
            ProjectNameLabel.Location = new Point(12, 124);
            ProjectNameLabel.Name = "ProjectNameLabel";
            ProjectNameLabel.Size = new Size(97, 20);
            ProjectNameLabel.TabIndex = 6;
            ProjectNameLabel.Text = "Project Name :";
            // 
            // ProjectName
            // 
            ProjectName.Location = new Point(180, 121);
            ProjectName.Name = "ProjectName";
            ProjectName.Size = new Size(310, 27);
            ProjectName.TabIndex = 7;
            // 
            // CallUnderMaintenanceApiCheckBox
            // 
            CallUnderMaintenanceApiCheckBox.AutoSize = true;
            CallUnderMaintenanceApiCheckBox.Location = new Point(520, 123);
            CallUnderMaintenanceApiCheckBox.Name = "CallUnderMaintenanceApiCheckBox";
            CallUnderMaintenanceApiCheckBox.Size = new Size(261, 24);
            CallUnderMaintenanceApiCheckBox.TabIndex = 8;
            CallUnderMaintenanceApiCheckBox.Text = "Call Under Maintenance API Before Publish";
            CallUnderMaintenanceApiCheckBox.UseVisualStyleBackColor = true;
            // 
            // UnderMaintenanceBaseUrlLabel
            // 
            UnderMaintenanceBaseUrlLabel.AutoSize = true;
            UnderMaintenanceBaseUrlLabel.Location = new Point(12, 159);
            UnderMaintenanceBaseUrlLabel.Name = "UnderMaintenanceBaseUrlLabel";
            UnderMaintenanceBaseUrlLabel.Size = new Size(149, 20);
            UnderMaintenanceBaseUrlLabel.TabIndex = 9;
            UnderMaintenanceBaseUrlLabel.Text = "Maintenance BaseUrl :";
            // 
            // UnderMaintenanceBaseUrlText
            // 
            UnderMaintenanceBaseUrlText.Location = new Point(180, 156);
            UnderMaintenanceBaseUrlText.Name = "UnderMaintenanceBaseUrlText";
            UnderMaintenanceBaseUrlText.Size = new Size(500, 27);
            UnderMaintenanceBaseUrlText.TabIndex = 10;
            // 
            // DelayMinutesLabel
            // 
            DelayMinutesLabel.AutoSize = true;
            DelayMinutesLabel.Location = new Point(700, 159);
            DelayMinutesLabel.Name = "DelayMinutesLabel";
            DelayMinutesLabel.Size = new Size(102, 20);
            DelayMinutesLabel.TabIndex = 11;
            DelayMinutesLabel.Text = "Delay Minutes :";
            // 
            // DelayMinutesNumeric
            // 
            DelayMinutesNumeric.Location = new Point(808, 157);
            DelayMinutesNumeric.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            DelayMinutesNumeric.Name = "DelayMinutesNumeric";
            DelayMinutesNumeric.Size = new Size(132, 27);
            DelayMinutesNumeric.TabIndex = 12;
            DelayMinutesNumeric.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // ApiListenerUrlLabel
            // 
            ApiListenerUrlLabel.AutoSize = true;
            ApiListenerUrlLabel.Location = new Point(12, 194);
            ApiListenerUrlLabel.Name = "ApiListenerUrlLabel";
            ApiListenerUrlLabel.Size = new Size(99, 20);
            ApiListenerUrlLabel.TabIndex = 13;
            ApiListenerUrlLabel.Text = "Local API Url :";
            // 
            // ApiListenerUrlText
            // 
            ApiListenerUrlText.Location = new Point(180, 191);
            ApiListenerUrlText.Name = "ApiListenerUrlText";
            ApiListenerUrlText.Size = new Size(620, 27);
            ApiListenerUrlText.TabIndex = 14;
            // 
            // ApplyApiListenerUrlButton
            // 
            ApplyApiListenerUrlButton.Location = new Point(808, 189);
            ApplyApiListenerUrlButton.Name = "ApplyApiListenerUrlButton";
            ApplyApiListenerUrlButton.Size = new Size(132, 31);
            ApplyApiListenerUrlButton.TabIndex = 15;
            ApplyApiListenerUrlButton.Text = "Set / Start API";
            ApplyApiListenerUrlButton.UseVisualStyleBackColor = true;
            ApplyApiListenerUrlButton.Click += ApplyApiListenerUrlButton_Click;
            // 
            // buildConfig
            // 
            buildConfig.AutoSize = true;
            buildConfig.Location = new Point(20, 245);
            buildConfig.Name = "buildConfig";
            buildConfig.Size = new Size(174, 24);
            buildConfig.TabIndex = 16;
            buildConfig.Text = "Build Mode (Config)";
            buildConfig.UseVisualStyleBackColor = true;
            // 
            // buildAppsettings
            // 
            buildAppsettings.AutoSize = true;
            buildAppsettings.Location = new Point(20, 275);
            buildAppsettings.Name = "buildAppsettings";
            buildAppsettings.Size = new Size(212, 24);
            buildAppsettings.TabIndex = 17;
            buildAppsettings.Text = "Build Mode (Appsettings)";
            buildAppsettings.UseVisualStyleBackColor = true;
            // 
            // buildBoth
            // 
            buildBoth.AutoSize = true;
            buildBoth.Location = new Point(20, 305);
            buildBoth.Name = "buildBoth";
            buildBoth.Size = new Size(164, 24);
            buildBoth.TabIndex = 18;
            buildBoth.Text = "Build Mode (Both)";
            buildBoth.UseVisualStyleBackColor = true;
            // 
            // buildNoOne
            // 
            buildNoOne.AutoSize = true;
            buildNoOne.Location = new Point(20, 335);
            buildNoOne.Name = "buildNoOne";
            buildNoOne.Size = new Size(184, 24);
            buildNoOne.TabIndex = 19;
            buildNoOne.Text = "Build Mode (No One)";
            buildNoOne.UseVisualStyleBackColor = true;
            // 
            // publishConfig
            // 
            publishConfig.AutoSize = true;
            publishConfig.Location = new Point(20, 390);
            publishConfig.Name = "publishConfig";
            publishConfig.Size = new Size(190, 24);
            publishConfig.TabIndex = 20;
            publishConfig.Text = "Publish Mode (Config)";
            publishConfig.UseVisualStyleBackColor = true;
            // 
            // publishAppsettings
            // 
            publishAppsettings.AutoSize = true;
            publishAppsettings.Location = new Point(20, 420);
            publishAppsettings.Name = "publishAppsettings";
            publishAppsettings.Size = new Size(228, 24);
            publishAppsettings.TabIndex = 21;
            publishAppsettings.Text = "Publish Mode (Appsettings)";
            publishAppsettings.UseVisualStyleBackColor = true;
            // 
            // publishBoth
            // 
            publishBoth.AutoSize = true;
            publishBoth.Checked = true;
            publishBoth.Location = new Point(20, 450);
            publishBoth.Name = "publishBoth";
            publishBoth.Size = new Size(180, 24);
            publishBoth.TabIndex = 22;
            publishBoth.TabStop = true;
            publishBoth.Text = "Publish Mode (Both)";
            publishBoth.UseVisualStyleBackColor = true;
            // 
            // publishNoOne
            // 
            publishNoOne.AutoSize = true;
            publishNoOne.Location = new Point(20, 480);
            publishNoOne.Name = "publishNoOne";
            publishNoOne.Size = new Size(200, 24);
            publishNoOne.TabIndex = 23;
            publishNoOne.Text = "Publish Mode (No One)";
            publishNoOne.UseVisualStyleBackColor = true;
            // 
            // publishWithDelay
            // 
            publishWithDelay.AutoSize = true;
            publishWithDelay.Location = new Point(20, 510);
            publishWithDelay.Name = "publishWithDelay";
            publishWithDelay.Size = new Size(206, 24);
            publishWithDelay.TabIndex = 24;
            publishWithDelay.Text = "Publish Mode (With Delay)";
            publishWithDelay.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(280, 245);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(660, 289);
            textBox1.TabIndex = 25;
            // 
            // Submit
            // 
            Submit.Location = new Point(801, 548);
            Submit.Name = "Submit";
            Submit.Size = new Size(139, 39);
            Submit.TabIndex = 26;
            Submit.Text = "Submit";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 557);
            label4.Name = "label4";
            label4.Size = new Size(218, 20);
            label4.TabIndex = 27;
            label4.Text = "Added delay mode + local API host";
            // 
            // AutoPublish
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 602);
            Controls.Add(label4);
            Controls.Add(Submit);
            Controls.Add(textBox1);
            Controls.Add(publishWithDelay);
            Controls.Add(publishNoOne);
            Controls.Add(publishBoth);
            Controls.Add(publishAppsettings);
            Controls.Add(publishConfig);
            Controls.Add(buildNoOne);
            Controls.Add(buildBoth);
            Controls.Add(buildAppsettings);
            Controls.Add(buildConfig);
            Controls.Add(ApplyApiListenerUrlButton);
            Controls.Add(ApiListenerUrlText);
            Controls.Add(ApiListenerUrlLabel);
            Controls.Add(DelayMinutesNumeric);
            Controls.Add(DelayMinutesLabel);
            Controls.Add(UnderMaintenanceBaseUrlText);
            Controls.Add(UnderMaintenanceBaseUrlLabel);
            Controls.Add(CallUnderMaintenanceApiCheckBox);
            Controls.Add(ProjectName);
            Controls.Add(ProjectNameLabel);
            Controls.Add(wwwrootDirection);
            Controls.Add(wwwrootDirectionLabel);
            Controls.Add(ProjectbinDirectionText);
            Controls.Add(ProjectbinDirectionLabel);
            Controls.Add(ProjectDirectionText);
            Controls.Add(ProjectDirectionLabel);
            Name = "AutoPublish";
            Text = "AutoPublisher";
            ((System.ComponentModel.ISupportInitialize)DelayMinutesNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label ProjectDirectionLabel;
        private TextBox ProjectDirectionText;
        private Label ProjectbinDirectionLabel;
        private TextBox ProjectbinDirectionText;
        private Label wwwrootDirectionLabel;
        private TextBox wwwrootDirection;
        private Label ProjectNameLabel;
        private TextBox ProjectName;
        private Button Submit;
        private RadioButton buildConfig;
        private RadioButton buildAppsettings;
        private RadioButton publishConfig;
        private RadioButton publishAppsettings;
        private RadioButton buildBoth;
        private RadioButton publishBoth;
        private TextBox textBox1;
        private Label label4;
        private RadioButton buildNoOne;
        private RadioButton publishNoOne;
        private RadioButton publishWithDelay;
        private CheckBox CallUnderMaintenanceApiCheckBox;
        private Label UnderMaintenanceBaseUrlLabel;
        private TextBox UnderMaintenanceBaseUrlText;
        private Label DelayMinutesLabel;
        private NumericUpDown DelayMinutesNumeric;
        private Label ApiListenerUrlLabel;
        private TextBox ApiListenerUrlText;
        private Button ApplyApiListenerUrlButton;
    }
}
