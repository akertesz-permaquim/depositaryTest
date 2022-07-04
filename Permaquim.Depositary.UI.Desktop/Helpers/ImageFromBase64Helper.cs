using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Helpers
{
    internal static class ImageFromBase64Helper
    {

        public static Image GetImageFromBase64String(string stringValue)
        {
            byte[] bytes = Convert.FromBase64String(stringValue
           .Replace("data:image/png;base64,", String.Empty)
           .Replace("data:image/gif;base64,", String.Empty)
           .Replace("data:image/jpeg;base64,", String.Empty)
           .Replace("data:image/webp;base64,", String.Empty));

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

    }
}
