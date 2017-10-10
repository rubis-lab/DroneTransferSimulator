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
            this.eventDataGridView = new System.Windows.Forms.DataGridView();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occuredTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ambulTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationEditButton = new System.Windows.Forms.Button();
            this.stationMapLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startSimButton = new System.Windows.Forms.Button();
            this.stationMap = new GMap.NET.WindowsForms.GMapControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eventMapLabel = new System.Windows.Forms.Label();
            this.eventMap = new GMap.NET.WindowsForms.GMapControl();
            this.fileLoading = new System.Windows.Forms.Button();
            this.property = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventDataGridView
            // 
            this.eventDataGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.eventDataGridView.AllowUserToAddRows = false;
            this.eventDataGridView.AllowUserToDeleteRows = false;
            this.eventDataGridView.AllowUserToResizeRows = false;
            this.eventDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.address,
            this.occuredTime,
            this.ambulTime,
            this.latitude,
            this.longitude});
            this.eventDataGridView.Location = new System.Drawing.Point(12, 123);
            this.eventDataGridView.Name = "eventDataGridView";
            this.eventDataGridView.ReadOnly = true;
            this.eventDataGridView.RowTemplate.Height = 23;
            this.eventDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDataGridView.Size = new System.Drawing.Size(490, 270);
            this.eventDataGridView.TabIndex = 13;
            this.eventDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventDataGridView_RowEnter);
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 130;
            // 
            // occuredTime
            // 
            this.occuredTime.HeaderText = "Occured Time";
            this.occuredTime.Name = "occuredTime";
            this.occuredTime.ReadOnly = true;
            this.occuredTime.Width = 142;
            // 
            // ambulTime
            // 
            this.ambulTime.HeaderText = "Ambulance Time";
            this.ambulTime.Name = "ambulTime";
            this.ambulTime.ReadOnly = true;
            this.ambulTime.Width = 142;
            // 
            // latitude
            // 
            this.latitude.HeaderText = "Latitude";
            this.latitude.Name = "latitude";
            this.latitude.ReadOnly = true;
            this.latitude.Width = 60;
            // 
            // longitude
            // 
            this.longitude.HeaderText = "Longitude";
            this.longitude.Name = "longitude";
            this.longitude.ReadOnly = true;
            this.longitude.Width = 60;
            // 
            // stationEditButton
            // 
            this.stationEditButton.Location = new System.Drawing.Point(815, 403);
            this.stationEditButton.Name = "stationEditButton";
            this.stationEditButton.Size = new System.Drawing.Size(217, 23);
            this.stationEditButton.TabIndex = 14;
            this.stationEditButton.Text = "Edit Drone Station";
            this.stationEditButton.UseVisualStyleBackColor = true;
            this.stationEditButton.Click += new System.EventHandler(this.stationEditButton_Click);
            // 
            // stationMapLabel
            // 
            this.stationMapLabel.AutoSize = true;
            this.stationMapLabel.Location = new System.Drawing.Point(265, 11);
            this.stationMapLabel.Name = "stationMapLabel";
            this.stationMapLabel.Size = new System.Drawing.Size(109, 12);
            this.stationMapLabel.TabIndex = 15;
            this.stationMapLabel.Text = "Drone Station Map";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Start Time:";
            // 
            // startTimePicker
            // 
            this.startTimePicker.Location = new System.Drawing.Point(94, 405);
            this.startTimePicker.MaxDate = new System.DateTime(2017, 8, 25, 0, 0, 0, 0);
            this.startTimePicker.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(200, 21);
            this.startTimePicker.TabIndex = 17;
            this.startTimePicker.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "~ End Time:";
            // 
            // endTimePicker
            // 
            this.endTimePicker.Location = new System.Drawing.Point(383, 405);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(200, 21);
            this.endTimePicker.TabIndex = 19;
            this.endTimePicker.Value = new System.DateTime(2013, 1, 10, 0, 0, 0, 0);
            // 
            // startSimButton
            // 
            this.startSimButton.Location = new System.Drawing.Point(12, 431);
            this.startSimButton.Name = "startSimButton";
            this.startSimButton.Size = new System.Drawing.Size(1020, 38);
            this.startSimButton.TabIndex = 20;
            this.startSimButton.Text = "Start Simulation";
            this.startSimButton.UseVisualStyleBackColor = true;
            this.startSimButton.Click += new System.EventHandler(this.startSimButton_Click);
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
            this.stationMap.Location = new System.Drawing.Point(267, 24);
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
            this.stationMap.Size = new System.Drawing.Size(251, 349);
            this.stationMap.TabIndex = 21;
            this.stationMap.Zoom = 0D;
            this.stationMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.stationMap_OnMarkerClick);
            this.stationMap.Load += new System.EventHandler(this.stationMap_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stationMap);
            this.groupBox1.Controls.Add(this.eventMapLabel);
            this.groupBox1.Controls.Add(this.eventMap);
            this.groupBox1.Controls.Add(this.stationMapLabel);
            this.groupBox1.Location = new System.Drawing.Point(508, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 379);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // eventMapLabel
            // 
            this.eventMapLabel.AutoSize = true;
            this.eventMapLabel.Location = new System.Drawing.Point(6, 11);
            this.eventMapLabel.Name = "eventMapLabel";
            this.eventMapLabel.Size = new System.Drawing.Size(65, 12);
            this.eventMapLabel.TabIndex = 22;
            this.eventMapLabel.Text = "Event Map";
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
            this.eventMap.Location = new System.Drawing.Point(6, 24);
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
            this.eventMap.Size = new System.Drawing.Size(255, 349);
            this.eventMap.TabIndex = 4;
            this.eventMap.Zoom = 0D;
            this.eventMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.eventMap_OnMarkerClick);
            this.eventMap.Load += new System.EventHandler(this.eventMap_Load);
            // 
            // fileLoading
            // 
            this.fileLoading.Location = new System.Drawing.Point(23, 31);
            this.fileLoading.Name = "fileLoading";
            this.fileLoading.Size = new System.Drawing.Size(226, 27);
            this.fileLoading.TabIndex = 27;
            this.fileLoading.Text = "File Loading";
            this.fileLoading.UseVisualStyleBackColor = true;
            this.fileLoading.Click += new System.EventHandler(this.fileLoading_Click);
            // 
            // property
            // 
            this.property.Location = new System.Drawing.Point(23, 73);
            this.property.Name = "property";
            this.property.Size = new System.Drawing.Size(226, 27);
            this.property.TabIndex = 28;
            this.property.Text = "Simulation Property";
            this.property.UseVisualStyleBackColor = true;
            // 
            // SimulatorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 481);
            this.Controls.Add(this.property);
            this.Controls.Add(this.fileLoading);
            this.Controls.Add(this.startSimButton);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stationEditButton);
            this.Controls.Add(this.eventDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "SimulatorUI";
            this.Text = "Drone Transfer Simulator";
            this.Load += new System.EventHandler(this.SimulatorUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView eventDataGridView;
        private System.Windows.Forms.Button stationEditButton;
        private System.Windows.Forms.Label stationMapLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Button startSimButton;
        private GMap.NET.WindowsForms.GMapControl stationMap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label eventMapLabel;
        public GMap.NET.WindowsForms.GMapControl eventMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn occuredTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ambulTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
        private System.Windows.Forms.Button fileLoading;
        private System.Windows.Forms.Button property;
    }
}

