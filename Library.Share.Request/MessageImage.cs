using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Share.Request
{
    [Serializable]
    public class MessageImage : Message
    {
        public Bitmap Data { get; set; }

    }
}
