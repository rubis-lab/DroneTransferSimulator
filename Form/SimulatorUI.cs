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
        
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        public SimulatorUI()
        {
            InitializeComponent();
        }
        
        private void SimulatorUI_Load(object sender, EventArgs e)
        {
        }

        private void eventMap_Load(object sender, EventArgs e)
        {
            double latInitial = 37.459237;
            double lngInitial = 126.952115;

            eventMap.DisableFocusOnMouseEnter = true;
            eventMap.DragButton = MouseButtons.Left;
            eventMap.CanDragMap = true;
            eventMap.MapProvider = GMapProviders.GoogleMap;
            eventMap.MinZoom = 10;
            eventMap.MaxZoom = 20;
            eventMap.Zoom = 10;
            eventMap.AutoScroll = true;

            markerOverlay = new GMapOverlay("Maker");
            eventMap.SetPositionByKeywords("Seoul, Korea");

            marker = new GMarkerGoogle(new PointLatLng(latInitial, lngInitial), GMarkerGoogleType.red_dot);
            markerOverlay.Markers.Add(marker); //add to map

            marker.ToolTipMode = MarkerTooltipMode.Always;

            eventMap.Overlays.Add(markerOverlay);

        }

        private void stationMap_Load(object sender, EventArgs e)
        {
            stationMap.DisableFocusOnMouseEnter = true;
            stationMap.DragButton = MouseButtons.Left;
            stationMap.CanDragMap = true;
            stationMap.MapProvider = GMapProviders.GoogleMap;
            stationMap.SetPositionByKeywords("Seoul, Korea");
            stationMap.MinZoom = 10;
            stationMap.MaxZoom = 20;
            stationMap.Zoom = 10;
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
                String path = dialog.FileName;
                eventCSVTextbox.Text = path;

                simulator.getEventsFromCSV(path);

                List<Event> eventList = new List<Event>();

                simulator.getEventList(ref eventList);

                foreach(Event eventElements in eventList)
                {
                    double latitude = eventElements.getCoordinates().Item1;
                    double longitude = eventElements.getCoordinates().Item2;
                    string occuredTime = eventElements.getOccuredDate().ToString();
                    string ambulanceTime = eventElements.getAmbulDate().ToString();
                    eventDataGridView.Rows.Add(latitude, longitude, occuredTime, ambulanceTime);
                }
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
                String path = dialog.FileName;
                stationCSVTextbox.Text = path;
            }
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
            int rowSelection;
            rowSelection = e.RowIndex;
            string lat = eventDataGridView.Rows[rowSelection].Cells[0].Value.ToString();
            marker.Position = new PointLatLng(Convert.ToDouble(eventDataGridView.Rows[rowSelection].Cells[0].Value), Convert.ToDouble(eventDataGridView.Rows[rowSelection].Cells[1].Value));
            eventMap.Position = marker.Position;
            eventMap.Zoom = 15;
        }
    }
}
