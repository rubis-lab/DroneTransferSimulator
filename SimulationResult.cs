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
            PathPlanner pathPlanner = PathPlanner.getInstance();
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();
            pathPlanner.calcTravelTime(37.578695, 126.997512, 37.578788, 126.994859);
            System.Console.WriteLine("Time elapsed : " + stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();

            stopwatch.Restart();
            pathPlanner.calcTravelTime(37.578695, 126.997512, 37.578788, 126.994859);
            System.Console.WriteLine("Time elapsed : " + stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();
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

            drawEventPoint(lat, lng);
            drawStationPoint(lat - 0.0012, lng + 0.0045);

            gMapControl1.Overlays.Add(markerOverlay);
            gMapControl1.Position = marker.Position;
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {

            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            drawEventPoint(lat, lng);
            Console.WriteLine(e.X + ", " + e.Y);
            gMapControl1.Overlays.Add(markerOverlay);
            gMapControl1.Position = marker.Position;
        }

        private void drawEventPoint(double lat, double lng)
        {
            markerOverlay = new GMapOverlay("dst");
            marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_dot);
            markerOverlay.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = string.Format("Event");
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.LightGoldenrodYellow;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(5, 5);
        }

        private void drawStationPoint(double lat, double lng)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            double seg = Math.PI * 2 / 100;

            for (int i = 0; i < 100; i++)
            {
                double theta = seg * i;
                double x = lat + Math.Cos(theta) * 0.0024697;
                double y = lng + Math.Sin(theta) * 0.0030828;

                points.Add(new PointLatLng(x, y));
            }

            GMapPolygon gpol = new GMapPolygon(points, "pol");
            gpol.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            gpol.Stroke = new Pen(Color.Red, 2);
            markerOverlay.Polygons.Add(gpol);
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
