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
        private List<Event> events = simulator.getEventList();
        private List<double> droneTimeList = new List<double>();
        private List<double> ambulTimeList = new List<double>();
        private int goldenTimeSec= 480; //8 minutes in second

        public Analysis()
        {
            InitializeComponent();
        }

        public List<Event> restrictEvent(List<Event> _events, string subLocal1)
        {
            if(subLocal1 == "None") return _events;
            List<Event> newEvents = new List<Event>();
            foreach(Event _event in _events ) if(_event.getAddress().getSubLocal1() == subLocal1) newEvents.Add(_event);
            return newEvents;
        }
        
        public List<Event> restrictStation(List<Event> _events, string subLocal1)
        {
            if (subLocal1 == "None") return _events;
            List<Event> newEvents = new List<Event>();
            foreach(Event _event in _events) if(_event.getStation().getStationAddress().getSubLocal1() == subLocal1) newEvents.Add(_event);
            return newEvents;
        }

        public Analysis(SimulationResult _form)
        {
            InitializeComponent();
            resultForm = _form;
        }
        
        public double getCoverageRate()
        {
            double coverEventNum = 0;
            foreach(Event _event in events) if(_event.getResult() == Event.eventResult.SUCCESS) coverEventNum += 1;
            return Math.Round(coverEventNum / events.Count, 3);
        }

        public double getAmbulCoverageRate()
        {
            double ambulSuccessNum = 0;
            foreach(double time in ambulTimeList) if(time < goldenTimeSec) ambulSuccessNum += 1;
            return Math.Round(ambulSuccessNum / events.Count, 3);
        }

        public double getSuccessRate()
        {
            double successEventNum = 0;
            foreach(double time in droneTimeList) if(time < goldenTimeSec) successEventNum += 1;
            return Math.Round(successEventNum / events.Count, 3);
        }

        public double getDroneMean()
        {
            double totalTime = 0;
            foreach(double time in droneTimeList) totalTime += time;
            return Math.Round(totalTime / events.Count, 3);
        }

        public double getAmbulMean()
        {
            double totalTime = 0;
            foreach(int time in ambulTimeList) totalTime += time;
            return Math.Round( totalTime / events.Count ,3);
        }

        public double getDroneStdev()
        {
            double variation = 0;
            foreach(double time in droneTimeList) variation += Math.Pow(time, 2);
            return Math.Round(Math.Sqrt(variation / events.Count - Math.Pow(getDroneMean(), 2)), 3);
        }

        public double getAmbulStdev()
        {
            double variation = 0;
            foreach(int time in ambulTimeList) variation += Math.Pow(time, 2);
            return Math.Round(Math.Sqrt(variation / events.Count - Math.Pow(getDroneMean(), 2)), 3);
        }

        private void itemListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            

        }

        private void itemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            events = restrictEvent(events, eventRestriction.SelectedText);
            events = restrictStation(events, stationRestriction.SelectedText);

            foreach(Event _event in events)
            {
                DateTime ambulTime = _event.getAmbulDate();
                DateTime occuredTime = _event.getOccuredDate();
                double ambulElapsedTime = (ambulTime - occuredTime).TotalSeconds;
                ambulTimeList.Add(ambulElapsedTime);
            }

            foreach(Event _event in events)
            {
                DateTime droneTime = _event.getDroneDate();
                DateTime occuredTime = _event.getOccuredDate();
                double droneElapsedTime = (droneTime - occuredTime).TotalSeconds;
                droneTimeList.Add(droneElapsedTime);
            }

            analyzeResultTable.Rows.Clear();
            if(itemListBox.CheckedItems.Count != 0)
            {
                string[] row0 = { "Rescue Success Rate", getAmbulCoverageRate().ToString(), getSuccessRate().ToString() };
                string[] row2 = { "Mean of Elapsed Time", getAmbulMean().ToString(), getDroneMean().ToString() };
                string[] row3 = { "Standard Deviation of Elapsed Time", getAmbulStdev().ToString(), getDroneStdev().ToString() };
                string[] row1 = { "Coverage Success Rate", "1", getCoverageRate().ToString() };

                if(itemListBox.GetItemCheckState(0) == CheckState.Checked) analyzeResultTable.Rows.Add(row0);
                if(itemListBox.GetItemCheckState(1) == CheckState.Checked) analyzeResultTable.Rows.Add(row1);
                if(itemListBox.GetItemCheckState(2) == CheckState.Checked) analyzeResultTable.Rows.Add(row2);
                if(itemListBox.GetItemCheckState(3) == CheckState.Checked) analyzeResultTable.Rows.Add(row3);
            }
            else return;
        }

        private void analyzeResultTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
