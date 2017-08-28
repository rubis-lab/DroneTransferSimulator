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
    public partial class SimulatorUI : Form
    {
        static public Simulator simulator = Simulator.getInstance();
        
        GMapOverlay eventOverlay = new GMapOverlay("Event");
        GMapOverlay stationOverlay = new GMapOverlay("Station");

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public SimulatorUI()
        {
            AllocConsole();
            InitializeComponent();
        }
        
        private void SimulatorUI_Load(object sender, EventArgs e)
        {
        }

        private void eventMap_Load(object sender, EventArgs e)
        {
            eventMap.DisableFocusOnMouseEnter = true;
            eventMap.DragButton = MouseButtons.Left;
            eventMap.CanDragMap = true;
            eventMap.MapProvider = GMapProviders.GoogleMap;
            eventMap.MinZoom = 8;
            eventMap.MaxZoom = 20;
            eventMap.Zoom = 9;
            eventMap.AutoScroll = true;

            eventOverlay = new GMapOverlay("Marker");
            eventMap.SetPositionByKeywords("Seoul, Korea");

            eventMap.Overlays.Add(eventOverlay);
        }

        private void stationMap_Load(object sender, EventArgs e)
        {
            stationMap.DisableFocusOnMouseEnter = true;
            stationMap.DragButton = MouseButtons.Left;
            stationMap.CanDragMap = true;
            stationMap.MapProvider = GMapProviders.GoogleMap;
            stationMap.SetPositionByKeywords("Seoul, Korea");
            stationMap.MinZoom = 8;
            stationMap.MaxZoom = 20;
            stationMap.Zoom = 9;
            stationMap.AutoScroll = true;
        }

        private void eventLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "CSV files | *.csv";
            dialog.Multiselect = false;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                eventOverlay.Markers.Clear();
                eventDataGridView.Rows.Clear();
                
                String path = dialog.FileName;
                eventCSVTextbox.Text = path;

                string msg = simulator.getEventsFromCSV(path);
                if(msg != null)
                {
                    MessageBox.Show(msg);
                    return;
                }

                List<Event> eventList = new List<Event>();
                simulator.getEventList(ref eventList);

                foreach(Event eventElement in eventList)
                {
                    double latitude = eventElement.getCoordinates().Item1;
                    double longitude = eventElement.getCoordinates().Item2;
                    string occuredTime = eventElement.getOccuredDate().ToString();
                    string ambulanceTime = eventElement.getAmbulDate().ToString();
                    eventDataGridView.Rows.Add(latitude, longitude, occuredTime, ambulanceTime);

                    GMarkerGoogle eventMarker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red_small);
                    eventOverlay.Markers.Add(eventMarker);
                }
                eventMap.Overlays.Add(eventOverlay);

                eventDataGridView.ClearSelection();
                eventMap.Zoom = 9;
                eventMap.SetPositionByKeywords("Seoul, Korea");
            }
        }

        private void stationLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "CSV files | *.csv";
            dialog.Multiselect = false;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                stationOverlay.Markers.Clear();
                stationOverlay.Polygons.Clear();

                String path = dialog.FileName;
                stationCSVTextbox.Text = path;

                string msg = simulator.getStationsFromCSV(path);
                if(msg != null)
                {
                    MessageBox.Show(msg);
                    return;
                }

                List<DroneStation> stationList = new List<DroneStation>();
                simulator.getStationList(ref stationList);
                foreach(DroneStation stationElement in stationList)
                {
                    string name = stationElement.name;
                    double latitude = stationElement.stationLat;
                    double longitude = stationElement.stationLng;
                    double coverRange = stationElement.coverRange;
                    drawStationPoint(stationElement);
                }
                stationMap.Zoom = 9;
                stationMap.SetPositionByKeywords("Seoul, Korea");
            }
        }

        private void drawStationPoint(DroneStation droneStation)
        {
            string name = droneStation.name;
            double lat = droneStation.stationLat;
            double lng = droneStation.stationLng;
            double coverRange = droneStation.coverRange;

            List<PointLatLng> points = new List<PointLatLng>();
            double seg = Math.PI * 2 / 100;

            for(int i = 0; i < 100; i++)
            {
                double theta = seg * i;
                double x = lat + Math.Cos(theta) * 0.0024697;
                double y = lng + Math.Sin(theta) * 0.0030828;

                points.Add(new PointLatLng(x, y));
            }

            GMapPolygon gpol = new GMapPolygon(points, "pol");
            gpol.Fill = new SolidBrush(Color.FromArgb(50, Color.Cyan));
            gpol.Stroke = new Pen(Color.DarkCyan, 1);
            stationOverlay.Polygons.Add(gpol);
            
            GMarkerGoogle stationMarker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue_small);
            stationMarker.ToolTipText = name;
            stationMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            stationOverlay.Markers.Add(stationMarker);

            stationMap.Overlays.Add(stationOverlay);
        }


        private void stationEditButton_Click(object sender, EventArgs e)
        {
            DroneStationEditor frm = new DroneStationEditor(this);
            frm.Show();
        }

        private void startSimButton_Click(object sender, EventArgs e)
        {
            DateTime startTimePicked = startTimePicker.Value;
            Time startTime = new Time();
            startTime.year = startTimePicked.Year;
            startTime.month = startTimePicked.Month;
            startTime.date = startTimePicked.Day;
            startTime.hour = 0;
            startTime.min = 0;

            DateTime endTimePicked = endTimePicker.Value;
            Time endTime = new Time();
            endTime.year = endTimePicked.Year;
            endTime.month = endTimePicked.Month;
            endTime.date = endTimePicked.Day;
            endTime.hour = 0;
            endTime.min = 0;

            simulator.updateEventsBtwRange(startTime, endTime);
            //s.start();

            SimulationResult frm = new SimulationResult(this);
            frm.Show();
        }
        
        private void eventDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            double latitude = (double)eventDataGridView.Rows[e.RowIndex].Cells[0].Value;
            double longitude = (double)eventDataGridView.Rows[e.RowIndex].Cells[1].Value;
            eventMap.Position = new PointLatLng(latitude, longitude);
            eventMap.Zoom = 15;
        }
    }
}
