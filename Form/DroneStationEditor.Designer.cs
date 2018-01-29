﻿namespace DroneTransferSimulator
{
    partial class DroneStationEditor
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
            if(disposing && (components != null))
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
            this.stationTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.addDroneStation = new System.Windows.Forms.Button();
            this.deleteDroneStation = new System.Windows.Forms.Button();
            this.stationMap = new GMap.NET.WindowsForms.GMapControl();
            this.droneCntInput = new System.Windows.Forms.TextBox();
            this.longitudeInput = new System.Windows.Forms.TextBox();
            this.latitudeInput = new System.Windows.Forms.TextBox();
            this.stationNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.initButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.stationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.droneCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stationTable)).BeginInit();
            this.SuspendLayout();
            // 
            // stationTable
            // 
            this.stationTable.AllowUserToAddRows = false;
            this.stationTable.AllowUserToResizeRows = false;
            this.stationTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stationTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stationName,
            this.latitude,
            this.longitude,
            this.droneCnt});
            this.stationTable.Location = new System.Drawing.Point(12, 50);
            this.stationTable.Name = "stationTable";
            this.stationTable.ReadOnly = true;
            this.stationTable.RowTemplate.Height = 23;
            this.stationTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stationTable.Size = new System.Drawing.Size(412, 260);
            this.stationTable.TabIndex = 0;
            this.stationTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stationTable_CellClick);
            this.stationTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.stationTable_RowEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drone Station Map";
            // 
            // addDroneStation
            // 
            this.addDroneStation.Location = new System.Drawing.Point(342, 21);
            this.addDroneStation.Name = "addDroneStation";
            this.addDroneStation.Size = new System.Drawing.Size(38, 23);
            this.addDroneStation.TabIndex = 2;
            this.addDroneStation.Text = "Add";
            this.addDroneStation.UseVisualStyleBackColor = true;
            this.addDroneStation.Click += new System.EventHandler(this.addDroneStation_Click);
            // 
            // deleteDroneStation
            // 
            this.deleteDroneStation.Location = new System.Drawing.Point(386, 21);
            this.deleteDroneStation.Name = "deleteDroneStation";
            this.deleteDroneStation.Size = new System.Drawing.Size(38, 23);
            this.deleteDroneStation.TabIndex = 3;
            this.deleteDroneStation.Text = "Del";
            this.deleteDroneStation.UseVisualStyleBackColor = true;
            this.deleteDroneStation.Click += new System.EventHandler(this.deleteDroneStation_Click);
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
            this.stationMap.Location = new System.Drawing.Point(430, 24);
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
            this.stationMap.Size = new System.Drawing.Size(237, 257);
            this.stationMap.TabIndex = 4;
            this.stationMap.Zoom = 0D;
            this.stationMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.stationMap_OnMarkerClick);
            this.stationMap.Load += new System.EventHandler(this.stationMap_Load);
            // 
            // droneCntInput
            // 
            this.droneCntInput.Location = new System.Drawing.Point(267, 23);
            this.droneCntInput.Name = "droneCntInput";
            this.droneCntInput.Size = new System.Drawing.Size(69, 21);
            this.droneCntInput.TabIndex = 15;
            // 
            // longitudeInput
            // 
            this.longitudeInput.Location = new System.Drawing.Point(191, 24);
            this.longitudeInput.Name = "longitudeInput";
            this.longitudeInput.Size = new System.Drawing.Size(70, 21);
            this.longitudeInput.TabIndex = 14;
            // 
            // latitudeInput
            // 
            this.latitudeInput.Location = new System.Drawing.Point(121, 23);
            this.latitudeInput.Name = "latitudeInput";
            this.latitudeInput.Size = new System.Drawing.Size(64, 21);
            this.latitudeInput.TabIndex = 13;
            // 
            // stationNameInput
            // 
            this.stationNameInput.AcceptsTab = true;
            this.stationNameInput.Location = new System.Drawing.Point(12, 23);
            this.stationNameInput.Name = "stationNameInput";
            this.stationNameInput.Size = new System.Drawing.Size(103, 21);
            this.stationNameInput.TabIndex = 12;
            this.stationNameInput.TextChanged += new System.EventHandler(this.stationNameInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Drone Count";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Latitude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Longitude";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Station Name";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(511, 287);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 16;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // initButton
            // 
            this.initButton.Location = new System.Drawing.Point(430, 287);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(75, 23);
            this.initButton.TabIndex = 17;
            this.initButton.Text = "Init";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(592, 287);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // stationName
            // 
            this.stationName.FillWeight = 101.5228F;
            this.stationName.HeaderText = "Station Name";
            this.stationName.Name = "stationName";
            this.stationName.ReadOnly = true;
            // 
            // latitude
            // 
            this.latitude.FillWeight = 94.96483F;
            this.latitude.HeaderText = "Latitude";
            this.latitude.Name = "latitude";
            this.latitude.ReadOnly = true;
            // 
            // longitude
            // 
            this.longitude.FillWeight = 97.4903F;
            this.longitude.HeaderText = "Longitude";
            this.longitude.Name = "longitude";
            this.longitude.ReadOnly = true;
            // 
            // droneCnt
            // 
            this.droneCnt.FillWeight = 106.022F;
            this.droneCnt.HeaderText = "Drone Count";
            this.droneCnt.Name = "droneCnt";
            this.droneCnt.ReadOnly = true;
            // 
            // DroneStationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 322);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.initButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.droneCntInput);
            this.Controls.Add(this.longitudeInput);
            this.Controls.Add(this.latitudeInput);
            this.Controls.Add(this.stationNameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stationMap);
            this.Controls.Add(this.deleteDroneStation);
            this.Controls.Add(this.addDroneStation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stationTable);
            this.Name = "DroneStationEditor";
            this.Text = "Drone Station Editor";
            this.Load += new System.EventHandler(this.droneStationEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stationTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView stationTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addDroneStation;
        private System.Windows.Forms.Button deleteDroneStation;
        private GMap.NET.WindowsForms.GMapControl stationMap;
        private System.Windows.Forms.TextBox droneCntInput;
        private System.Windows.Forms.TextBox longitudeInput;
        private System.Windows.Forms.TextBox latitudeInput;
        private System.Windows.Forms.TextBox stationNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn droneCnt;
    }
}

