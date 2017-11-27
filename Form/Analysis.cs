using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DroneTransferSimulator
{
    public partial class Analysis : Form
    {
        SimulationResult resultForm;
        static private Simulator simulator = SimulatorUI.simulator;
        private List<double> droneTimeList = new List<double>();
        private List<double> ambulTimeList = new List<double>();
        List<Event> events = simulator.getEventList();
        private Tuple<double, double> goldenTimeSec = simulator.getGoldenTime();

        public Analysis(SimulationResult _form)
        {
            InitializeComponent();

            itemListBox.Items.AddRange(new object[] {"Number of Events", "Coverage Rate", "Rescue Success Rate", "Drone Arrival Rate","Mean of Elapsed Time","Standard Deviation of Elapsed Time"});
            resultForm = _form;
            addCombobox();
            
        }

        public Analysis()
        {
            InitializeComponent();
        }
        
        public void addCombobox()
        {
            List<string> sublocalList = new List<string>() { "도봉구", "강북구", "노원구", "은평구", "성북구", "종로구", "동대문구", "중랑구", "서대문구", "중구", "성동구", "광진구", "용산구", "마포구", "강서구", "양천구", "구로구", "영등포구", "금천구", "관악구", "동작구", "서초구", "강남구", "송파구", "강동구" };
            Dictionary<string, bool> sublocalDict = new Dictionary<string, bool>();
            foreach(string s in sublocalList) sublocalDict.Add(s, false);
            foreach(Event e in events) sublocalDict[e.getAddress().getSubLocal1()] = true;
            foreach(string s in sublocalDict.Keys)
            {
                if(sublocalDict[s] == true) eventRestriction.Items.Add(s);
            }
        }
        
        public List<Event> restrictEvent(List<Event> _events, string subLocal1)
        {
            if(subLocal1 == "") return _events;
            List<Event> newEvents = new List<Event>();
            foreach (Event e in _events) if (e.getAddress().getSubLocal1() == subLocal1) newEvents.Add(e);

            if(newEvents.Count != 0) return newEvents;
            else
            {
                MessageBox.Show("No events");
                return _events;
            }
        }
        
        private double getCoverageRate(List<Event> events)
        {
            double num = 0;
            foreach(Event e in events)
            {
                if(e.getAddress().getSubLocal1() == e.getStation().getStationAddress().getSubLocal1()) num += 1;
            }
            return Math.Round(num / events.Count, 3);
        }

        public double getArrivalRate(List<Event> events)
        {
            double coverEventNum = 0;
            foreach(Event _event in events) if(_event.getResult() == Event.eventResult.SUCCESS) coverEventNum += 1;
            return Math.Round(coverEventNum / events.Count, 3);
        }

        public double getAmbulSuccessRate(List<Event> events)
        {
            double ambulSuccessNum = 0;
            foreach(double time in ambulTimeList) if(time < goldenTimeSec.Item1) ambulSuccessNum += 1;
            return Math.Round(ambulSuccessNum / events.Count, 3);
        }

        public double getSuccessRate(List<Event> events)
        {
            double successEventNum = 0;
            foreach(double time in droneTimeList) if(time < goldenTimeSec.Item1) successEventNum += 1;
            return Math.Round(successEventNum / events.Count, 3);
        }

        public double getDroneMean(List<Event> events)
        {
            double totalTime = 0;
            foreach(double time in droneTimeList) totalTime += time;
            return Math.Round(totalTime / events.Count, 3);
        }

        public double getAmbulMean(List<Event> events)
        {
            double totalTime = 0;
            foreach(int time in ambulTimeList) totalTime += time;
            return Math.Round(totalTime / events.Count ,3);
        }

        public double getDroneStdev(List<Event> events)
        {
            double variation = 0;
            foreach(double time in droneTimeList) variation += Math.Pow(time, 2);
            return Math.Round(Math.Sqrt(variation / events.Count - Math.Pow(getDroneMean(events), 2)), 3);
        }

        public double getAmbulStdev(List<Event> events)
        {
            double variation = 0;
            foreach(int time in ambulTimeList) variation += Math.Pow(time, 2);
            return Math.Round(Math.Sqrt(variation / events.Count - Math.Pow(getDroneMean(events), 2)), 3);
        }

        private void itemListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void itemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            droneTimeList.Clear();
            ambulTimeList.Clear();
            events = simulator.getEventList();
            List<Event> localEvents = new List<Event>();
            if(eventRestriction.SelectedItem != null) localEvents = restrictEvent(events, eventRestriction.SelectedItem.ToString());
            else localEvents = events;
            
            foreach(Event _event in localEvents)
            {
                DateTime ambulTime = _event.getAmbulDate();
                DateTime occuredTime = _event.getOccuredDate();
                double ambulElapsedTime = (ambulTime - occuredTime).TotalSeconds;
                ambulTimeList.Add(ambulElapsedTime);
            }

            foreach(Event _event in localEvents)
            {
                DateTime droneTime = _event.getDroneDate();
                DateTime occuredTime = _event.getOccuredDate();
                double droneElapsedTime = (droneTime - occuredTime).TotalSeconds;
                droneTimeList.Add(droneElapsedTime);
            }

            analyzeResultTable.Rows.Clear();
            if(itemListBox.CheckedItems.Count != 0)
            {
                string[] row0 = { "Number of Events", localEvents.Count.ToString(), localEvents.Count.ToString() };
                string[] row1 = { "Coverage Rate", "N/A", getCoverageRate(localEvents).ToString() };
                string[] row2 = { "Rescue Success Rate", getAmbulSuccessRate(localEvents).ToString(), getSuccessRate(localEvents).ToString() };
                string[] row3 = { "Arrival Rate", "1", getArrivalRate(localEvents).ToString() };
                string[] row4 = { "Mean of Elapsed Time", getAmbulMean(localEvents).ToString(), getDroneMean(localEvents).ToString() };
                string[] row5 = { "Standard Deviation of Elapsed Time", getAmbulStdev(localEvents).ToString(), getDroneStdev(localEvents).ToString() };

                if(itemListBox.GetItemCheckState(0) == CheckState.Checked) analyzeResultTable.Rows.Add(row0);
                if(itemListBox.GetItemCheckState(1) == CheckState.Checked) analyzeResultTable.Rows.Add(row1);
                if(itemListBox.GetItemCheckState(2) == CheckState.Checked) analyzeResultTable.Rows.Add(row2);
                if(itemListBox.GetItemCheckState(3) == CheckState.Checked) analyzeResultTable.Rows.Add(row3);
                if(itemListBox.GetItemCheckState(4) == CheckState.Checked) analyzeResultTable.Rows.Add(row4);
                if(itemListBox.GetItemCheckState(5) == CheckState.Checked) analyzeResultTable.Rows.Add(row5);
            }
            
            return;
        }

        private void analyzeResultTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
