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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.p_subzero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_rain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_light = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_snow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_sight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.dataGridView1.Size = new System.Drawing.Size(640, 62);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // w_temp_low
            // 
            this.w_temp_low.HeaderText = "최소비행 온도 [°C]";
            this.w_temp_low.Name = "w_temp_low";
            // 
            // w_temp_high
            // 
            this.w_temp_high.HeaderText = "최대비행 온도 [°C]";
            this.w_temp_high.Name = "w_temp_high";
            // 
            // w_rain
            // 
            this.w_rain.HeaderText = "최대비행 강수량 [mm]";
            this.w_rain.Name = "w_rain";
            // 
            // w_winds
            // 
            this.w_winds.HeaderText = "최대비행 풍속 [m/s]";
            this.w_winds.Name = "w_winds";
            // 
            // w_snow
            // 
            this.w_snow.HeaderText = "최대비행 적설량 [mm]";
            this.w_snow.Name = "w_snow";
            // 
            // w_sight
            // 
            this.w_sight.HeaderText = "최소비행 시계 [m]";
            this.w_sight.Name = "w_sight";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_subzero,
            this.p_rain,
            this.p_light,
            this.p_snow,
            this.p_sight});
            this.dataGridView2.Location = new System.Drawing.Point(12, 80);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(640, 67);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEndEdit);
            // 
            // p_subzero
            // 
            this.p_subzero.HeaderText = "영하 비행가능 여부";
            this.p_subzero.Name = "p_subzero";
            // 
            // p_rain
            // 
            this.p_rain.HeaderText = "강수 비행가능 여부";
            this.p_rain.Name = "p_rain";
            // 
            // p_light
            // 
            this.p_light.HeaderText = "뇌우 비행가능 여부";
            this.p_light.Name = "p_light";
            // 
            // p_snow
            // 
            this.p_snow.HeaderText = "눈 비행가능 여부";
            this.p_snow.Name = "p_snow";
            // 
            // p_sight
            // 
            this.p_sight.HeaderText = "안개 비행가능 여부";
            this.p_sight.Name = "p_sight";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(577, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DroneProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DroneProperty";
            this.Text = "DroneProperty";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_temp_low;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_temp_high;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_rain;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_winds;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_snow;
        private System.Windows.Forms.DataGridViewTextBoxColumn w_sight;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_subzero;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_rain;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_light;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_snow;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_sight;
        private System.Windows.Forms.Button button1;
    }
}