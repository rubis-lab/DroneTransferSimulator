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
        private List<double> droneTimeList = simulator.droneElapsedTime;
        private List<double> ambulTimeList = new List<double>();

        public Analysis()
        {
            InitializeComponent();
        }

        public void setAmbulTimeList()
        {
            foreach(Event _event in events)
            {
                DateTime ambulTime = _event.getAmbulDate();
                DateTime occuredTime = _event.getOccuredDate();
                double ambulElapsedTime = (ambulTime - occuredTime).TotalSeconds;
                ambulTimeList.Add(ambulElapsedTime);
            }
        }

        public Analysis(SimulationResult _form)
        {
            InitializeComponent();
            resultForm = _form;
            setAmbulTimeList();
        }
        
        public double getSuccessRate()
        {
            double successEventNum = simulator.successEventNum;
            return Math.Round(successEventNum / events.Count, 3);
        }

        public double getDroneMean()
        {
            double totalTime = 0;
            foreach (double time in droneTimeList) totalTime += time;
            return Math.Round(totalTime / events.Count, 3);
        }

        public double getAmbulMean()
        {
            double totalTime = 0;
            foreach (int time in ambulTimeList) totalTime += time;
            return Math.Round( totalTime / events.Count ,3);
        }

        public double getDroneStdev()
        {
            double variation = 0;
            foreach (double time in droneTimeList) variation += Math.Pow(time, 2);
            return Math.Round(Math.Sqrt(variation / events.Count - Math.Pow(getDroneMean(), 2)), 3);
        }

        public double getAmbulStdev()
        {
            double variation = 0;
            foreach (int time in ambulTimeList) variation += Math.Pow(time, 2);
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
            analyzeResultTable.Rows.Clear();

            if (itemListBox.CheckedItems.Count != 0)
            {
                string[] row0 = { "Rescue Success Rate", "1", getSuccessRate().ToString() };
                string[] row1 = { "Mean of Elapsed Time", getAmbulMean().ToString(), getDroneMean().ToString() };
                string[] row2 = { "Standart Deviation of Elapsed Time", getAmbulStdev().ToString(), getDroneStdev().ToString() };

                if (itemListBox.GetItemCheckState(0) == CheckState.Checked)
                {
                    analyzeResultTable.Rows.Add(row0);
                }

                if (itemListBox.GetItemCheckState(1) == CheckState.Checked)
                {
                    analyzeResultTable.Rows.Add(row1);
                }
                if (itemListBox.GetItemCheckState(2) == CheckState.Checked)
                {
                    analyzeResultTable.Rows.Add(row2);
                }
            }
            else return;
        }

        private void analyzeResultTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
