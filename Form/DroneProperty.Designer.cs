namespace DroneTransferSimulator
{
    partial class DroneProperty
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
            if(disposing && (components != null))
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.w_temp_low = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w_temp_high = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w_rain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w_winds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w_snow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w_sight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.subzeroCheckBox = new System.Windows.Forms.CheckBox();
            this.rainCheckBox = new System.Windows.Forms.CheckBox();
            this.lightCheckBox = new System.Windows.Forms.CheckBox();
            this.snowCheckBox = new System.Windows.Forms.CheckBox();
            this.sightCheckBox = new System.Windows.Forms.CheckBox();
            this.maxSpeedTextBox = new System.Windows.Forms.TextBox();
            this.maxDistanceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.w_temp_low,
            this.w_temp_high,
            this.w_rain,
            this.w_winds,
            this.w_snow,
            this.w_sight});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(603, 57);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // w_temp_low
            // 
            this.w_temp_low.HeaderText = "최소비행 온도 [°C]";
            this.w_temp_low.Name = "w_temp_low";
            this.w_temp_low.Width = 90;
            // 
            // w_temp_high
            // 
            this.w_temp_high.HeaderText = "최대비행 온도 [°C]";
            this.w_temp_high.Name = "w_temp_high";
            this.w_temp_high.Width = 90;
            // 
            // w_rain
            // 
            this.w_rain.HeaderText = "최대비행 강수량 [mm]";
            this.w_rain.Name = "w_rain";
            this.w_rain.Width = 110;
            // 
            // w_winds
            // 
            this.w_winds.HeaderText = "최대비행 풍속 [m/s]";
            this.w_winds.Name = "w_winds";
            this.w_winds.Width = 110;
            // 
            // w_snow
            // 
            this.w_snow.HeaderText = "최대비행 적설량 [mm]";
            this.w_snow.Name = "w_snow";
            this.w_snow.Width = 110;
            // 
            // w_sight
            // 
            this.w_sight.HeaderText = "최소비행 시계 [m]";
            this.w_sight.Name = "w_sight";
            this.w_sight.Width = 90;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(541, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // subzeroCheckBox
            // 
            this.subzeroCheckBox.AutoSize = true;
            this.subzeroCheckBox.Location = new System.Drawing.Point(12, 75);
            this.subzeroCheckBox.Name = "subzeroCheckBox";
            this.subzeroCheckBox.Size = new System.Drawing.Size(100, 16);
            this.subzeroCheckBox.TabIndex = 3;
            this.subzeroCheckBox.Text = "영하 비행가능";
            this.subzeroCheckBox.UseVisualStyleBackColor = true;
            this.subzeroCheckBox.CheckedChanged += new System.EventHandler(this.subzeroCheckBox_CheckedChanged);
            // 
            // rainCheckBox
            // 
            this.rainCheckBox.AutoSize = true;
            this.rainCheckBox.Location = new System.Drawing.Point(118, 75);
            this.rainCheckBox.Name = "rainCheckBox";
            this.rainCheckBox.Size = new System.Drawing.Size(100, 16);
            this.rainCheckBox.TabIndex = 4;
            this.rainCheckBox.Text = "강수 비행가능";
            this.rainCheckBox.UseVisualStyleBackColor = true;
            this.rainCheckBox.CheckedChanged += new System.EventHandler(this.rainCheckBox_CheckedChanged);
            // 
            // lightCheckBox
            // 
            this.lightCheckBox.AutoSize = true;
            this.lightCheckBox.Location = new System.Drawing.Point(224, 75);
            this.lightCheckBox.Name = "lightCheckBox";
            this.lightCheckBox.Size = new System.Drawing.Size(100, 16);
            this.lightCheckBox.TabIndex = 5;
            this.lightCheckBox.Text = "뇌우 비행가능";
            this.lightCheckBox.UseVisualStyleBackColor = true;
            this.lightCheckBox.CheckedChanged += new System.EventHandler(this.lightCheckBox_CheckedChanged);
            // 
            // snowCheckBox
            // 
            this.snowCheckBox.AutoSize = true;
            this.snowCheckBox.Location = new System.Drawing.Point(330, 75);
            this.snowCheckBox.Name = "snowCheckBox";
            this.snowCheckBox.Size = new System.Drawing.Size(88, 16);
            this.snowCheckBox.TabIndex = 6;
            this.snowCheckBox.Text = "눈 비행가능";
            this.snowCheckBox.UseVisualStyleBackColor = true;
            this.snowCheckBox.CheckedChanged += new System.EventHandler(this.snowCheckBox_CheckedChanged);
            // 
            // sightCheckBox
            // 
            this.sightCheckBox.AutoSize = true;
            this.sightCheckBox.Location = new System.Drawing.Point(424, 75);
            this.sightCheckBox.Name = "sightCheckBox";
            this.sightCheckBox.Size = new System.Drawing.Size(100, 16);
            this.sightCheckBox.TabIndex = 7;
            this.sightCheckBox.Text = "안개 비행가능";
            this.sightCheckBox.UseVisualStyleBackColor = true;
            this.sightCheckBox.CheckedChanged += new System.EventHandler(this.sightCheckBox_CheckedChanged);
            // 
            // maxSpeedTextBox
            // 
            this.maxSpeedTextBox.Location = new System.Drawing.Point(516, 126);
            this.maxSpeedTextBox.Name = "maxSpeedTextBox";
            this.maxSpeedTextBox.Size = new System.Drawing.Size(100, 21);
            this.maxSpeedTextBox.TabIndex = 8;
            // 
            // maxDistanceTextBox
            // 
            this.maxDistanceTextBox.Location = new System.Drawing.Point(516, 99);
            this.maxDistanceTextBox.Name = "maxDistanceTextBox";
            this.maxDistanceTextBox.Size = new System.Drawing.Size(100, 21);
            this.maxDistanceTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "최대 비행 거리 [km]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "최대 비행 속도 [km/h]";
            // 
            // DroneProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 188);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxDistanceTextBox);
            this.Controls.Add(this.maxSpeedTextBox);
            this.Controls.Add(this.sightCheckBox);
            this.Controls.Add(this.snowCheckBox);
            this.Controls.Add(this.lightCheckBox);
            this.Controls.Add(this.rainCheckBox);
            this.Controls.Add(this.subzeroCheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DroneProperty";
            this.Text = "DroneProperty";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox subzeroCheckBox;
        private System.Windows.Forms.CheckBox rainCheckBox;
        private System.Windows.Forms.CheckBox lightCheckBox;
        private System.Windows.Forms.CheckBox snowCheckBox;
        private System.Windows.Forms.CheckBox sightCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_temp_low;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_temp_high;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_rain;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_winds;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_snow;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_sight;
        private System.Windows.Forms.TextBox maxSpeedTextBox;
        private System.Windows.Forms.TextBox maxDistanceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}