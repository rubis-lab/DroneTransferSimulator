namespace DroneTransferSimulator
{
    partial class SimulatorUI
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventMap = new GMap.NET.WindowsForms.GMapControl();
            this.eventList = new System.Windows.Forms.DataGridView();
            this.latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occuredTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ambulTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stationCsvTextbox = new System.Windows.Forms.TextBox();
            this.eventCsvTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.stationMapLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.stationMap = new GMap.NET.WindowsForms.GMapControl();
            this.eventMapLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.eventList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventMap
            // 
            this.eventMap.Bearing = 0F;
            this.eventMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventMap.CanDragMap = true;
            this.eventMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.eventMap.GrayScaleMode = false;
            this.eventMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.eventMap.LevelsKeepInMemmory = 5;
            this.eventMap.Location = new System.Drawing.Point(12, 33);
            this.eventMap.MarkersEnabled = true;
            this.eventMap.MaxZoom = 2;
            this.eventMap.MinZoom = 2;
            this.eventMap.MouseWheelZoomEnabled = true;
            this.eventMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.eventMap.Name = "eventMap";
            this.eventMap.NegativeMode = false;
            this.eventMap.PolygonsEnabled = true;
            this.eventMap.RetryLoadTile = 0;
            this.eventMap.RoutesEnabled = true;
            this.eventMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.eventMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.eventMap.ShowTileGridLines = false;
            this.eventMap.Size = new System.Drawing.Size(240, 311);
            this.eventMap.TabIndex = 4;
            this.eventMap.Zoom = 0D;
            this.eventMap.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // eventList
            // 
            this.eventList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.eventList.AllowUserToAddRows = false;
            this.eventList.AllowUserToDeleteRows = false;
            this.eventList.AllowUserToResizeRows = false;
            this.eventList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.latitude,
            this.longitude,
            this.occuredTime,
            this.ambulTime});
            this.eventList.Location = new System.Drawing.Point(12, 83);
            this.eventList.Name = "eventList";
            this.eventList.ReadOnly = true;
            this.eventList.RowTemplate.Height = 23;
            this.eventList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventList.Size = new System.Drawing.Size(477, 286);
            this.eventList.TabIndex = 13;
            this.eventList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventList_CellClick);
            // 
            // latitude
            // 
            this.latitude.HeaderText = "Latitude";
            this.latitude.Name = "latitude";
            this.latitude.ReadOnly = true;
            this.latitude.Width = 80;
            // 
            // longitude
            // 
            this.longitude.HeaderText = "Longitude";
            this.longitude.Name = "longitude";
            this.longitude.ReadOnly = true;
            this.longitude.Width = 95;
            // 
            // occuredTime
            // 
            this.occuredTime.HeaderText = "Occured Time";
            this.occuredTime.Name = "occuredTime";
            this.occuredTime.ReadOnly = true;
            this.occuredTime.Width = 130;
            // 
            // ambulTime
            // 
            this.ambulTime.HeaderText = "Ambulance Time";
            this.ambulTime.Name = "ambulTime";
            this.ambulTime.ReadOnly = true;
            this.ambulTime.Width = 130;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stationCsvTextbox
            // 
            this.stationCsvTextbox.Location = new System.Drawing.Point(151, 51);
            this.stationCsvTextbox.Name = "stationCsvTextbox";
            this.stationCsvTextbox.Size = new System.Drawing.Size(100, 21);
            this.stationCsvTextbox.TabIndex = 10;
            // 
            // eventCsvTextbox
            // 
            this.eventCsvTextbox.Location = new System.Drawing.Point(151, 20);
            this.eventCsvTextbox.Name = "eventCsvTextbox";
            this.eventCsvTextbox.Size = new System.Drawing.Size(100, 21);
            this.eventCsvTextbox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Drone Station csv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Event csv";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(815, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(217, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Edit Drone Station";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // stationMapLabel
            // 
            this.stationMapLabel.AutoSize = true;
            this.stationMapLabel.Location = new System.Drawing.Point(256, 17);
            this.stationMapLabel.Name = "stationMapLabel";
            this.stationMapLabel.Size = new System.Drawing.Size(109, 12);
            this.stationMapLabel.TabIndex = 15;
            this.stationMapLabel.Text = "Drone Station Map";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Start Time:";
            // 
            // startTimePicker
            // 
            this.startTimePicker.Location = new System.Drawing.Point(94, 386);
            this.startTimePicker.MaxDate = new System.DateTime(2017, 8, 25, 0, 0, 0, 0);
            this.startTimePicker.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(200, 21);
            this.startTimePicker.TabIndex = 17;
            this.startTimePicker.Value = new System.DateTime(2017, 8, 25, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "~ End Time:";
            // 
            // endTimePicker
            // 
            this.endTimePicker.Location = new System.Drawing.Point(383, 386);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(200, 21);
            this.endTimePicker.TabIndex = 19;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(34, 431);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(972, 38);
            this.button4.TabIndex = 20;
            this.button4.Text = "Start Simulation";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // stationMap
            // 
            this.stationMap.Bearing = 0F;
            this.stationMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stationMap.CanDragMap = true;
            this.stationMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.stationMap.GrayScaleMode = false;
            this.stationMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.stationMap.LevelsKeepInMemmory = 5;
            this.stationMap.Location = new System.Drawing.Point(267, 33);
            this.stationMap.MarkersEnabled = true;
            this.stationMap.MaxZoom = 2;
            this.stationMap.MinZoom = 2;
            this.stationMap.MouseWheelZoomEnabled = true;
            this.stationMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.stationMap.Name = "stationMap";
            this.stationMap.NegativeMode = false;
            this.stationMap.PolygonsEnabled = true;
            this.stationMap.RetryLoadTile = 0;
            this.stationMap.RoutesEnabled = true;
            this.stationMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.stationMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.stationMap.ShowTileGridLines = false;
            this.stationMap.Size = new System.Drawing.Size(244, 311);
            this.stationMap.TabIndex = 21;
            this.stationMap.Zoom = 0D;
            // 
            // eventMapLabel
            // 
            this.eventMapLabel.AutoSize = true;
            this.eventMapLabel.Location = new System.Drawing.Point(10, 17);
            this.eventMapLabel.Name = "eventMapLabel";
            this.eventMapLabel.Size = new System.Drawing.Size(65, 12);
            this.eventMapLabel.TabIndex = 22;
            this.eventMapLabel.Text = "Event Map";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stationMap);
            this.groupBox1.Controls.Add(this.eventMapLabel);
            this.groupBox1.Controls.Add(this.eventMap);
            this.groupBox1.Controls.Add(this.stationMapLabel);
            this.groupBox1.Location = new System.Drawing.Point(508, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 360);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // SimulatorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 481);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.eventList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stationCsvTextbox);
            this.Controls.Add(this.eventCsvTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SimulatorUI";
            this.Text = "Drone Transfer Simulator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SimulatorUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl eventMap;
        public System.Windows.Forms.DataGridView eventList;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn occuredTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ambulTime;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox stationCsvTextbox;
        public System.Windows.Forms.TextBox eventCsvTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label stationMapLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Button button4;
        private GMap.NET.WindowsForms.GMapControl stationMap;
        private System.Windows.Forms.Label eventMapLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

