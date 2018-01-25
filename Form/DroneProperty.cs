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
    public partial class DroneProperty : Form
    {
        SimulatorUI simulatorUIForm;
        static public Simulator simulator = Simulator.getInstance();

        public DroneProperty()
        {
            InitializeComponent();
        }

        public DroneProperty(SimulatorUI _form)
        {
            InitializeComponent();
            simulatorUIForm = _form;
            
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells["w_temp_low"].Value = simulator.w_temp_low;
            dataGridView1.Rows[index].Cells["w_temp_high"].Value = simulator.w_temp_high;
            dataGridView1.Rows[index].Cells["w_rain"].Value = simulator.w_rain;
            dataGridView1.Rows[index].Cells["w_winds"].Value = simulator.w_winds;
            dataGridView1.Rows[index].Cells["w_snow"].Value = simulator.w_snow;
            dataGridView1.Rows[index].Cells["w_sight"].Value = simulator.w_sight;

            subzeroCheckBox.Checked = simulator.p_subzero;
            rainCheckBox.Checked = simulator.p_rain;
            lightCheckBox.Checked = simulator.p_light;
            snowCheckBox.Checked = simulator.p_snow;
            sightCheckBox.Checked = simulator.p_sight;

            maxSpeedTextBox.Text = simulator.maxSpeed.ToString();
            maxDistanceTextBox.Text = simulator.maxDistance.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                simulator.maxSpeed = Convert.ToDouble(maxSpeedTextBox.Text);
                simulator.maxDistance = Convert.ToDouble(maxDistanceTextBox.Text);

                simulator.w_temp_low = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_temp_low"].Value);
                simulator.w_temp_high = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_temp_high"].Value);
                simulator.w_rain = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_rain"].Value);
                simulator.w_winds = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_winds"].Value);
                simulator.w_snow = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_snow"].Value);
                simulator.w_sight = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_sight"].Value);
                this.Close();
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToDouble(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show("올바른 입력값이 아닙니다.");
            }
        }

        private void subzeroCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            simulator.p_subzero = subzeroCheckBox.Checked;
        }

        private void rainCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            simulator.p_rain = rainCheckBox.Checked;
        }

        private void lightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            simulator.p_light = lightCheckBox.Checked;
        }

        private void snowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            simulator.p_snow = snowCheckBox.Checked;
        }

        private void sightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            simulator.p_sight = sightCheckBox.Checked;
        }
    }
}
