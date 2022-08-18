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
    public class Client
    {

        private int port = 6363;
        private string ipAddress = "127.0.0.1";
        public TcpClient tcpClient;
        private MemoryStream memoryStream;
        private IRequest msg;
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
            f.Binder = new AllowAllAssemblyVersionsDeserializationBinder();
             msg = (IRequest)f.Deserialize(tcpClient.GetStream());

          

        }


        public void SendingMethod()
        {
            msg.GetData();

            BinaryFormatter fs = new BinaryFormatter();
            fs.Serialize(tcpClient.GetStream(), memoryStream);

            RecievingMethod();
            SendingMethod();
        }
    }
}
