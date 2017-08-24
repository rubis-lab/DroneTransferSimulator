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
        SimulatorUI form1;
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        public SimulationResult()
        {
            AllocConsole();
            InitializeComponent();
        }

        public SimulationResult(SimulatorUI _form)
        {
            InitializeComponent();
            form1 = _form;
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        private void SimulationResult_Load(object sender, EventArgs e)
        {
            initGMapControl();
            initDataGridView();
        }

        private void initGMapControl()
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

        private void initDataGridView()
        {
            Time t = new Time();
            Event e = new Event(37.578695, 126.997512, null, null, Event.eventType.E_EVENT_OCCURED);
            for(int i = 0; i < 10; i++)
            {
                double latitude = e.getCoordinates().Item1;
                double longitude = e.getCoordinates().Item2;
                string occuredTime = "2017-07-19, 15:20:03";
                string droneArrivalTime = "2017-07-19, 15:20:03";
                string result = "success";
                dataGridView1.Rows.Add(dataGridView1.RowCount - 1, latitude, longitude, occuredTime, droneArrivalTime, result);
            }
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

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            if(ind < 0 || ind >= dataGridView1.RowCount - 1) return;

            string msg = "";
            for(int i = 0; i < 6; i++)
                msg += dataGridView1.Rows[ind].Cells[i].Value.ToString() + " / ";
            Console.WriteLine(msg);

            double lat = (double)dataGridView1[1, ind].Value;
            double lng = (double)dataGridView1[2, ind].Value;

            gMapControl1.Overlays.Clear();

       //     drawEventPoint(lat, lng);
       //     drawStationPoint(lat - 0.0012, lng + 0.0045);

        //    gMapControl1.Overlays.Add(markerOverlay);
        //    gMapControl1.Position = marker.Position;
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
