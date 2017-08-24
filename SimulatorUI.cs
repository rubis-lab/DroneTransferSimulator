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

        private void droneStationEditor_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(latInitial, lngInitial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 15;
            gMapControl1.AutoScroll = true;

            markerOverlay = new GMapOverlay("Maker");
            marker = new GMarkerGoogle(new PointLatLng(latInitial, lngInitial),GMarkerGoogleType.red_dot);
            markerOverlay.Markers.Add(marker); //add to map

            marker.ToolTipMode = MarkerTooltipMode.Always;
            //marker.ToolTipText = string.Format("Location:\n Latitude:{0} \n Longitude: {1}", latInitial, lngInitial);

            gMapControl1.Overlays.Add(markerOverlay);
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
            SimulationResult frm = new SimulationResult(this);
            frm.Show();
        }
    }
}
