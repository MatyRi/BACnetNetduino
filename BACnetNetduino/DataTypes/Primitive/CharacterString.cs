using System;
using System.Text;
using BACnetNetduino.DataTypes.Enumerated;
using BACnetNetduino.Exception;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class CharacterString : Primitive
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

        private readonly Encodings encoding;
        private readonly string value;

        public CharacterString(string value)
        {
            encoding = Encodings.ANSI_X3_4;
            this.value = value;
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
            this.encoding = encoding;
            this.value = value;
        }

        public Encodings getEncoding()
        {
            return encoding;
        }

        public string getValue()
        {
            return value;
        }

        //
        // Reading and writing
        //
        public CharacterString(ByteStream queue)
        {
            int length = (int)readTag(queue);

            byte enc = queue.ReadByte();
            encoding = Encodings.ANSI_X3_4;
            validateEncoding();

            byte[] bytes = new byte[length - 1];
            queue.pop(bytes);

            value = decode(encoding, bytes);
          
        }

    
    /*public override void writeImpl(ByteStream queue)
    {
        queue.push(encoding);
        queue.push(encode(encoding, value));
    }*/

    
    protected override long getLength()
    {
        return encode(encoding, value).Length + 1;
    }

    
    protected override byte getTypeId()
    {
        return TYPE_ID;
    }

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
                    return Encoding.UTF8.GetBytes(value);
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
                    return new string(Encoding.UTF8.GetChars(bytes));
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
        if (encoding != Encodings.ANSI_X3_4 && encoding != Encodings.ISO_10646_UCS_2
                && encoding != Encodings.ISO_8859_1)
            throw new BACnetErrorException(ErrorClass.property, ErrorCode.characterSetNotSupported, encoding.ToString());
    }



    public override string ToString()
    {
        return value;
    }

}

}
