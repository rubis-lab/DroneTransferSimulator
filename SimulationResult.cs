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
            gMapControl1.Position = new PointLatLng(37.459871, 126.951878);
            gMapControl1.MinZoom = 10;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 15;
            gMapControl1.AutoScroll = true;

            for (int i = 0; i < 200; i++)
                pushDataGridRow(37.459871 + 0.001 * i, 126.951878 + 0.001 * i, "2017-08-17,14:12:00", "2017-08-17,14:14:58", "hello");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!");
        }

        private void pushDataGridRow(double latitude, double longitude, string occuredTime, string droneArrivalTime, string result)
        {
            dataGridView1.Rows.Add(dataGridView1.RowCount - 1, latitude, longitude, occuredTime, droneArrivalTime, result);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            if (ind < 0 || ind >= dataGridView1.RowCount - 1) return;

            string msg = "";
            for (int i = 0; i < 6; i++)
                msg += dataGridView1.Rows[ind].Cells[i].Value.ToString() + " / ";
            Console.WriteLine(msg);

            double lat = (double)dataGridView1[1, ind].Value;
            double lng = (double)dataGridView1[2, ind].Value;

            gMapControl1.Overlays.Clear();

            markerOverlay = new GMapOverlay("dst");
            marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_dot);
            markerOverlay.Markers.Add(marker);

            gMapControl1.Overlays.Add(markerOverlay);
            gMapControl1.Position = marker.Position;
        }
    }
}
