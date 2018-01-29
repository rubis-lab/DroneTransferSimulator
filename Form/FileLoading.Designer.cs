namespace DroneTransferSimulator
{
    partial class FileLoading
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
            this.stationLoadButton = new System.Windows.Forms.Button();
            this.eventLoadButton = new System.Windows.Forms.Button();
            this.stationCSVTextbox = new System.Windows.Forms.TextBox();
            this.eventCSVTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stationLoadButton
            // 
            this.stationLoadButton.Location = new System.Drawing.Point(476, 69);
            this.stationLoadButton.Name = "stationLoadButton";
            this.stationLoadButton.Size = new System.Drawing.Size(26, 24);
            this.stationLoadButton.TabIndex = 32;
            this.stationLoadButton.Text = "...";
            this.stationLoadButton.UseVisualStyleBackColor = true;
            this.stationLoadButton.Click += new System.EventHandler(this.stationLoadButton_Click);
            // 
            // eventLoadButton
            // 
            this.eventLoadButton.Location = new System.Drawing.Point(476, 31);
            this.eventLoadButton.Name = "eventLoadButton";
            this.eventLoadButton.Size = new System.Drawing.Size(26, 24);
            this.eventLoadButton.TabIndex = 31;
            this.eventLoadButton.Text = "...";
            this.eventLoadButton.UseVisualStyleBackColor = true;
            this.eventLoadButton.Click += new System.EventHandler(this.eventLoadButton_Click);
            // 
            // stationCSVTextbox
            // 
            this.stationCSVTextbox.Location = new System.Drawing.Point(12, 70);
            this.stationCSVTextbox.Name = "stationCSVTextbox";
            this.stationCSVTextbox.ReadOnly = true;
            this.stationCSVTextbox.Size = new System.Drawing.Size(458, 21);
            this.stationCSVTextbox.TabIndex = 30;
            // 
            // eventCSVTextbox
            // 
            this.eventCSVTextbox.Location = new System.Drawing.Point(12, 32);
            this.eventCSVTextbox.Name = "eventCSVTextbox";
            this.eventCSVTextbox.ReadOnly = true;
            this.eventCSVTextbox.Size = new System.Drawing.Size(458, 21);
            this.eventCSVTextbox.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "Drone Station CSV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "Event CSV";
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(349, 99);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(153, 23);
            this.apply.TabIndex = 36;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // FileLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 131);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.stationLoadButton);
            this.Controls.Add(this.eventLoadButton);
            this.Controls.Add(this.stationCSVTextbox);
            this.Controls.Add(this.eventCSVTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FileLoading";
            this.Text = "FileLoading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stationLoadButton;
        private System.Windows.Forms.Button eventLoadButton;
        public System.Windows.Forms.TextBox stationCSVTextbox;
        public System.Windows.Forms.TextBox eventCSVTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button apply;
    }
}