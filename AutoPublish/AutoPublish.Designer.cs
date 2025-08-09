namespace AutoPublish
{
    partial class AutoPublish
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProjectDirectionLabel = new Label();
            ProjectDirectionText = new TextBox();
            wwwrootDirection = new TextBox();
            wwwrootDirectionLabel = new Label();
            ProjectName = new TextBox();
            ProjectNameLabel = new Label();
            Submit = new Button();
            buildConfig = new RadioButton();
            buildAppsettings = new RadioButton();
            publishConfig = new RadioButton();
            publishAppsettings = new RadioButton();
            buildBoth = new RadioButton();
            publishBoth = new RadioButton();
            textBox1 = new TextBox();
            label4 = new Label();
            buildNoOne = new RadioButton();
            publishNoOne = new RadioButton();
            ProjectbinDirectionText = new TextBox();
            ProjectbinDirectionLabel = new Label();
            SuspendLayout();
            // 
            // ProjectDirectionLabel
            // 
            ProjectDirectionLabel.AutoSize = true;
            ProjectDirectionLabel.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Bold);
            ProjectDirectionLabel.Location = new Point(12, 9);
            ProjectDirectionLabel.Name = "ProjectDirectionLabel";
            ProjectDirectionLabel.Size = new Size(139, 20);
            ProjectDirectionLabel.TabIndex = 0;
            ProjectDirectionLabel.Text = "Project Direction : ";
            // 
            // ProjectDirectionText
            // 
            ProjectDirectionText.Location = new Point(157, 6);
            ProjectDirectionText.Name = "ProjectDirectionText";
            ProjectDirectionText.Size = new Size(631, 27);
            ProjectDirectionText.TabIndex = 1;
            // 
            // wwwrootDirection
            // 
            wwwrootDirection.Location = new Point(170, 72);
            wwwrootDirection.Name = "wwwrootDirection";
            wwwrootDirection.Size = new Size(618, 27);
            wwwrootDirection.TabIndex = 3;
            // 
            // wwwrootDirectionLabel
            // 
            wwwrootDirectionLabel.AutoSize = true;
            wwwrootDirectionLabel.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Bold);
            wwwrootDirectionLabel.Location = new Point(12, 75);
            wwwrootDirectionLabel.Name = "wwwrootDirectionLabel";
            wwwrootDirectionLabel.Size = new Size(152, 20);
            wwwrootDirectionLabel.TabIndex = 2;
            wwwrootDirectionLabel.Text = "wwwroot Direction : ";
            // 
            // ProjectName
            // 
            ProjectName.Location = new Point(132, 105);
            ProjectName.Name = "ProjectName";
            ProjectName.Size = new Size(656, 27);
            ProjectName.TabIndex = 5;
            // 
            // ProjectNameLabel
            // 
            ProjectNameLabel.AutoSize = true;
            ProjectNameLabel.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Bold);
            ProjectNameLabel.Location = new Point(12, 108);
            ProjectNameLabel.Name = "ProjectNameLabel";
            ProjectNameLabel.Size = new Size(114, 20);
            ProjectNameLabel.TabIndex = 4;
            ProjectNameLabel.Text = "Project Name : ";
            // 
            // Submit
            // 
            Submit.BackColor = SystemColors.AppWorkspace;
            Submit.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Bold);
            Submit.Location = new Point(649, 433);
            Submit.Name = "Submit";
            Submit.Size = new Size(139, 39);
            Submit.TabIndex = 6;
            Submit.Text = "Submit";
            Submit.UseVisualStyleBackColor = false;
            Submit.Click += Submit_Click;
            // 
            // buildConfig
            // 
            buildConfig.AutoSize = true;
            buildConfig.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold);
            buildConfig.Location = new Point(12, 153);
            buildConfig.Name = "buildConfig";
            buildConfig.Size = new Size(243, 24);
            buildConfig.TabIndex = 7;
            buildConfig.TabStop = true;
            buildConfig.Text = "On Build  Mode ( With Config )";
            buildConfig.UseVisualStyleBackColor = true;
            // 
            // buildAppsettings
            // 
            buildAppsettings.AutoSize = true;
            buildAppsettings.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold);
            buildAppsettings.Location = new Point(12, 183);
            buildAppsettings.Name = "buildAppsettings";
            buildAppsettings.Size = new Size(281, 24);
            buildAppsettings.TabIndex = 8;
            buildAppsettings.TabStop = true;
            buildAppsettings.Text = "On Build  Mode ( With Appsettings )";
            buildAppsettings.UseVisualStyleBackColor = true;
            // 
            // publishConfig
            // 
            publishConfig.AutoSize = true;
            publishConfig.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold);
            publishConfig.Location = new Point(12, 285);
            publishConfig.Name = "publishConfig";
            publishConfig.Size = new Size(259, 24);
            publishConfig.TabIndex = 9;
            publishConfig.TabStop = true;
            publishConfig.Text = "On Publish  Mode ( With Config )";
            publishConfig.UseVisualStyleBackColor = true;
            // 
            // publishAppsettings
            // 
            publishAppsettings.AutoSize = true;
            publishAppsettings.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold);
            publishAppsettings.Location = new Point(12, 315);
            publishAppsettings.Name = "publishAppsettings";
            publishAppsettings.Size = new Size(297, 24);
            publishAppsettings.TabIndex = 10;
            publishAppsettings.TabStop = true;
            publishAppsettings.Text = "On Publish  Mode ( With Appsettings )";
            publishAppsettings.UseVisualStyleBackColor = true;
            // 
            // buildBoth
            // 
            buildBoth.AutoSize = true;
            buildBoth.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold);
            buildBoth.Location = new Point(12, 213);
            buildBoth.Name = "buildBoth";
            buildBoth.Size = new Size(192, 24);
            buildBoth.TabIndex = 11;
            buildBoth.TabStop = true;
            buildBoth.Text = "On Build  Mode ( Both )";
            buildBoth.UseVisualStyleBackColor = true;
            // 
            // publishBoth
            // 
            publishBoth.AutoSize = true;
            publishBoth.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold);
            publishBoth.Location = new Point(12, 345);
            publishBoth.Name = "publishBoth";
            publishBoth.Size = new Size(208, 24);
            publishBoth.TabIndex = 12;
            publishBoth.TabStop = true;
            publishBoth.Text = "On Publish  Mode ( Both )";
            publishBoth.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(358, 153);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(430, 274);
            textBox1.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.2F);
            label4.Location = new Point(12, 458);
            label4.Name = "label4";
            label4.Size = new Size(137, 15);
            label4.TabIndex = 14;
            label4.Text = "Developed By Amircliper";
            // 
            // buildNoOne
            // 
            buildNoOne.AutoSize = true;
            buildNoOne.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold);
            buildNoOne.Location = new Point(12, 243);
            buildNoOne.Name = "buildNoOne";
            buildNoOne.Size = new Size(212, 24);
            buildNoOne.TabIndex = 15;
            buildNoOne.TabStop = true;
            buildNoOne.Text = "On Build  Mode ( No One )";
            buildNoOne.UseVisualStyleBackColor = true;
            // 
            // publishNoOne
            // 
            publishNoOne.AutoSize = true;
            publishNoOne.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold);
            publishNoOne.Location = new Point(12, 375);
            publishNoOne.Name = "publishNoOne";
            publishNoOne.Size = new Size(228, 24);
            publishNoOne.TabIndex = 16;
            publishNoOne.TabStop = true;
            publishNoOne.Text = "On Publish  Mode ( No One )";
            publishNoOne.UseVisualStyleBackColor = true;
            // 
            // ProjectbinDirectionText
            // 
            ProjectbinDirectionText.Location = new Point(183, 39);
            ProjectbinDirectionText.Name = "ProjectbinDirectionText";
            ProjectbinDirectionText.Size = new Size(605, 27);
            ProjectbinDirectionText.TabIndex = 18;
            // 
            // ProjectbinDirectionLabel
            // 
            ProjectbinDirectionLabel.AutoSize = true;
            ProjectbinDirectionLabel.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Bold);
            ProjectbinDirectionLabel.Location = new Point(12, 42);
            ProjectbinDirectionLabel.Name = "ProjectbinDirectionLabel";
            ProjectbinDirectionLabel.Size = new Size(165, 20);
            ProjectbinDirectionLabel.TabIndex = 17;
            ProjectbinDirectionLabel.Text = "Project bin Direction : ";
            // 
            // AutoPublish
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 485);
            Controls.Add(ProjectbinDirectionText);
            Controls.Add(ProjectbinDirectionLabel);
            Controls.Add(publishNoOne);
            Controls.Add(buildNoOne);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(publishBoth);
            Controls.Add(buildBoth);
            Controls.Add(publishAppsettings);
            Controls.Add(publishConfig);
            Controls.Add(buildAppsettings);
            Controls.Add(buildConfig);
            Controls.Add(Submit);
            Controls.Add(ProjectName);
            Controls.Add(ProjectNameLabel);
            Controls.Add(wwwrootDirection);
            Controls.Add(wwwrootDirectionLabel);
            Controls.Add(ProjectDirectionText);
            Controls.Add(ProjectDirectionLabel);
            Name = "AutoPublish";
            Text = "AutoPublish";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label ProjectDirectionLabel;
        private TextBox ProjectDirectionText;
        private TextBox wwwrootDirection;
        private Label wwwrootDirectionLabel;
        private TextBox ProjectName;
        private Label ProjectNameLabel;
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
        private TextBox ProjectbinDirectionText;
        private Label ProjectbinDirectionLabel;
    }
}