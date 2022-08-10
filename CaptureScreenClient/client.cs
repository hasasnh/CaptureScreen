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

namespace CaptureScreenClient
{
    public class Client
    {

        private int port = 6363;
        private string ipAddress = "127.0.0.1";
        public TcpClient tcpClient;
        private MemoryStream memoryStream;


        public Client()
        {

        }

        public void Connect()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(ipAddress, port);

            RecievingMethod();
            SendingMethod();
        }

        private void RecievingMethod()
        {


            BinaryFormatter f = new BinaryFormatter();
            var msg = f.Deserialize(tcpClient.GetStream());

        }


        private void SendingMethod()
        {

            BinaryFormatter fs = new BinaryFormatter();
            fs.Serialize(tcpClient.GetStream(), memoryStream);

            ImageService imageService = new ImageService();
            imageService.CreateScreen();

        }
    }
}
