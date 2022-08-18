using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Share.Request
{
    [Serializable]
    public class MessageText : Message
    {
        public string Data { get; set; }
    }
}
