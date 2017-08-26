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
        static public Simulator s = new Simulator();

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        int rowSelection = 0;
        double latInitial = 37.459237;
        double lngInitial = 126.952115;

        public SimulatorUI()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SimulatorUI_Load(object sender, EventArgs e)
        {
            
            eventMap.DragButton = MouseButtons.Left;
            eventMap.CanDragMap = true;
            eventMap.MapProvider = GMapProviders.GoogleMap;
            eventMap.MinZoom = 10;
            eventMap.MaxZoom = 20;
            eventMap.Zoom = 10;
            eventMap.AutoScroll = true;

            markerOverlay = new GMapOverlay("Maker");
            eventMap.SetPositionByKeywords("Seoul, Korea");

            marker = new GMarkerGoogle(new PointLatLng(latInitial, lngInitial),GMarkerGoogleType.red_dot);
            markerOverlay.Markers.Add(marker); //add to map

            marker.ToolTipMode = MarkerTooltipMode.Always;
            
            eventMap.Overlays.Add(markerOverlay);


            stationMap.DragButton = MouseButtons.Left;
            stationMap.CanDragMap = true;
            stationMap.MapProvider = GMapProviders.GoogleMap;
            stationMap.SetPositionByKeywords("Seoul, Korea");
            stationMap.MinZoom = 10;
            stationMap.MaxZoom = 20;
            stationMap.Zoom = 10;
            stationMap.AutoScroll = true;

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void addDroneStation_Click(object sender, EventArgs e)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadEventCsv frm = new LoadEventCsv(this);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadStationCsv frm = new LoadStationCsv(this);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            droneStationEditor frm = new droneStationEditor(this);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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

            s.updateEventsBtwRange(startTime, endTime);
            //s.start();

            SimulationResult frm = new SimulationResult(this);
            frm.Show();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void eventList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelection = e.RowIndex;
            string lat = eventList.Rows[rowSelection].Cells[0].Value.ToString();
            marker.Position = new PointLatLng(Convert.ToDouble(eventList.Rows[rowSelection].Cells[0].Value), Convert.ToDouble(eventList.Rows[rowSelection].Cells[1].Value));
            eventMap.Position = marker.Position;
            eventMap.Zoom = 15;
        }
    }
}
