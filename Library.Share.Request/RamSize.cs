using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Library.Share.Request
{
    [Serializable]
    public class RamSize : IRequest
    {
        public Message GetData()
        {
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
            double Ram_Bytes = 0.0;
            double Ram_inGigaBytes = 0.0;


            foreach (ManagementObject Mobject in Search.Get())
            {
                 Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
               
             }
            Ram_inGigaBytes = Ram_Bytes / 1073741824;
            MessageNumber ramSize = new MessageNumber();
            ramSize.Data = Ram_inGigaBytes;
            ramSize.MessageName = nameof(RamSize);
            return ramSize; 
        }
    }
}
