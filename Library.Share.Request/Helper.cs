using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Library.Share.Request
{
    public static class Helper
    {
        public static Message GetCaptureScreen()
        {
            ImageService imageService = new ImageService();
            var bm = imageService.CreateScreen();
            MessageImage image = new MessageImage();
            image.Data = bm;
            image.MessageName = nameof(ScreenCapture);
            return image;
        }

        public static Message GetClientInfo()
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

        public static MemoryStream ToMemoryStream(this Bitmap btm)
        {
            var memoryStream = new MemoryStream();
            btm.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream;
        }
    }
}
