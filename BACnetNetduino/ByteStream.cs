using System;
using System.IO;
using System.Text;
using Microsoft.SPOT;

namespace BACnetNetduino
{
    class ByteStream
    {

        private readonly MemoryStream source;

        public ByteStream()
        {
            source = new MemoryStream();
        }

        public ByteStream(MemoryStream ms)
        {
            source = ms;
        }

        public ByteStream(byte[] bytes)
        {
            source = new MemoryStream(bytes);
        }

        public long Length => source.Length;

        public long Position
        {
            get { return source.Position; }
            set { source.Position = value; }
        }

        public byte ReadByte()
        {
            return (byte) source.ReadByte();
        }

        public void Read(byte[] buff)
        {
            source.Read(buff, 0, buff.Length);
        }

        public void Read(byte[] buff, int start, int length)
        {
            source.Read(buff, 0, buff.Length);
        }

        public short ReadShort()
        {
            return (short)((toInt((byte)source.ReadByte()) << 8) | toInt((byte)source.ReadByte()));
        }

        public int ReadIntByte()
        {
            return source.ReadByte() & 0xFF;
        }

        private static int toInt(byte b)
        {
            return b & 0xff;
        }

        public byte popU1B()
        {
            return (byte) (source.ReadByte() & 0xff);
        }

        public ushort popU2B()
        {
            return (ushort) ((source.ReadByte() & 0xff) << 8 | source.ReadByte() & 0xff);
        }

        public int popU3B()
        {
            return (source.ReadByte() & 0xff) << 16 | (source.ReadByte() & 0xff) << 8 | source.ReadByte() & 0xff;
        }

        public int popS4B()
        {
            return (source.ReadByte() & 0xff) << 24 | (source.ReadByte() & 0xff) << 16 | (source.ReadByte() & 0xff) << 8 | source.ReadByte() & 0xff;
        }

        public uint popU4B()
        {
            return (uint)(source.ReadByte() & 0xff) << 24 | (uint)(source.ReadByte() & 0xff) << 16 | (uint)(source.ReadByte() & 0xff) << 8 | (uint)(source.ReadByte() & 0xff);
        }

        public float ReadFloat()
        {
            byte[] source = new byte[4];
            Read(source);
            if (BitConverter.IsLittleEndian)
            {
                // TODO Reverse
            }
            return System.BitConverter.ToSingle(source, 0);
        }

        public double ReadDouble()
        {
            byte[] source = new byte[8];
            Read(source);
            if (BitConverter.IsLittleEndian)
            {
                // TODO Reverse
            }
            return System.BitConverter.ToDouble(source, 0);
        }

        /*public MemoryStream ReadToEnd()
        {
            return new MemoryStream(source.ToArray());
        }*/

        public byte[] ReadToEnd()
        {
            return source.ToArray();
        }

        [Obsolete("Use Read")]
        public void pop(byte[] buff)
        {
            source.Read(buff, 0, buff.Length);
        }

        public void pop(int length)
        {
            source.Position += length;
        }

        public static long toLong(byte b)
        {
            return (b & 0xff);
        }


        public byte PeekByte()
        {
            long tmpPosition = source.Position;
            byte result = ReadByte();
            source.Position = tmpPosition;
            return result;
        }

        public byte Peek()
        {
            long tmpPosition = source.Position;
            byte result = ReadByte();
            source.Position = tmpPosition;
            return result;
        }

        public void Peek(byte[] buff)
        {
            long tmpPosition = source.Position;
            source.Read(buff, 0, buff.Length);
            source.Position = tmpPosition;
        }

        public byte PeekFromHere(int position)
        {
            long tmpPosition = source.Position;
            source.Position += position;
            byte result = ReadByte();
            source.Position = tmpPosition;
            return result;
        }




        #region Writing

        public void WriteByte(byte data)
        {
            source.WriteByte(data);
        }

        public void Write(byte[] data)
        {
            this.source.Write(data, 0, data.Length);
        }

        public void Write(ByteStream data)
        {
            byte[] bData = data.source.ToArray();
            this.source.Write(bData,0,bData.Length);
        }

        public void WriteShort(ushort value)
        {
            source.WriteByte((byte)(0xff & (value >> 8)));
            source.WriteByte((byte)(0xff & value));
        }

        public void WriteInt(int value)
        {
            source.WriteByte((byte)(0xff & (value >> 24)));
            source.WriteByte((byte)(0xff & (value >> 16)));
            source.WriteByte((byte)(0xff & (value >> 8)));
            source.WriteByte((byte)(0xff & value));
        }

        public void WriteLong(short value)
        {
            source.WriteByte((byte)(0xff & (value >> 56)));
            source.WriteByte((byte)(0xff & (value >> 48)));
            source.WriteByte((byte)(0xff & (value >> 40)));
            source.WriteByte((byte)(0xff & (value >> 32)));
            source.WriteByte((byte)(0xff & (value >> 24)));
            source.WriteByte((byte)(0xff & (value >> 16)));
            source.WriteByte((byte)(0xff & (value >> 8)));
            source.WriteByte((byte)(0xff & value));
        }

        #endregion

        public void pushU2B(ushort value)
        {

            WriteByte((byte)(value >> 8));
            WriteByte((byte)value);
    }
    }
}
