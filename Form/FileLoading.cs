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
    
    public partial class FileLoading : Form
    {
        SimulatorUI formUI;
        private Simulator simulator = SimulatorUI.simulator;
        public FileLoading()
        {
            InitializeComponent();
        }



        public FileLoading(SimulatorUI _frm)
        {
            InitializeComponent();
            formUI = _frm;
        }

        private void droneLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files | *.csv";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                droneCSVTextbox.Text = path;

                string msg = simulator.getDronesFromCSV(path);
                if (msg != null)
                {
                    MessageBox.Show(msg);
                    droneCSVTextbox.Text = "";
                    return;
                }
            }
        }

        private void stationLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files | *.csv";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                stationCSVTextbox.Text = path;

                string msg = simulator.getStationsFromCSV(path);
                if (msg != null)
                {
                    MessageBox.Show(msg);
                    stationCSVTextbox.Text = "";
                    return;
                }
                droneLoadButton.Enabled = true;
            }
        }

        private void eventLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "CSV files | *.csv";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                eventCSVTextbox.Text = path;
                string msg = simulator.getEventsFromCSV(path);
                if (msg != null)
                {
                    MessageBox.Show(msg);
                    eventCSVTextbox.Text = "";
                    return;
                }

                
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            try
            {
                if (eventCSVTextbox.TextLength == 0) throw new Exception("No event CSV files uploaded");
                if (stationCSVTextbox.TextLength == 0) throw new Exception("No station CSV files uploaded");

                formUI.eventOverlay.Markers.Clear();
                formUI.eventDataGridView.Rows.Clear();

                List<Event> eventList = simulator.getEventList();

                foreach (Event eventElement in eventList)
                {
                    double latitude = eventElement.getCoordinates().Item1;
                    double longitude = eventElement.getCoordinates().Item2;
                    string address = eventElement.getAddress().ToString();
                    string occuredTime = eventElement.getOccuredDate().ToString();
                    string ambulanceTime = eventElement.getAmbulDate().ToString();

                    formUI.eventDataGridView.Rows.Add(address, occuredTime, ambulanceTime, latitude, longitude);

                    GMarkerGoogle eventMarker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red_small);
                    formUI.eventOverlay.Markers.Add(eventMarker);
                }
                formUI.eventMap.Overlays.Add(formUI.eventOverlay);

                formUI.eventDataGridView.ClearSelection();
                formUI.eventMap.Zoom = 9;
                formUI.eventMap.SetPositionByKeywords("Seoul, Korea");


                formUI.stationOverlay.Markers.Clear();
                formUI.stationOverlay.Polygons.Clear();
                formUI.updateStationDict();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    
}
