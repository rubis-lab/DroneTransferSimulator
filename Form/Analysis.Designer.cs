namespace DroneTransferSimulator
{
    partial class Analysis
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
            this.itemListBox = new System.Windows.Forms.CheckedListBox();
            this.analyzeResultTable = new System.Windows.Forms.DataGridView();
            this.anallysisItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ambulance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.regionRestriction = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eventRestriction = new System.Windows.Forms.ComboBox();
            this.drone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drone3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.analyzeResultTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.regionRestriction.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemListBox
            // 
            this.itemListBox.CheckOnClick = true;
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.Location = new System.Drawing.Point(6, 20);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(339, 68);
            this.itemListBox.TabIndex = 0;
            this.itemListBox.SelectedIndexChanged += new System.EventHandler(this.itemListBox_SelectedIndexChanged);
            // 
            // analyzeResultTable
            // 
            this.analyzeResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.analyzeResultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.anallysisItem,
            this.ambulance,
            this.drone,
            this.drone2,
            this.drone3});
            this.analyzeResultTable.Location = new System.Drawing.Point(397, 19);
            this.analyzeResultTable.Name = "analyzeResultTable";
            this.analyzeResultTable.RowTemplate.Height = 23;
            this.analyzeResultTable.Size = new System.Drawing.Size(543, 220);
            this.analyzeResultTable.TabIndex = 1;
            this.analyzeResultTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.analyzeResultTable_CellContentClick);
            // 
            // anallysisItem
            // 
            this.anallysisItem.HeaderText = "Analysis Item";
            this.anallysisItem.Name = "anallysisItem";
            // 
            // ambulance
            // 
            this.ambulance.HeaderText = "Ambulance";
            this.ambulance.Name = "ambulance";
            // 
            // drone
            // 
            this.drone.HeaderText = "Drone";
            this.drone.Name = "drone";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.itemListBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 107);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analysis Item";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(247, 216);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(133, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // regionRestriction
            // 
            this.regionRestriction.Controls.Add(this.label2);
            this.regionRestriction.Controls.Add(this.eventRestriction);
            this.regionRestriction.Location = new System.Drawing.Point(18, 12);
            this.regionRestriction.Name = "regionRestriction";
            this.regionRestriction.Size = new System.Drawing.Size(362, 70);
            this.regionRestriction.TabIndex = 3;
            this.regionRestriction.TabStop = false;
            this.regionRestriction.Text = "Region Restriction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Event Restriction";
            // 
            // eventRestriction
            // 
            this.eventRestriction.FormattingEnabled = true;
            this.eventRestriction.Location = new System.Drawing.Point(132, 32);
            this.eventRestriction.Name = "eventRestriction";
            this.eventRestriction.Size = new System.Drawing.Size(121, 20);
            this.eventRestriction.TabIndex = 1;
            // 
            // drone2
            // 
            this.drone2.HeaderText = "Drone2";
            this.drone2.Name = "drone2";
            // 
            // drone3
            // 
            this.drone3.HeaderText = "Drone3";
            this.drone3.Name = "drone3";
            // 
            // Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 253);
            this.Controls.Add(this.regionRestriction);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.analyzeResultTable);
            this.Controls.Add(this.groupBox1);
            this.Name = "Analysis";
            this.Text = "Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.analyzeResultTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.regionRestriction.ResumeLayout(false);
            this.regionRestriction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox itemListBox;
        private System.Windows.Forms.DataGridView analyzeResultTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn anallysisItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ambulance;
        private System.Windows.Forms.DataGridViewTextBoxColumn drone;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox regionRestriction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox eventRestriction;
        private System.Windows.Forms.DataGridViewTextBoxColumn drone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn drone3;
    }
}