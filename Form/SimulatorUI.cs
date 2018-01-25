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
        public FileLoading fileLoadingForm;
        static Dictionary<string, DroneStation> stationDict = simulator.getStationDict();

        public GMapOverlay eventOverlay = new GMapOverlay("Event");
        public GMapOverlay stationOverlay = new GMapOverlay("Station");

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

        public void updateStationDict()
        {
            stationOverlay.Markers.Clear();

            stationOverlay.Polygons.Clear();

            stationDict = simulator.getStationDict();

            foreach(KeyValuePair<string, DroneStation> dict in stationDict)
            {
                DroneStation stationElement = dict.Value;
                string name = stationElement.name;
                double latitude = stationElement.stationLat;
                double longitude = stationElement.stationLng;
                double coverRange = stationElement.coverRange;
                drawStationPoint(stationElement);
            }
            stationMap.Overlays.Add(stationOverlay);
            stationMap.Zoom = 9;
            stationMap.SetPositionByKeywords("Seoul, Korea");
        }
        

        private void drawCircle(PointLatLng p, double coverRange)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            double pNum = 30;
            double seg = Math.PI * 2 / pNum;

            stationOverlay.Polygons.Clear();
            stationMap.Overlays.Clear();

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

            stationMap.Overlays.Add(stationOverlay);
        }

        private void drawStationPoint(DroneStation droneStation)
        {
            string name = droneStation.name;
            double lat = droneStation.stationLat;
            double lng = droneStation.stationLng;
            double coverRange = droneStation.coverRange;

            GMarkerGoogle stationMarker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue_small);
            stationMarker.ToolTipText = name;
            stationMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            stationOverlay.Markers.Add(stationMarker);
        }

        private void stationEditButton_Click(object sender, EventArgs e)
        {
            DroneStationEditor frm = new DroneStationEditor(this);
            frm.Show();
        }

        private void startSimButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(eventDataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No CSV Loaded");
                    return;
                }
                DateTime startTimePicked = startTimePicker.Value;
                DateTime startTime = new DateTime(startTimePicked.Year, startTimePicked.Month, startTimePicked.Day, 0, 0, 0);

                DateTime endTimePicked = endTimePicker.Value;
                DateTime endTime = new DateTime(endTimePicked.Year, endTimePicked.Month, endTimePicked.Day, 0, 0, 0);

                if( DateTime.Compare(endTime, startTime) <=0 ) throw new Exception("Start should be earlier than end");
                
                simulator.setGoldenTime(Convert.ToDouble(goldenTimeText1.Text), Convert.ToDouble(goldenTimeText2.Text));
                simulator.updateEventsBtwRange(startTime, endTime);
                simulator.start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            SimulationResult frm = new SimulationResult(this);
            frm.Show();
        }
        
        private void eventDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            double latitude = (double)eventDataGridView.Rows[e.RowIndex].Cells[3].Value;
            double longitude = (double)eventDataGridView.Rows[e.RowIndex].Cells[4].Value;
            eventMap.Position = new PointLatLng(latitude, longitude);
            eventMap.Zoom = 15;
        }

        private void stationMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            stationMap.Position = item.Position;
            stationMap.Zoom = 12;

            drawCircle(item.Position, stationDict[item.ToolTipText].coverRange);
            stationMap.Overlays.Add(stationOverlay);
        }

        private void eventMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            eventMap.Position = item.Position;
            eventMap.Zoom = 15;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileLoading_Click(object sender, EventArgs e)
        {
            FileLoading frm = new FileLoading(this);
            frm.Show();
            fileLoadingForm = frm;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.radioButton1, "Advanced Model\n - 환경 요인에 상관없이 출동한다 가정\n - \"전화 도움 심폐소생술\" 을 안내 받은 경우 출동\n - Coverage 는 최대 20km\n");
        }

        private void radioButton2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.radioButton2, "Intermediate model – 1(High spec model for environment)\n - \"전화 도움 심폐소생술\" 을 안내 받은 경우 출동\n - 환경 요인 중 온도 / 우천 / 낙뢰 / 풍속 에도 출동 가능\n - Coverage 10km");
        }

        private void radioButton3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.radioButton3, "Intermediate model – 2 (GPS base control model)\n - \"전화 도움 심폐소생술\" 을 안내 받은 경우 출동\n - 환경 요인 중 시정 / 주야간 에도 출동 가능\n – Coverage 10km");
        }

        private void radioButton4_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.radioButton4, "Intermediate model – 3 (Long flight time)\n - \"전화 도움 심폐소생술\" 을 안내 받은 경우 출동\n - 환경 요인 중 온도 / 우천 / 낙뢰 / 시정 / 풍속 에도 출동 불가 하나\n - Coverage 20km");
        }

        private void radioButton5_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.radioButton5, "Basic model\n - \"전화 도움 심폐소생술\" 을 안내 받은 경우 출동\n - 모든 환경적 요인에 출동 불가\n - Coverage 10km");
        }

        private void autoLoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                msg = simulator.getEventsFromCSV("../../EventList.csv");
                if(msg != null) throw new Exception(msg);
                simulator.getStationsFromCSV("../../DroneStationList.csv");
                if(msg != null) throw new Exception(msg);

                eventOverlay.Markers.Clear();
                eventDataGridView.Rows.Clear();

                List<Event> eventList = simulator.getEventList();

                foreach(Event eventElement in eventList)
                {
                    double latitude = eventElement.getCoordinates().Item1;
                    double longitude = eventElement.getCoordinates().Item2;
                    string address = eventElement.getAddress().ToString();
                    string occuredTime = eventElement.getOccuredDate().ToString();
                    string ambulanceTime = eventElement.getAmbulDate().ToString();

                    eventDataGridView.Rows.Add(address, occuredTime, ambulanceTime, latitude, longitude);

                    GMarkerGoogle eventMarker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red_small);
                    eventOverlay.Markers.Add(eventMarker);

                }

                eventMap.Overlays.Add(eventOverlay);

                eventDataGridView.ClearSelection();
                eventMap.Zoom = 9;
                eventMap.SetPositionByKeywords("Seoul, Korea");


                stationOverlay.Markers.Clear();
                stationOverlay.Polygons.Clear();
                updateStationDict();
                textBox1.Text = simulator.getEventList().Count.ToString();
                textBox2.Text = stationDict.Count.ToString();

                int droneCnt = 0;
                foreach(KeyValuePair<string, DroneStation> dict in stationDict)
                {
                    DroneStation stationElement = dict.Value;
                    droneCnt += stationElement.drones.Count;
                }

                textBox3.Text = droneCnt.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void droneProperty_Click(object sender, EventArgs e)
        {
            DroneProperty frm = new DroneProperty(this);
            frm.Show();
        }
    }
}
