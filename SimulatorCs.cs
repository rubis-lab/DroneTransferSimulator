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
    public partial class simulator : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        double latInitial = 37.56;
        double lngInitial = 126.98;


        public simulator()
        {
            InitializeComponent();
        }

        private void eventCsvLoadingButton_Click(object sender, EventArgs e)
        {
            LoadEventCsv frm = new LoadEventCsv(this);
            frm.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

       

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void droneStations_Click(object sender, EventArgs e)
        {

        }

        private void droneStationsEdit_Click(object sender, EventArgs e)
        {
            droneStationEditor frm = new droneStationEditor(this);
            frm.Show();
        }

        private void simulator_Load(object sender, EventArgs e)
        {
            gMapControl2.DragButton = MouseButtons.Left;
            gMapControl2.CanDragMap = true;
            gMapControl2.MapProvider = GMapProviders.GoogleMap;
            gMapControl2.Position = new PointLatLng(latInitial, lngInitial);
            gMapControl2.MinZoom = 0;
            gMapControl2.MaxZoom = 24;
            gMapControl2.Zoom = 9;
            gMapControl2.AutoScroll = true;

        }

        private void gMapControl2_Load(object sender, EventArgs e)
        {

        }

        private void droneStationCsvLoadingButton_Click(object sender, EventArgs e)
        {
            LoadStationCsv frm = new LoadStationCsv(this);
            frm.Show();
        }


        //get start time and end time
        DateTime pickedStartTime, pickedEndTime;

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            pickedStartTime = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            pickedEndTime = dateTimePicker2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //declare Time startTime, endTime
            //start simulation
        }

    }
}
