using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace DroneTransferSimulator
{
    public partial class SimulationResult : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        public SimulationResult()
        {
            AllocConsole();
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        private void SimulationResult_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.SetPositionByKeywords("Seoul, Korea");
            gMapControl1.MinZoom = 10;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 10;
            gMapControl1.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(gMapControl1.Zoom);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackBar1.Value;
        }
    }
}
