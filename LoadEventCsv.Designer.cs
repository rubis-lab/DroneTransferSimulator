namespace DroneTransferSimulator
{
    partial class LoadEventCsv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filePath = new System.Windows.Forms.Label();
            this.filePathInput = new System.Windows.Forms.TextBox();
            this.uploadCSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.AutoSize = true;
            this.filePath.Location = new System.Drawing.Point(20, 40);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(58, 12);
            this.filePath.TabIndex = 0;
            this.filePath.Text = "File Path:";
            this.filePath.Click += new System.EventHandler(this.label1_Click);
            // 
            // filePathInput
            // 
            this.filePathInput.Location = new System.Drawing.Point(85, 35);
            this.filePathInput.Name = "filePathInput";
            this.filePathInput.Size = new System.Drawing.Size(173, 21);
            this.filePathInput.TabIndex = 1;
            // 
            // uploadCSV
            // 
            this.uploadCSV.Location = new System.Drawing.Point(270, 35);
            this.uploadCSV.Name = "uploadCSV";
            this.uploadCSV.Size = new System.Drawing.Size(104, 23);
            this.uploadCSV.TabIndex = 3;
            this.uploadCSV.Text = "Upload CSV";
            this.uploadCSV.UseVisualStyleBackColor = true;
            this.uploadCSV.Click += new System.EventHandler(this.uploadCSV_click);
            // 
            // LoadEventCsv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 91);
            this.Controls.Add(this.uploadCSV);
            this.Controls.Add(this.filePathInput);
            this.Controls.Add(this.filePath);
            this.Name = "LoadEventCsv";
            this.Text = "Event CSV Importer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadEventCsv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filePath;
        private System.Windows.Forms.TextBox filePathInput;
        private System.Windows.Forms.Button uploadCSV;
    }
}