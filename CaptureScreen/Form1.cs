using Library.Share.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureScreen
{
    public partial class Form1 : Form
    {
        TcpServer tcpServer;
       

        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnstart_Click_1(object sender, EventArgs e)
        {
            tcpServer = new TcpServer(this);
            tcpServer.Startlisting();
            tcpServer.WaitForConnection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            IRequest request = new ScreenCapture();

            tcpServer.SendingMethod(request);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(delegate ()
            {
                while (true)
                {
                    tcpServer.SendingMethod(null );
                }
            });
            thread.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            IRequest request = new DiskSpace();
           // label1.Text = request.GetData();









        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

       
    }
}

