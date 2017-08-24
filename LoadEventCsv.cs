using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


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
        
        private void button1_Click(object sender, EventArgs e)
        {
            List<string[]> records = new List<string[]>();
            System.IO.StreamReader sr = new StreamReader(eventCsvPath.Text);
            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] cols = s.Split(',');
                records.Add(cols);
            }
        }
    }
}
