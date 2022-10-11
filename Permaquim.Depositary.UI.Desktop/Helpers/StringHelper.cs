using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Permaquim.Depositary.UI.Desktop.Helpers
{
    internal static class StringHelper
    {
        public enum AlignEnum
        {

            AlignLeft,
            AlignMiddle,
            AlignRight
        }
        private const char SPACE = ' ';
        public static string FormatString(String text, int textLenght, AlignEnum align)
        {
            StringBuilder returnValue = new();

            switch (align)
            {
                case AlignEnum.AlignLeft:

                    returnValue.Append(text);
                    returnValue.Append(SPACE, textLenght - text.Length);

                    break;
                case AlignEnum.AlignMiddle:

                    int startText = textLenght / 2 - text.Length / 2;

                    returnValue.Append(SPACE, startText - 1);
                    returnValue.Append(text);
                    returnValue.Append(SPACE, textLenght - returnValue.Length);

                    break;
                case AlignEnum.AlignRight:

                    returnValue.Append(SPACE, textLenght - text.Length);
                    returnValue.Append(text);

                    break;
                default:
                    break;
            }


            return returnValue.ToString();
        }

    }
}
