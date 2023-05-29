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
            this.ProjectDirectionLabel = new System.Windows.Forms.Label();
            this.ProjectDirectionText = new System.Windows.Forms.TextBox();
            this.wwwrootDirection = new System.Windows.Forms.TextBox();
            this.wwwrootDirectionLabel = new System.Windows.Forms.Label();
            this.ProjectName = new System.Windows.Forms.TextBox();
            this.ProjectNameLabel = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.buildConfig = new System.Windows.Forms.RadioButton();
            this.buildAppsettings = new System.Windows.Forms.RadioButton();
            this.publishConfig = new System.Windows.Forms.RadioButton();
            this.publishAppsettings = new System.Windows.Forms.RadioButton();
            this.buildBoth = new System.Windows.Forms.RadioButton();
            this.publishBoth = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProjectDirectionLabel
            // 
            this.ProjectDirectionLabel.AutoSize = true;
            this.ProjectDirectionLabel.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProjectDirectionLabel.Location = new System.Drawing.Point(12, 9);
            this.ProjectDirectionLabel.Name = "ProjectDirectionLabel";
            this.ProjectDirectionLabel.Size = new System.Drawing.Size(139, 20);
            this.ProjectDirectionLabel.TabIndex = 0;
            this.ProjectDirectionLabel.Text = "Project Direction : ";
            // 
            // ProjectDirectionText
            // 
            this.ProjectDirectionText.Location = new System.Drawing.Point(157, 6);
            this.ProjectDirectionText.Name = "ProjectDirectionText";
            this.ProjectDirectionText.Size = new System.Drawing.Size(631, 27);
            this.ProjectDirectionText.TabIndex = 1;
            // 
            // wwwrootDirection
            // 
            this.wwwrootDirection.Location = new System.Drawing.Point(170, 39);
            this.wwwrootDirection.Name = "wwwrootDirection";
            this.wwwrootDirection.Size = new System.Drawing.Size(618, 27);
            this.wwwrootDirection.TabIndex = 3;
            // 
            // wwwrootDirectionLabel
            // 
            this.wwwrootDirectionLabel.AutoSize = true;
            this.wwwrootDirectionLabel.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wwwrootDirectionLabel.Location = new System.Drawing.Point(12, 42);
            this.wwwrootDirectionLabel.Name = "wwwrootDirectionLabel";
            this.wwwrootDirectionLabel.Size = new System.Drawing.Size(152, 20);
            this.wwwrootDirectionLabel.TabIndex = 2;
            this.wwwrootDirectionLabel.Text = "wwwroot Direction : ";
            // 
            // ProjectName
            // 
            this.ProjectName.Location = new System.Drawing.Point(132, 72);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(656, 27);
            this.ProjectName.TabIndex = 5;
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.AutoSize = true;
            this.ProjectNameLabel.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProjectNameLabel.Location = new System.Drawing.Point(12, 75);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(114, 20);
            this.ProjectNameLabel.TabIndex = 4;
            this.ProjectNameLabel.Text = "Project Name : ";
            // 
            // Submit
            // 
            this.Submit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Submit.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Submit.Location = new System.Drawing.Point(649, 399);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(139, 39);
            this.Submit.TabIndex = 6;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = false;
            // 
            // buildConfig
            // 
            this.buildConfig.AutoSize = true;
            this.buildConfig.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buildConfig.Location = new System.Drawing.Point(12, 119);
            this.buildConfig.Name = "buildConfig";
            this.buildConfig.Size = new System.Drawing.Size(243, 24);
            this.buildConfig.TabIndex = 7;
            this.buildConfig.TabStop = true;
            this.buildConfig.Text = "On Build  Mode ( With Config )";
            this.buildConfig.UseVisualStyleBackColor = true;
            // 
            // buildAppsettings
            // 
            this.buildAppsettings.AutoSize = true;
            this.buildAppsettings.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buildAppsettings.Location = new System.Drawing.Point(12, 149);
            this.buildAppsettings.Name = "buildAppsettings";
            this.buildAppsettings.Size = new System.Drawing.Size(281, 24);
            this.buildAppsettings.TabIndex = 8;
            this.buildAppsettings.TabStop = true;
            this.buildAppsettings.Text = "On Build  Mode ( With Appsettings )";
            this.buildAppsettings.UseVisualStyleBackColor = true;
            // 
            // publishConfig
            // 
            this.publishConfig.AutoSize = true;
            this.publishConfig.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.publishConfig.Location = new System.Drawing.Point(12, 230);
            this.publishConfig.Name = "publishConfig";
            this.publishConfig.Size = new System.Drawing.Size(259, 24);
            this.publishConfig.TabIndex = 9;
            this.publishConfig.TabStop = true;
            this.publishConfig.Text = "On Publish  Mode ( With Config )";
            this.publishConfig.UseVisualStyleBackColor = true;
            // 
            // publishAppsettings
            // 
            this.publishAppsettings.AutoSize = true;
            this.publishAppsettings.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.publishAppsettings.Location = new System.Drawing.Point(12, 260);
            this.publishAppsettings.Name = "publishAppsettings";
            this.publishAppsettings.Size = new System.Drawing.Size(297, 24);
            this.publishAppsettings.TabIndex = 10;
            this.publishAppsettings.TabStop = true;
            this.publishAppsettings.Text = "On Publish  Mode ( With Appsettings )";
            this.publishAppsettings.UseVisualStyleBackColor = true;
            // 
            // buildBoth
            // 
            this.buildBoth.AutoSize = true;
            this.buildBoth.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buildBoth.Location = new System.Drawing.Point(12, 179);
            this.buildBoth.Name = "buildBoth";
            this.buildBoth.Size = new System.Drawing.Size(192, 24);
            this.buildBoth.TabIndex = 11;
            this.buildBoth.TabStop = true;
            this.buildBoth.Text = "On Build  Mode ( Both )";
            this.buildBoth.UseVisualStyleBackColor = true;
            // 
            // publishBoth
            // 
            this.publishBoth.AutoSize = true;
            this.publishBoth.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.publishBoth.Location = new System.Drawing.Point(12, 290);
            this.publishBoth.Name = "publishBoth";
            this.publishBoth.Size = new System.Drawing.Size(208, 24);
            this.publishBoth.TabIndex = 12;
            this.publishBoth.TabStop = true;
            this.publishBoth.Text = "On Publish  Mode ( Both )";
            this.publishBoth.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(358, 119);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(430, 274);
            this.textBox1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Developed By Amircliper";
            // 
            // AutoPublish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.publishBoth);
            this.Controls.Add(this.buildBoth);
            this.Controls.Add(this.publishAppsettings);
            this.Controls.Add(this.publishConfig);
            this.Controls.Add(this.buildAppsettings);
            this.Controls.Add(this.buildConfig);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.ProjectName);
            this.Controls.Add(this.ProjectNameLabel);
            this.Controls.Add(this.wwwrootDirection);
            this.Controls.Add(this.wwwrootDirectionLabel);
            this.Controls.Add(this.ProjectDirectionText);
            this.Controls.Add(this.ProjectDirectionLabel);
            this.Name = "AutoPublish";
            this.Text = "AutoPublish";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}