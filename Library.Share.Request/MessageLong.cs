using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Share.Request
{
    [Serializable]
    public class MessageLong : Message
    {
        public long Data { get; set; }
    }
}
