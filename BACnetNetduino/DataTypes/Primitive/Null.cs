using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class Null : Primitive
    {
        public static readonly byte TYPE_ID = 0;

        public Null()
        {
            // no op
        }

        public Null(ByteStream queue)
        {
            readTag(queue);
        }

        /*public override void writeImpl(ByteStream queue)
        {
            // no op
        }*/

        
        protected override long getLength()
        {
            return 0;
        }

        protected override byte getTypeId()
        {
            return TYPE_ID;
        }

        public override string ToString()
        {
            return "Null";
        }
    }
}
