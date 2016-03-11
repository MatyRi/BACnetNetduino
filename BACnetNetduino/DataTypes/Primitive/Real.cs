using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class Real : Primitive
    {
        public static readonly byte TYPE_ID = 4;

        private readonly float value;

        public Real(float value)
        {
            this.value = value;
        }

        public float floatValue()
        {
            return value;
        }

        //
        // Reading and writing
        //
        public Real(ByteStream queue)
        {
            readTag(queue);
            value = queue.ReadFloat();
        }

       
        protected override long getLength()
        {
            return 4;
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
