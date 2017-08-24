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
            this.eventCsvPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            // eventCsvPath
            // 
            this.eventCsvPath.Enabled = false;
            this.eventCsvPath.Location = new System.Drawing.Point(85, 35);
            this.eventCsvPath.Name = "eventCsvPath";
            this.eventCsvPath.Size = new System.Drawing.Size(173, 21);
            this.eventCsvPath.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Upload CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoadEventCsv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 91);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.eventCsvPath);
            this.Controls.Add(this.filePath);
            this.Name = "LoadEventCsv";
            this.Text = "Event CSV Importer";
            this.Load += new System.EventHandler(this.LoadEventCsv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filePath;
        private System.Windows.Forms.TextBox eventCsvPath;
        private System.Windows.Forms.Button button1;
    }
}