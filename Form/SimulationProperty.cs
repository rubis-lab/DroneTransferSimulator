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
    public partial class SimulationProperty : Form
    {
        SimulatorUI formUI;
        private Simulator simulator = SimulatorUI.simulator;

        public SimulationProperty()
        {
            InitializeComponent();
        }

        public SimulationProperty(SimulatorUI _frm)
        {
            InitializeComponent();
            formUI = _frm;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            simulator.setGoldenTime(Convert.ToDouble(goldenTimeText1.Text), Convert.ToDouble(goldenTimeText2.Text));
            this.Close();

        }
    }
}
