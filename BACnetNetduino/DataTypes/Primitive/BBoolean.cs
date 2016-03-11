using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class BBoolean : Primitive
    {
        public static readonly byte TYPE_ID = 1;

        protected bool value;

        public BBoolean(bool value)
        {
            this.value = value;
        }

        public bool booleanValue()
        {
            return value;
        }

        public BBoolean(ByteStream queue)
        {
            long length = readTag(queue);
            if (contextSpecific)
                value = queue.ReadByte() == 1;
            else
                value = length == 1;
        }

        /*public override void writeImpl(ByteStream queue)
        {
            if (contextSpecific)
                queue.push((byte)(value ? 1 : 0));
        }*/

        protected override long getLength()
        {
            if (contextSpecific)
                return 1;
            return (byte)(value ? 1 : 0);
        }

        protected override byte getTypeId()
        {
            return TYPE_ID;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
