using System.Text;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;

namespace BACnetDataTypes.Primitive
{
    public class CharacterString : Primitive
    {
        public static readonly byte TYPE_ID = 7;

        public enum Encodings
        {
            ANSI_X3_4 = 0,
            IBM_MS_DBCS = 1,
            JIS_C_6226 = 2,
            ISO_10646_UCS_4 = 3,
            ISO_10646_UCS_2 = 4,
            ISO_8859_1 = 5
        }

        public CharacterString(string value)
        {
            Encoding = Encodings.ANSI_X3_4;
            Value = value;
        }

        public CharacterString(Encodings encoding, string value)
        {
            try
            {
                validateEncoding();
            }
            catch (BACnetErrorException e)
            {
                // This is an API constructor, so it doesn't need to throw checked exceptions. Convert to runtime.
                throw new BACnetRuntimeException(e);
            }
            Encoding = encoding;
            Value = value;
        }

        public Encodings Encoding { get; }

        public string Value { get; }

        //
        // Reading and writing
        //
        public CharacterString(ByteStream queue)
        {
            int length = (int) readTag(queue);

            //byte enc = queue.ReadByte();
            //Encoding = Encodings.ANSI_X3_4;
            Encoding = (Encodings) queue.ReadByte();
            validateEncoding();

            byte[] bytes = new byte[length - 1];
            queue.Read(bytes);

            Value = decode(Encoding, bytes);
        }


        protected override void WriteImpl(ByteStream queue)
        {
            queue.WriteByte((byte) Encoding);
            queue.Write(encode(Encoding, Value));
        }


        protected override long Length => encode(Encoding, Value).Length + 1;

        protected override byte TypeId => TYPE_ID;

        private static byte[] encode(Encodings encoding, string value)
        {
            switch (encoding)
            {
                case Encodings.ISO_10646_UCS_2:
                // TODO return value.getBytes("UTF-16");
                case Encodings.ISO_8859_1:
                // TODO return value.getBytes("ISO-8859-1");
                case Encodings.ANSI_X3_4:
                default:
                    return System.Text.Encoding.UTF8.GetBytes(value);
            }
        }

        private static string decode(Encodings encoding, byte[] bytes)
        {
            /*try
        {*/
            switch (encoding)
            {
                case Encodings.ISO_10646_UCS_2:
                // TODO return new string(bytes, "UTF-16");
                case Encodings.ISO_8859_1:
                // TODO return new string(bytes, "ISO-8859-1");
                case Encodings.ANSI_X3_4:
                default:
                    //AdK
                    //return new string(bytes, "UTF-8");
                    return new string(System.Text.Encoding.UTF8.GetChars(bytes));
            }
            /*}
        catch (UnsupportedEncodingException e)
        {
            // Should never happen, so convert to a runtime exception.
            throw new RuntimeException(e);
        }
        return null;*/
        }

        private void validateEncoding()
        {
            if (Encoding != Encodings.ANSI_X3_4 && Encoding != Encodings.ISO_10646_UCS_2
                && Encoding != Encodings.ISO_8859_1)
                throw new BACnetErrorException(ErrorClass.Property, ErrorCode.CharacterSetNotSupported,
                    Encoding.ToString());
        }


        public override string ToString() => Value;
    }
}
