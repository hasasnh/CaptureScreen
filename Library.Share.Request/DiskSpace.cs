using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Library.Share.Request
{
    public class DiskSpace : IRequest
    {
        public Message GetData()
        {
          
                DriveInfo dInfo = new DriveInfo("C");

                // Get free space
               
        MessageLong value = new MessageLong();
            value.Data = dInfo.AvailableFreeSpace;
            value.MessageName = nameof(DiskSpace);
            return value;
        }
    }
}