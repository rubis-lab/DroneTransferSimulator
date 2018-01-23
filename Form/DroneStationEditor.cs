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
        static Simulator simulator = Simulator.getInstance();
        static Dictionary<string, DroneStation> stationDict = simulator.getStationDict();

        SimulatorUI simulatorUIForm;
        GMapOverlay markerOverlay = new GMapOverlay("Marker");
        GMapOverlay stationOverlay = new GMapOverlay("Station");

        public DroneStationEditor(SimulatorUI _form)
        {
            InitializeComponent();
            simulatorUIForm = _form;
            
            if(simulatorUIForm.fileLoadingForm.stationCSVTextbox.TextLength == 0) this.Text = "Drone Station Editor";
            else this.Text = simulatorUIForm.fileLoadingForm.stationCSVTextbox.Text;
            
        }

        private void PopulateDataGridView()
        {
            try
            {
                foreach(KeyValuePair<string, DroneStation> dict in stationDict)
                {
                    DroneStation stationElement = dict.Value;
                    string name = stationElement.name;
                    double latitude = stationElement.stationLat;
                    double longitude = stationElement.stationLng;
                    double coverRange = stationElement.coverRange;
                    stationName.DataGridView.Rows.Add(name, latitude, longitude, coverRange);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void droneStationEditor_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private int getStationRow(string name)
        {
            for(int i = 0; i < stationTable.RowCount; i++)
            {
                if(stationTable.Rows[i].Cells[0].Value.ToString() == name)
                {
                    return i;
                }
            }
            return -1;
        }

        private void drawStations()
        {
            markerOverlay.Markers.Clear();
            stationMap.Overlays.Clear();

            foreach(KeyValuePair<string, DroneStation> dict in stationDict)
            {
                PointLatLng p = new PointLatLng(dict.Value.stationLat, dict.Value.stationLng);
                GMarkerGoogle marker = new GMarkerGoogle(p, GMarkerGoogleType.blue_small);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = dict.Value.name;

                markerOverlay.Markers.Add(marker);
            }
            stationMap.Overlays.Add(markerOverlay);
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

            drawStations();
        }

        private void stationTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            drawSelectedStation(e.RowIndex);
        }

        private void stationNameInput_TextChanged(object sender, EventArgs e)
        {
            int stationRow = getStationRow(stationNameInput.Text);
            if(stationRow != -1)
            {
                selectStation(stationRow);
                drawSelectedStation(stationRow);
            }
        }

        private void stationTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            string nameText = stationTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            string latText = stationTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            string lngText = stationTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            string coverText = stationTable.Rows[e.RowIndex].Cells[3].Value.ToString();

            stationNameInput.Text = nameText;
            latitudeInput.Text = latText;
            longitudeInput.Text = lngText;
            coverageInput.Text = coverText;
        }
        
        private void drawCircle(PointLatLng p, double coverRange)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            double pNum = 30;
            double seg = Math.PI * 2 / pNum;

            stationMap.Overlays.Clear();
            stationOverlay.Polygons.Clear();

            for(int i = 0; i < pNum; i++)
            {
                double theta = seg * i;
                double y = p.Lat + Math.Cos(theta) / 0.030828 / 60 / 60 * coverRange;
                double x = p.Lng + Math.Sin(theta) / 0.024697 / 60 / 60 * coverRange;

                points.Add(new PointLatLng(y, x));
            }

            GMapPolygon gpol = new GMapPolygon(points, "pol");
            gpol.Fill = new SolidBrush(Color.FromArgb(40, Color.Cyan));
            gpol.Stroke = new Pen(Color.DarkCyan, (float)0.5);
            stationOverlay.Polygons.Add(gpol);

            stationMap.Overlays.Add(stationOverlay);
            stationMap.Overlays.Add(markerOverlay);
        }

        private void drawSelectedStation(int selected)
        {
            if(stationTable.RowCount == 0) return;
            string nameText = stationTable.Rows[selected].Cells[0].Value.ToString();
            string latText = stationTable.Rows[selected].Cells[1].Value.ToString();
            string lngText = stationTable.Rows[selected].Cells[2].Value.ToString();
            string coverText = stationTable.Rows[selected].Cells[3].Value.ToString();

            PointLatLng p = new PointLatLng(Convert.ToDouble(latText), Convert.ToDouble(lngText));
            drawCircle(p, Convert.ToDouble(coverText));

            stationMap.Position = p;
            stationMap.Zoom = 11;
        }

        private void selectStation(int selected)
        {
            if(stationTable.RowCount == 0) return;
            stationTable.ClearSelection();
            stationTable.Rows[selected].Selected = true;
            if(!stationTable.Rows[selected].Displayed)
            {
                stationTable.FirstDisplayedScrollingRowIndex = selected;
            }
        }

        private void stationMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            int stationRow = getStationRow(item.ToolTipText);
            if(stationRow != -1)
            {
                selectStation(stationRow);
                drawSelectedStation(stationRow);
            }
        }

        private void addDroneStation_Click(object sender, EventArgs e)
        {
            try
            {
                if(stationNameInput.TextLength == 0) throw new Exception("This input should not be empty");
                string name = stationNameInput.Text;

                if(latitudeInput.TextLength == 0) throw new Exception("This input should not be empty");
                double latitude = Convert.ToDouble(latitudeInput.Text);

                if(longitudeInput.TextLength == 0) throw new Exception("This input should not be empty");
                double longitude = Convert.ToDouble(longitudeInput.Text);

                if(coverageInput.TextLength == 0) throw new Exception("This input should not be empty");
                double coverRange = Convert.ToDouble(coverageInput.Text);

                int stationRow = getStationRow(name);
                if(stationRow == -1)
                {
                    stationName.DataGridView.Rows.Add(name, latitude, longitude, coverRange);
                    selectStation(stationTable.RowCount - 1);
                }
                else
                {
                    stationTable.Rows[stationRow].Cells[1].Value = latitude;
                    stationTable.Rows[stationRow].Cells[2].Value = longitude;
                    stationTable.Rows[stationRow].Cells[3].Value = coverRange;
                    selectStation(stationRow);
                }
                clearTextBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteDroneStation_Click(object sender, EventArgs e)
        {
            try
            {
                if(stationTable.SelectedRows.Count == 0) throw new Exception("No stations selected");
                foreach(DataGridViewRow item in stationTable.SelectedRows)
                {
                    stationTable.Rows.RemoveAt(item.Index);
                }
                
                clearTextBox();
                selectStation(0);
                drawSelectedStation(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            stationTable.Rows.Clear();
            PopulateDataGridView();
            drawStations();
            clearTextBox();
            selectStation(0);
            drawSelectedStation(0);
        }

        private void clearTextBox()
        {
            stationNameInput.Clear();
            latitudeInput.Clear();
            longitudeInput.Clear();
            coverageInput.Clear();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            stationDict.Clear();
            for(int i = 0; i < stationTable.RowCount; i++)
            {
                string name = (string)stationTable.Rows[i].Cells[0].Value;
                double latitude = (double)stationTable.Rows[i].Cells[1].Value;
                double longitude = (double)stationTable.Rows[i].Cells[2].Value;
                double coverRange = (double)stationTable.Rows[i].Cells[3].Value;
                Address addr = new Address(latitude, longitude);

                stationDict.Add(name, new DroneStation(name, latitude, longitude, coverRange, addr));
            }
            
            stationTable.Rows.Clear();
            PopulateDataGridView();
            drawStations();
            clearTextBox();
            selectStation(0);
            drawSelectedStation(0);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            // dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "CSV files | *.csv";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                System.IO.StreamWriter csvFileWriter = new System.IO.StreamWriter(path, false);
                
                foreach(DataGridViewRow row in stationTable.Rows)
                {
                    string csvData = row.Cells[0].Value.ToString();
                    for(int i = 1; i < 4; i++) csvData += "," + row.Cells[i].Value.ToString();
                    csvFileWriter.WriteLine(csvData); 
                }
                csvFileWriter.Flush();
                csvFileWriter.Close();
                this.Close();
                
                simulatorUIForm.fileLoadingForm.stationCSVTextbox.Text = path;
                simulatorUIForm.updateStationDict();
            }
        }
    }
}
