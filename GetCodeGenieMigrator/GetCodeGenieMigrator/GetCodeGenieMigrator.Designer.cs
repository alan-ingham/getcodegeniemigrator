namespace GetCodeGenieMigrator
{
    partial class GetCodeGenieMigrator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.textBoxWorkingDirectory = new System.Windows.Forms.TextBox();
            this.labelWorkingDirectory = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonChooseDirectory = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxWorkingDirectory
            // 
            this.textBoxWorkingDirectory.Location = new System.Drawing.Point(16, 32);
            this.textBoxWorkingDirectory.Name = "textBoxWorkingDirectory";
            this.textBoxWorkingDirectory.Size = new System.Drawing.Size(357, 26);
            this.textBoxWorkingDirectory.TabIndex = 0;
            // 
            // labelWorkingDirectory
            // 
            this.labelWorkingDirectory.AutoSize = true;
            this.labelWorkingDirectory.Location = new System.Drawing.Point(12, 9);
            this.labelWorkingDirectory.Name = "labelWorkingDirectory";
            this.labelWorkingDirectory.Size = new System.Drawing.Size(134, 20);
            this.labelWorkingDirectory.TabIndex = 1;
            this.labelWorkingDirectory.Text = "Working Directory";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(16, 159);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(117, 20);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Status: Waiting";
            // 
            // buttonChooseDirectory
            // 
            this.buttonChooseDirectory.Location = new System.Drawing.Point(16, 64);
            this.buttonChooseDirectory.Name = "buttonChooseDirectory";
            this.buttonChooseDirectory.Size = new System.Drawing.Size(179, 39);
            this.buttonChooseDirectory.TabIndex = 3;
            this.buttonChooseDirectory.Text = "Choose Directory";
            this.buttonChooseDirectory.UseVisualStyleBackColor = true;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(194, 64);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(179, 39);
            this.buttonConvert.TabIndex = 4;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            // 
            // GetCodeGenieMigrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 191);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonChooseDirectory);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelWorkingDirectory);
            this.Controls.Add(this.textBoxWorkingDirectory);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GetCodeGenieMigrator";
            this.Text = "GetCodeGenie Migrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWorkingDirectory;
        private System.Windows.Forms.Label labelWorkingDirectory;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonChooseDirectory;
        private System.Windows.Forms.Button buttonConvert;
    }
}
