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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occuredTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.droneArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.stationLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationLng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.droneElapsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ambulanceElapsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.latitude,
            this.longitude,
            this.occuredTime,
            this.droneArrivalTime,
            this.result});
            this.dataGridView1.Location = new System.Drawing.Point(12, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(560, 418);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // index
            // 
            this.index.HeaderText = "Index";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            this.index.Visible = false;
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
            this.longitude.Width = 80;
            // 
            // occuredTime
            // 
            this.occuredTime.HeaderText = "Occured Time";
            this.occuredTime.Name = "occuredTime";
            this.occuredTime.ReadOnly = true;
            this.occuredTime.Width = 135;
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
            this.result.Width = 70;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(560, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Analyze";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.gMapControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(440, 450);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 2;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(405, 185);
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
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 0);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(438, 384);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stationLat,
            this.stationLng,
            this.droneElapsedTime,
            this.ambulanceElapsedTime});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(438, 58);
            this.dataGridView2.TabIndex = 1;
            // 
            // stationLat
            // 
            this.stationLat.HeaderText = "Station Latitude";
            this.stationLat.Name = "stationLat";
            this.stationLat.ReadOnly = true;
            this.stationLat.Width = 80;
            // 
            // stationLng
            // 
            this.stationLng.HeaderText = "Station Longitude";
            this.stationLng.Name = "stationLng";
            this.stationLng.ReadOnly = true;
            this.stationLng.Width = 80;
            // 
            // droneElapsedTime
            // 
            this.droneElapsedTime.HeaderText = "Drone Elapsed Time";
            this.droneElapsedTime.Name = "droneElapsedTime";
            this.droneElapsedTime.ReadOnly = true;
            this.droneElapsedTime.Width = 130;
            // 
            // ambulanceElapsedTime
            // 
            this.ambulanceElapsedTime.HeaderText = "Ambulance Elapsed Time";
            this.ambulanceElapsedTime.Name = "ambulanceElapsedTime";
            this.ambulanceElapsedTime.ReadOnly = true;
            this.ambulanceElapsedTime.Width = 130;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
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
            // SimulationResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 481);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Name = "SimulationResult";
            this.Text = "Drone Transfer Simulator";
            this.Load += new System.EventHandler(this.SimulationResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn occuredTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn droneArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationLat;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationLng;
        private System.Windows.Forms.DataGridViewTextBoxColumn droneElapsedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ambulanceElapsedTime;
    }
}

