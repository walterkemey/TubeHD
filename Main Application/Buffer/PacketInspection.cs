using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeTube.Buffer
{
    public class PacketInspection
    {
        private static char[] HEX = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        public static String toString(byte byteValue)
        {
            int tmp = byteValue << 8;
            char[] retstr = new char[] { HEX[(tmp >> 12) & 0x0F], HEX[(tmp >> 8) & 0x0F] };
            return new string(retstr);
        }

        public static String toString(byte[] bytes)
        {
            StringBuilder hexed = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                hexed.Append(toString(bytes[i]));
                hexed.Append(' ');
            }
            return hexed.ToString();
        }
    }
}
