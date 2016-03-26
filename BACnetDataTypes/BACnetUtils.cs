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
    }
}
