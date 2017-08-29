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
    public partial class DroneStationEditor : Form
    {
        SimulatorUI simulatorUIForm;
        GMapOverlay markerOverlay = new GMapOverlay("Marker");

        int rowSelection = 0;

        public DroneStationEditor(SimulatorUI _form)
        {
            InitializeComponent();
            simulatorUIForm = _form;
        }

        public DroneStationEditor()
        {
            InitializeComponent();
        }

        private void PopulateDataGridView()
        {
            try
            {
                if(simulatorUIForm.stationDict == null) throw new Exception("No station lists uploaded\nCreate new or upload");
                foreach(KeyValuePair<string, DroneStation> dict in simulatorUIForm.stationDict)
                {
                    DroneStation stationElement = dict.Value;
                    string name = stationElement.name;
                    double latitude = stationElement.stationLat;
                    double longitude = stationElement.stationLng;
                    double coverRange = stationElement.coverRange;
                    stationName.DataGridView.Rows.Add(name, latitude, longitude, coverRange);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            stationName.DataGridView.ClearSelection();
        }

        private void droneStationEditor_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void addDroneStation_Click(object sender, EventArgs e)
        { 
        }

        private void stationMap_Load(object sender, EventArgs e)
        {
            stationMap.DragButton = MouseButtons.Left;
            stationMap.CanDragMap = true;
            stationMap.MapProvider = GMapProviders.GoogleMap;
            stationMap.SetPositionByKeywords("Seoul, Korea");
            stationMap.MinZoom = 8;
            stationMap.MaxZoom = 20;
            stationMap.Zoom = 9;
            stationMap.AutoScroll = true;
        }

        private void stationTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            rowSelection = e.RowIndex;
            stationNameInput.Text = stationTable.Rows[rowSelection].Cells[0].Value.ToString();
            latitudeInput.Text = stationTable.Rows[rowSelection].Cells[1].Value.ToString();
            longitudeInput.Text = stationTable.Rows[rowSelection].Cells[2].Value.ToString();
            coverageInput.Text = stationTable.Rows[rowSelection].Cells[3].Value.ToString();

            markerOverlay.Markers.Clear();
            stationMap.Overlays.Clear();

            PointLatLng p = new PointLatLng(Convert.ToDouble(latitudeInput.Text), Convert.ToDouble(longitudeInput.Text));
            GMarkerGoogle marker = new GMarkerGoogle(p, GMarkerGoogleType.blue_small);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            markerOverlay.Markers.Add(marker);

            stationMap.Overlays.Add(markerOverlay);
            stationMap.Position = marker.Position;
        }
    }
}
