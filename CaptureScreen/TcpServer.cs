using Library.Share.Request;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CaptureScreen
{
    public class TcpServer
    {
        private int Port;
        private IPAddress LocalIPAddress ;
        private TcpListener Listener;
        private TcpClient Client;
        private Form1 Form;
        public TcpServer(Form1 from)
        {
            Port = 6363;
            LocalIPAddress = IPAddress.Parse("127.0.0.1");
            Form = from;
        }

        public void Startlisting()
        {
            Listener = new TcpListener(LocalIPAddress, Port);
            Listener.Start();
        }

        public void WaitForConnection()
        {
            Listener.BeginAcceptTcpClient(new AsyncCallback(ConnectionHandler), null);
        }

        private void ConnectionHandler(IAsyncResult ar)
        {
            Client = Listener.EndAcceptTcpClient(ar);

            ReceivingMethod();
        }

        public void SendingMethod(IRequest request)
        {
            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(Client.GetStream(), request);
        }

        public void ReceivingMethod()
        {
            while (true)
            {
                if (Client != null)
                {
                    BinaryFormatter f = new BinaryFormatter();
                    var msg = f.Deserialize(Client.GetStream());

                   // pictureBox1.Image = new Bitmap((MemoryStream)msg);

                    Form.pictureBox1.Image = new Bitmap((MemoryStream)msg);
                }
            }
        }
    }
}
