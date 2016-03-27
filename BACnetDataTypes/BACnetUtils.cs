using System.Text;

namespace BACnetDataTypes
{
    public class BACnetUtils
    {
        public static int toInt(byte b)
        {
            return b & 0xff;
        }

        public static long toLong(byte b)
        {
            return (b & 0xff);
        }

        public static byte[] dottedStringToBytes(string substring)
        {
            string[] parts = substring.Split('.');
            byte[] b = new byte[parts.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = byte.Parse(parts[i]);
            }
            return b;
        }

        public static string bytesToDottedString(byte[] value)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                if (i > 0)
                    sb.Append('.');
                sb.Append(0xff & value[i]);
            }
            return sb.ToString();
        }

        public static bool[] convertToBooleans(byte[] data, int length)
        {
            bool[] bdata = new bool[length];
            for (int i = 0; i < bdata.Length; i++)
                bdata[i] = ((data[i / 8] >> (7 - (i % 8))) & 0x1) == 1;
            return bdata;
        }

        public static byte[] convertToBytes(bool[] bdata)
        {
            int byteCount = (bdata.Length + 7) / 8;
            byte[] data = new byte[byteCount];
            for (int i = 0; i < bdata.Length; i++)
            {
                data[i / 8] |= (byte)((bdata[i] ? 1 : 0) << (7 - (i % 8)));
            }   
            return data;
        }
    }
}
