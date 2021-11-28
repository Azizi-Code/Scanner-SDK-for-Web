using System.Drawing;
using System.IO;

namespace Scanner.Service
{
    public static class ImageToByte
    {
        public static byte[] ToByte(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
