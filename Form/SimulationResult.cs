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
        List<Event> eventList;
        SimulatorUI simulatorUIForm;
        GMapOverlay markerOverlay = new GMapOverlay("Marker");
        GMapOverlay stationOverlay = new GMapOverlay("Station");

        public SimulationResult(SimulatorUI _form)
        {
            InitializeComponent();
            simulatorUIForm = _form;
        }

        private void SimulationResult_Load(object sender, EventArgs e)
        {
            initGMapControl();
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
            eventMap.Overlays.Clear();
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

        private void eventTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            eventDetailTable.Rows.Clear();
            initGMapControl();
            if(ind < 0 || ind >= eventTable.RowCount - 1) return;
            if(eventList[ind].getResult() == "failure") return;

            string msg = "";
            for(int i = 0; i < 6; i++)
                msg += eventTable.Rows[ind].Cells[i].Value.ToString() + " / ";
            Console.WriteLine(msg);

            double lat = eventList[ind].getCoordinates().Item1;
            double lng = eventList[ind].getCoordinates().Item2;
            Time occuredTime = eventList[ind].getOccuredDate();
            Time droneTime = eventList[ind].getDroneDate();
            Time ambulTime = eventList[ind].getAmbulDate();

            int droneSec = Time.getTimeGap(droneTime, occuredTime);
            int ambulSec = Time.getTimeGap(ambulTime, occuredTime);
            string droneGap = "" + (droneSec / 60) + "' " + (droneSec % 60) + "\"";
            string ambulGap = "" + (ambulSec / 60) + "' " + (ambulSec % 60) + "\"";

            DroneStation station = eventList[ind].getStation();

            eventDetailTable.Rows.Clear();
            eventDetailTable.Rows.Add(station.name, droneGap, ambulGap);

            eventMap.Overlays.Clear();

       //     drawEventPoint(lat, lng);
            drawStationPoint(station);
            
        //    gMapControl1.Position = marker.Position;
        }

        private void drawCircle(PointLatLng p, double coverRange)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            double pNum = 30;
            double seg = Math.PI * 2 / pNum;

            stationOverlay.Polygons.Clear();
            eventMap.Overlays.Clear();

            for(int i = 0; i < pNum; i++)
            {
                double theta = seg * i;
                double y = p.Lat + Math.Cos(theta) / 0.030828 / 60 / 60 * coverRange;
                double x = p.Lng + Math.Sin(theta) / 0.024697 / 60 / 60 * coverRange;

                points.Add(new PointLatLng(y, x));
            }

            GMapPolygon gpol = new GMapPolygon(points, "pol");
            gpol.Fill = new SolidBrush(Color.FromArgb(20, Color.Cyan));
            gpol.Stroke = new Pen(Color.DarkCyan, (float)0.5);
            stationOverlay.Polygons.Add(gpol);
        }

        private void drawStationPoint(DroneStation droneStation)
        {
            stationOverlay.Markers.Clear();
            string name = droneStation.name;
            double lat = droneStation.stationLat;
            double lng = droneStation.stationLng;
            double coverRange = droneStation.coverRange;

            PointLatLng p = new PointLatLng(lat, lng);
            drawCircle(p, coverRange);

            GMarkerGoogle stationMarker = new GMarkerGoogle(p, GMarkerGoogleType.blue_small);
            stationMarker.ToolTipText = name;
            stationMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            stationOverlay.Markers.Add(stationMarker);

            eventMap.Overlays.Add(stationOverlay);

            eventMap.Position = p;
            eventMap.Zoom = 12;
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            PointLatLng p = eventMap.FromLocalToLatLng(e.X, e.Y);
            Console.WriteLine(p.Lat + ", " + p.Lng);
        }

        private void updateDataGridView()
        {
            eventTable.Rows.Clear();
            eventList = simulator.getEventList();
            for(int i = 0; i < eventList.Count; i++)
            {
                Event e = eventList[i];
                double latitude = e.getCoordinates().Item1;
                double longitude = e.getCoordinates().Item2;
                string occuredTime = e.getOccuredDate().ToString();
                string droneArrivalTime = e.getDroneDate().ToString();
                string result = e.getResult();
                eventTable.Rows.Add(i, latitude, longitude, occuredTime, droneArrivalTime, result);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(eventMap.Zoom);
            if(simulator.isDone)
            {
                updateDataGridView();
                simulator.isDone = false;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            eventMap.Zoom = trackBar1.Value;
        }
    }
}
