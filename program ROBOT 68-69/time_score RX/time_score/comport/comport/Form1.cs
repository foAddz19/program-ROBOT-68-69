using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace comport
{
    
    public partial class Form1 : Form
    {
        string dataouts ;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comport.Items.AddRange(ports);

        }

        private void open_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort2.PortName = comport.Text;
                serialPort2.BaudRate = Convert.ToInt32(baudpate.Text);
                serialPort2.DataBits = Convert.ToInt32(databits.Text);
                serialPort2.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopbits.Text);
                serialPort2.Parity = (Parity)Enum.Parse(typeof(Parity), paritybits.Text);
                
                serialPort2.Open();
                progressBar2.Value = 100;
            }
            catch(Exception err) {
                MessageBox.Show(err.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            { 
                serialPort2.Close();
                progressBar2.Value = 0;
            }
        }

        private void senddata_Click(object sender, EventArgs e)
        {
         

            if (serialPort2.IsOpen)
            {
               dataouts = dataout.Text;
               //serialPort2.WriteLine(dataouts);
                serialPort2.Write(dataouts);

            }
        }
    }
}
