using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Library.Share.Request;

namespace CaptureScreenClient
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Connect();
            //client.RecievingMethod();
            //client.CreateScreen();
            //client.SendingMethod();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client client = new Client();

            //IRequest request = new ScreenCapture();
            IRequest request = new ClientInfo();

            client.SendingMethod();

        }
    }
}