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
    public partial class LoadStationCsv : Form
    {
        simulator form1;
        public LoadStationCsv()
        {
            InitializeComponent();
        }

        public LoadStationCsv(simulator _form)
        {
            InitializeComponent();
            form1 = _form;
        }
    }
}
