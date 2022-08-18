using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Library.Share.Request
{
    public class ClientInfo : IRequest
    {
        public Message GetData()
        {
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            string OS = null;

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                OS = obj["Caption"].ToString();
            }

            MessageText txt = new MessageText();
            txt.Data = OS;
            txt.MessageName = nameof(ClientInfo);
            return txt;
        }
    }
}
