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

            index = dataGridView2.Rows.Add(); 
            dataGridView2.Rows[index].Cells["p_subzero"].Value = simulator.p_subzero ? 1 : 0;
            dataGridView2.Rows[index].Cells["p_rain"].Value = simulator.p_rain ? 1 : 0;
            dataGridView2.Rows[index].Cells["p_light"].Value = simulator.p_light ? 1 : 0;
            dataGridView2.Rows[index].Cells["p_snow"].Value = simulator.p_snow ? 1 : 0;
            dataGridView2.Rows[index].Cells["p_sight"].Value = simulator.p_sight ? 1 : 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                simulator.w_temp_low = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_temp_low"].Value);
                simulator.w_temp_high = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_temp_high"].Value);
                simulator.w_rain = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_rain"].Value);
                simulator.w_winds = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_winds"].Value);
                simulator.w_snow = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_snow"].Value);
                simulator.w_sight = Convert.ToDouble(dataGridView1.Rows[0].Cells["w_sight"].Value);

                simulator.p_subzero = Convert.ToInt32(dataGridView2.Rows[0].Cells["p_subzero"].Value) == 0 ? false : true;
                simulator.p_rain = Convert.ToInt32(dataGridView2.Rows[0].Cells["p_rain"].Value) == 0 ? false : true;
                simulator.p_light = Convert.ToInt32(dataGridView2.Rows[0].Cells["p_light"].Value) == 0 ? false : true;
                simulator.p_snow = Convert.ToInt32(dataGridView2.Rows[0].Cells["p_snow"].Value) == 0 ? false : true;
                simulator.p_sight = Convert.ToInt32(dataGridView2.Rows[0].Cells["p_sight"].Value) == 0 ? false : true;
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

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(Convert.ToInt32(dataGridView2[e.ColumnIndex, e.RowIndex].Value) != 1 && Convert.ToInt32(dataGridView2[e.ColumnIndex, e.RowIndex].Value) != 0)
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("1 또는 0을 입력해주십시오.");
            }
        }
    }
}
