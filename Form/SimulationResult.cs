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
        static private Simulator simulator = SimulatorUI.simulator;
        private List<Event> eventList;
        public List<double> ambulElaspedTime = new List<double>();
        SimulatorUI simulatorUIForm;
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

        private void eventTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            eventDetailTable.Rows.Clear();
            initGMapControl();
            if(ind < 0 || ind >= eventTable.RowCount - 1) return;
            if(eventList[ind].getResult()!= Event.eventResult.SUCCESS) return;

            string msg = "";
            for(int i = 0; i < 6; i++)
                msg += eventTable.Rows[ind].Cells[i].Value.ToString() + " / ";

            double lat = eventList[ind].getCoordinates().Item1;
            double lng = eventList[ind].getCoordinates().Item2;

            DateTime occuredTime = eventList[ind].getOccuredDate();
            DateTime droneTime = eventList[ind].getDroneDate();
            DateTime ambulTime = eventList[ind].getAmbulDate();

            double droneSec = Math.Round((droneTime - occuredTime).TotalSeconds);
            double ambulSec = (ambulTime - occuredTime).TotalSeconds;
            
            string droneGap = "" + (int)(droneSec / 60) + "' " + (droneSec % 60) + "\"";
            string ambulGap = "" + (int)(ambulSec / 60) + "' " + (ambulSec % 60) + "\"";

            DroneStation station = eventList[ind].getStation();

            eventDetailTable.Rows.Clear();
            eventDetailTable.Rows.Add(station.name, station.stationLat, station.stationLng, droneGap, ambulGap);
            stationOverlay.Markers.Clear();
            eventMap.Overlays.Clear();

            drawEventPoint(lat, lng);
            drawStationPoint(station);
        }

        private void drawEventPoint(double lat, double lng)
        {
            GMarkerGoogle eventMarker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_small);
            stationOverlay.Markers.Add(eventMarker);
            eventMap.Overlays.Add(stationOverlay);

        }

        private void drawStationPoint(DroneStation droneStation)
        {
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

        private void updateDataGridView()
        {
            eventTable.Rows.Clear();
            eventList = simulator.getEventList();

            for(int i = 0; i < eventList.Count; i++)
            {
                Event e = eventList[i];
                string address = e.getAddress().ToString();
                double latitude = e.getCoordinates().Item1;
                double longitude = e.getCoordinates().Item2;
                string occuredTime = e.getOccuredDate().ToString();
                string droneArrivalTime = "N/A";
                string result = "Failure";
                string note = " ";
                if (e.getResult() == Event.eventResult.SUCCESS)
                {
                    result = e.getStation().name;
                    droneArrivalTime = e.getDroneDate().ToString();
                }
                // temp, rain, wind, snow, sight, light
                else if (e.getReason() == Event.failReason.NO_DRONE) note = "No Available Drones";
                else if (e.getReason() == Event.failReason.COVERAGE_PROBLEM) note = "Coverage Problem";
                else if (e.getReason() == Event.failReason.WEAHTER)
                {
                    if (e.getWthFailRsn(0) == true) note += " 온도";
                    if (e.getWthFailRsn(1) == true) note += " 비";
                    if (e.getWthFailRsn(2) == true) note += " 바람";
                    if (e.getWthFailRsn(3) == true) note += " 눈";
                    if (e.getWthFailRsn(4) == true) note += " 시계";
                    if (e.getWthFailRsn(5) == true) note += " 뇌우";
                }

                eventTable.Rows.Add(i, address, occuredTime, droneArrivalTime, result, latitude, longitude, note);

                double droneSec = Math.Round((e.getDroneDate() - e.getOccuredDate()).TotalSeconds);

                if(e.getResult() != Event.eventResult.SUCCESS) eventTable.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                else if(droneSec < simulator.getGoldenTime().Item1) eventTable.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                else if(droneSec < simulator.getGoldenTime().Item2) eventTable.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
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

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            Analysis frm = new Analysis(this);
            frm.Show();
        }
    }
}
