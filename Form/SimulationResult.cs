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
        static Simulator simulator = Simulator.getInstance();
        SimulatorUI simulatorUIForm;
        GMapOverlay markerOverlay;

        public SimulationResult(SimulatorUI _form)
        {
            InitializeComponent();
            simulatorUIForm = _form;
        }

        private void SimulationResult_Load(object sender, EventArgs e)
        {
            initGMapControl();
            initDataGridView();
        }

        private void initGMapControl()
        {
            eventMap.DisableFocusOnMouseEnter = true;
            eventMap.DragButton = MouseButtons.Left;
            eventMap.CanDragMap = true;
            eventMap.MapProvider = GMapProviders.GoogleMap;
            eventMap.SetPositionByKeywords("Seoul, Korea");
            eventMap.MinZoom = 10;
            eventMap.MaxZoom = 20;
            eventMap.Zoom = 10;
            eventMap.AutoScroll = true;
        }

        private void initDataGridView()
        {
            List<Event> eventList = simulator.getEventList();
            foreach(Event e in eventList)
            {
                double latitude = e.getCoordinates().Item1;
                double longitude = e.getCoordinates().Item2;
                string occuredTime = e.getOccuredDate().ToString();
                string droneArrivalTime = "2017-07-19, 15:20:03";
                string result = "success";
                eventTable.Rows.Add(eventTable.RowCount - 1, latitude, longitude, occuredTime, droneArrivalTime, result);
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
            if(ind < 0 || ind >= eventTable.RowCount - 1) return;

            string msg = "";
            for(int i = 0; i < 6; i++)
                msg += eventTable.Rows[ind].Cells[i].Value.ToString() + " / ";
            Console.WriteLine(msg);

            double lat = (double)eventTable[1, ind].Value;
            double lng = (double)eventTable[2, ind].Value;

            eventMap.Overlays.Clear();

       //     drawEventPoint(lat, lng);
       //     drawStationPoint(lat - 0.0012, lng + 0.0045);

        //    gMapControl1.Overlays.Add(markerOverlay);
        //    gMapControl1.Position = marker.Position;
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            PointLatLng p = eventMap.FromLocalToLatLng(e.X, e.Y);
            Console.WriteLine(p.Lat + ", " + p.Lng);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(eventMap.Zoom);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            eventMap.Zoom = trackBar1.Value;
        }
    }
}
