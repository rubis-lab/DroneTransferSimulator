using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DroneTransferSimulator
{
    public partial class LoadEventCsv : Form
    {
        SimulatorUI frm1;
        public LoadEventCsv()
        {
            InitializeComponent();
        }

        public LoadEventCsv(SimulatorUI _form)
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

        private void uploadCSV_click(object sender, EventArgs e)
        {
            string fname = filePathInput.Text;
            try
            { SimulatorUI.s.getEventsFromCSV(fname);}

            catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("Wrong File Name");
                frm1.eventList.Rows.Add("wrongFileName");
                return;
            }
            frm1.eventCsvTextbox.Text=fname + ".csv";
            frm1.eventList.Rows.Clear();

            List<Event> eventList = new List<Event>();

            SimulatorUI.s.getEventList(ref eventList);
            
            foreach(Event eventElements in eventList)
            {
                frm1.eventList.Rows.Add(eventElements.getCoordinates().Item1.ToString(), eventElements.getCoordinates().Item2.ToString(),"2011-01-01 01:01","2011-01-01 01:01");
                
            }
        }
    }
}
