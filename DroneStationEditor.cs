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
    public partial class droneStationEditor : Form
    {

        simulator frm1;
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        int rowSelection = 0;
        double latInitial = 37.459237;
        double lngInitial = 126.952115;

        public droneStationEditor(simulator _form)
        {
            InitializeComponent();
            frm1 = _form;
        }

        public droneStationEditor()
        {
            InitializeComponent();
        }

        private void PopulateDataGridView()
        {
            string[] row1 = { "301 building", "37.448673", "126.952511",  "3" };
            string[] row2 = { "Posco Sports Center", "37.467439", "126.952305", "5" };
            stationName.DataGridView.Rows.Add(row1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void droneStationEditor_Load(object sender, EventArgs e)
        {
            latitudeInput.Text = latInitial.ToString();
            longitudeInput.Text = lngInitial.ToString();

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
            gMapControl1.Position = marker.Position;
            PopulateDataGridView();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void addDroneStation_Click(object sender, EventArgs e)
        { 
        }

        private void selectLocation(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowSelection = e.RowIndex;
            stationNameInput.Text = stationTable.Rows[rowSelection].Cells[0].Value.ToString();
            latitudeInput.Text = stationTable.Rows[rowSelection].Cells[1].Value.ToString();
            longitudeInput.Text = stationTable.Rows[rowSelection].Cells[2].Value.ToString();

            marker.Position = new PointLatLng(Convert.ToDouble(latitudeInput.Text), Convert.ToDouble(longitudeInput.Text));
        }
    }
}
