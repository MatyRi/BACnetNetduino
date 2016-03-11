using System;
using System.IO;
using System.Text;
using Microsoft.SPOT;

namespace BACnetNetduino
{
    class ByteStream
    {

        private readonly MemoryStream source;

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

        public int popU1B()
        {
            return source.ReadByte() & 0xff;
        }

        public int popU2B()
        {
            return (source.ReadByte() & 0xff) << 8 | source.ReadByte() & 0xff;
        }

        public int popU3B()
        {
            return (source.ReadByte() & 0xff) << 16 | (source.ReadByte() & 0xff) << 8 | source.ReadByte() & 0xff;
        }

        public int popS4B()
        {
            return (source.ReadByte() & 0xff) << 24 | (source.ReadByte() & 0xff) << 16 | (source.ReadByte() & 0xff) << 8 | source.ReadByte() & 0xff;
        }

        public long popU4B()
        {
            return (long)(source.ReadByte() & 0xff) << 24 | (long)(source.ReadByte() & 0xff) << 16 | (long)(source.ReadByte() & 0xff) << 8 | (long)(source.ReadByte() & 0xff);
        }

        [Obsolete]
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
    }
}
