namespace DroneTransferSimulator
{
    partial class SimulationProperty
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
            this.goldenTimeLabel = new System.Windows.Forms.Label();
            this.goldenTimeText1 = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.goldenTimeText2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // goldenTimeLabel
            // 
            this.goldenTimeLabel.AutoSize = true;
            this.goldenTimeLabel.Location = new System.Drawing.Point(23, 31);
            this.goldenTimeLabel.Name = "goldenTimeLabel";
            this.goldenTimeLabel.Size = new System.Drawing.Size(169, 12);
            this.goldenTimeLabel.TabIndex = 0;
            this.goldenTimeLabel.Text = "Golden Time1 [sec] (Green)";
            // 
            // goldenTimeText1
            // 
            this.goldenTimeText1.Location = new System.Drawing.Point(198, 28);
            this.goldenTimeText1.Name = "goldenTimeText1";
            this.goldenTimeText1.Size = new System.Drawing.Size(91, 21);
            this.goldenTimeText1.TabIndex = 1;
            this.goldenTimeText1.Text = "300";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(171, 97);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(131, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Golden Time2 [sec] (Yellow)";
            // 
            // goldenTimeText2
            // 
            this.goldenTimeText2.Location = new System.Drawing.Point(198, 55);
            this.goldenTimeText2.Name = "goldenTimeText2";
            this.goldenTimeText2.Size = new System.Drawing.Size(91, 21);
            this.goldenTimeText2.TabIndex = 1;
            this.goldenTimeText2.Text = "480";
            // 
            // SimulationProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 132);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.goldenTimeText2);
            this.Controls.Add(this.goldenTimeText1);
            this.Controls.Add(this.goldenTimeLabel);
            this.Name = "SimulationProperty";
            this.Text = "SimulationProperty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label goldenTimeLabel;
        private System.Windows.Forms.TextBox goldenTimeText1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox goldenTimeText2;
    }
}