using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Share.Request
{
    [Serializable]
    public class ScreenCapture : IRequest
    {
        public Message GetData()
        {
            ImageService imageService = new ImageService();
            var img = imageService.CreateScreen();
            MessageImage image = new MessageImage();
            image.Data = img;
            image.MessageName = nameof(ScreenCapture);
            return image;
        }
    }
}
