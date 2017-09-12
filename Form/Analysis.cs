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
        public Analysis()
        {
            InitializeComponent();
        }

        public Analysis(SimulationResult _form)
        {
            InitializeComponent();
            resultForm = _form;
        }

        private void itemListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(itemListBox.GetItemCheckState(0)==CheckState.Checked)
            {
                //rescue success rate
                analyzeResultTable.Rows.Add(itemListBox.GetItemText(0), SimulatorUI.simulator.getSuccessRate(), 1);
            }

            if(itemListBox.GetItemCheckState(1)==CheckState.Checked)
            {

            }
            if(itemListBox.GetItemCheckState(2)==CheckState.Checked)
            {

            }

        }
    }
}
