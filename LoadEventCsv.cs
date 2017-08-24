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
    public partial class LoadEventCsv : Form
    {
        simulator frm1;
        public LoadEventCsv()
        {
            InitializeComponent();
        }

        public LoadEventCsv(simulator _form)
        {
            InitializeComponent();
            frm1 = _form;
        }

        private void LoadEventCsv_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
