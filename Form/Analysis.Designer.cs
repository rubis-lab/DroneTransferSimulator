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
            this.button1 = new System.Windows.Forms.Button();
            this.regionRestriction = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eventRestriction = new System.Windows.Forms.ComboBox();
            this.stationRestriction = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.analyzeResultTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.regionRestriction.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemListBox
            // 
            this.itemListBox.CheckOnClick = true;
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.Items.AddRange(new object[] {
            "Rescue Success Rate",
            "Coverage Success Rate",
            "Mean of Elapsed Time",
            "Standard Deviation of Elapsed Time"});
            this.itemListBox.Location = new System.Drawing.Point(10, 20);
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
            this.drone});
            this.analyzeResultTable.Location = new System.Drawing.Point(12, 298);
            this.analyzeResultTable.Name = "analyzeResultTable";
            this.analyzeResultTable.RowTemplate.Height = 23;
            this.analyzeResultTable.Size = new System.Drawing.Size(362, 167);
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
            this.groupBox1.Location = new System.Drawing.Point(18, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 107);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analysis Item";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "↓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // regionRestriction
            // 
            this.regionRestriction.Controls.Add(this.label2);
            this.regionRestriction.Controls.Add(this.label1);
            this.regionRestriction.Controls.Add(this.eventRestriction);
            this.regionRestriction.Controls.Add(this.stationRestriction);
            this.regionRestriction.Location = new System.Drawing.Point(18, 12);
            this.regionRestriction.Name = "regionRestriction";
            this.regionRestriction.Size = new System.Drawing.Size(362, 107);
            this.regionRestriction.TabIndex = 3;
            this.regionRestriction.TabStop = false;
            this.regionRestriction.Text = "Region Restriction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Event Restriction";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Station Restriction";
            // 
            // eventRestriction
            // 
            this.eventRestriction.FormattingEnabled = true;
            this.eventRestriction.Items.AddRange(new object[] {
            "None",
            "강남구",
            "광진구",
            "강북구",
            "강서구",
            "구로구",
            "금천구",
            "관악구",
            "강남구",
            "강동구",
            "노원구",
            "동대문구",
            "중랑구",
            "도봉구",
            "마포구",
            "서초구",
            "서대문구",
            "송파구",
            "성북구",
            "성동구",
            "은평구",
            "용산구",
            "영등포구",
            "양천구",
            "종로구",
            "중구",
            "중랑구"});
            this.eventRestriction.Location = new System.Drawing.Point(137, 62);
            this.eventRestriction.Name = "eventRestriction";
            this.eventRestriction.Size = new System.Drawing.Size(121, 20);
            this.eventRestriction.TabIndex = 1;
            // 
            // stationRestriction
            // 
            this.stationRestriction.FormattingEnabled = true;
            this.stationRestriction.Items.AddRange(new object[] {
            "None",
            "강남구",
            "광진구",
            "강북구",
            "강서구",
            "구로구",
            "금천구",
            "관악구",
            "강남구",
            "강동구",
            "노원구",
            "동대문구",
            "중랑구",
            "도봉구",
            "마포구",
            "서초구",
            "서대문구",
            "송파구",
            "성북구",
            "성동구",
            "은평구",
            "용산구",
            "영등포구",
            "양천구",
            "종로구",
            "중구",
            "중랑구"});
            this.stationRestriction.Location = new System.Drawing.Point(137, 36);
            this.stationRestriction.Name = "stationRestriction";
            this.stationRestriction.Size = new System.Drawing.Size(121, 20);
            this.stationRestriction.TabIndex = 0;
            // 
            // Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 494);
            this.Controls.Add(this.regionRestriction);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox regionRestriction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox eventRestriction;
        private System.Windows.Forms.ComboBox stationRestriction;
    }
}