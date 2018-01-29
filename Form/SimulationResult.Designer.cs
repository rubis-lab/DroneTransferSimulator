namespace DroneTransferSimulator
{
    partial class SimulationResult
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
            this.components = new System.ComponentModel.Container();
            this.eventTable = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occuredTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.droneArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.eventMap = new GMap.NET.WindowsForms.GMapControl();
            this.eventDetailTable = new System.Windows.Forms.DataGridView();
            this.stationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.droneElapsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ambulanceElapsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.eventTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDetailTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventTable
            // 
            this.eventTable.AllowUserToAddRows = false;
            this.eventTable.AllowUserToDeleteRows = false;
            this.eventTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.Address,
            this.occuredTime,
            this.droneArrivalTime,
            this.result,
            this.latitude,
            this.longitude,
            this.note});
            this.eventTable.Location = new System.Drawing.Point(12, 20);
            this.eventTable.Name = "eventTable";
            this.eventTable.ReadOnly = true;
            this.eventTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eventTable.RowTemplate.Height = 23;
            this.eventTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventTable.Size = new System.Drawing.Size(560, 418);
            this.eventTable.TabIndex = 0;
            this.eventTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventTable_RowEnter);
            // 
            // index
            // 
            this.index.HeaderText = "Index";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            this.index.Visible = false;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 130;
            // 
            // occuredTime
            // 
            this.occuredTime.HeaderText = "Occured Time";
            this.occuredTime.Name = "occuredTime";
            this.occuredTime.ReadOnly = true;
            this.occuredTime.Width = 125;
            // 
            // droneArrivalTime
            // 
            this.droneArrivalTime.HeaderText = "Drone Arrival Time";
            this.droneArrivalTime.Name = "droneArrivalTime";
            this.droneArrivalTime.ReadOnly = true;
            this.droneArrivalTime.Width = 135;
            // 
            // result
            // 
            this.result.HeaderText = "Result";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.result.Width = 105;
            // 
            // latitude
            // 
            this.latitude.HeaderText = "Latitude";
            this.latitude.Name = "latitude";
            this.latitude.ReadOnly = true;
            this.latitude.Width = 65;
            // 
            // longitude
            // 
            this.longitude.HeaderText = "Longitude";
            this.longitude.Name = "longitude";
            this.longitude.ReadOnly = true;
            this.longitude.Width = 70;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(6, 439);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(560, 25);
            this.analyzeButton.TabIndex = 2;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(586, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 470);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Details";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trackBar1);
            this.splitContainer1.Panel1.Controls.Add(this.eventMap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.eventDetailTable);
            this.splitContainer1.Size = new System.Drawing.Size(440, 450);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 2;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.trackBar1.Location = new System.Drawing.Point(403, 175);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(1);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(34, 201);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 10;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // eventMap
            // 
            this.eventMap.Bearing = 0F;
            this.eventMap.CanDragMap = true;
            this.eventMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.eventMap.GrayScaleMode = false;
            this.eventMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.eventMap.LevelsKeepInMemmory = 5;
            this.eventMap.Location = new System.Drawing.Point(0, 0);
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
            this.eventMap.Size = new System.Drawing.Size(438, 374);
            this.eventMap.TabIndex = 0;
            this.eventMap.Zoom = 0D;
            // 
            // eventDetailTable
            // 
            this.eventDetailTable.AllowUserToAddRows = false;
            this.eventDetailTable.AllowUserToDeleteRows = false;
            this.eventDetailTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDetailTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stationName,
            this.stationLatitude,
            this.stationLongitude,
            this.droneElapsedTime,
            this.ambulanceElapsedTime});
            this.eventDetailTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventDetailTable.Location = new System.Drawing.Point(0, 0);
            this.eventDetailTable.Name = "eventDetailTable";
            this.eventDetailTable.ReadOnly = true;
            this.eventDetailTable.RowHeadersVisible = false;
            this.eventDetailTable.Size = new System.Drawing.Size(438, 68);
            this.eventDetailTable.TabIndex = 1;
            // 
            // stationName
            // 
            this.stationName.HeaderText = "Station Name";
            this.stationName.Name = "stationName";
            this.stationName.ReadOnly = true;
            this.stationName.Width = 85;
            // 
            // stationLatitude
            // 
            this.stationLatitude.HeaderText = "Station Latitude";
            this.stationLatitude.Name = "stationLatitude";
            this.stationLatitude.ReadOnly = true;
            this.stationLatitude.Width = 90;
            // 
            // stationLongitude
            // 
            this.stationLongitude.HeaderText = "Station Longitude";
            this.stationLongitude.Name = "stationLongitude";
            this.stationLongitude.ReadOnly = true;
            this.stationLongitude.Width = 90;
            // 
            // droneElapsedTime
            // 
            this.droneElapsedTime.HeaderText = "Drone Elapsed Time";
            this.droneElapsedTime.Name = "droneElapsedTime";
            this.droneElapsedTime.ReadOnly = true;
            this.droneElapsedTime.Width = 80;
            // 
            // ambulanceElapsedTime
            // 
            this.ambulanceElapsedTime.HeaderText = "Ambulance Elapsed Time";
            this.ambulanceElapsedTime.Name = "ambulanceElapsedTime";
            this.ambulanceElapsedTime.ReadOnly = true;
            this.ambulanceElapsedTime.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.analyzeButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 470);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation Result";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // note
            // 
            this.note.HeaderText = "note";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            // 
            // SimulationResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 481);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.eventTable);
            this.Controls.Add(this.groupBox2);
            this.Name = "SimulationResult";
            this.Text = "Drone Transfer Simulator";
            this.Load += new System.EventHandler(this.SimulationResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDetailTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView eventTable;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GMap.NET.WindowsForms.GMapControl eventMap;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView eventDetailTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn droneElapsedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ambulanceElapsedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn occuredTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn droneArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
    }
}

