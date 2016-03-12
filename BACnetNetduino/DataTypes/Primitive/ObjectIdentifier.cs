using System;
using BACnetNetduino.DataTypes.Enumerated;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class ObjectIdentifier : Primitive
    {
        public static readonly byte TYPE_ID = 12;

        private ObjectType objectType;
        private uint instanceNumber;

        public ObjectIdentifier(ObjectType objectType, uint instanceNumber)
        {
            setValues(objectType, instanceNumber);
        }

        private void setValues(ObjectType objectType, uint instanceNumber)
        {
            if (instanceNumber < 0 || instanceNumber > 0x3FFFFF)
                throw new ArgumentException("Illegal instance number: " + instanceNumber);

            this.objectType = objectType;
            this.instanceNumber = instanceNumber;
        }

        public ObjectType getObjectType()
        {
            return objectType;
        }

        public uint getInstanceNumber()
        {
            return instanceNumber;
        }

        public override string ToString()
        {
            return objectType.ToString() + " " + instanceNumber;
        }

        //
        // Reading and writing
        //
        public ObjectIdentifier(ByteStream queue)
        {
            readTag(queue);

            uint objectType = (uint) (queue.popU1B() << 2);
            uint i = queue.popU1B();
            objectType |= i >> 6;

            this.objectType = new ObjectType(objectType);

            instanceNumber = (i & 0x3f) << 16;
            instanceNumber |= (uint)queue.popU1B() << 8;
            instanceNumber |= queue.popU1B();
        }

        /*public override void writeImpl(ByteStream queue)
        {
            int objectType = this.objectType.intValue();
            queue.push(objectType >> 2);
            queue.push(((objectType & 3) << 6) | (instanceNumber >> 16));
            queue.push(instanceNumber >> 8);
            queue.push(instanceNumber);
        }*/

        protected override long getLength()
        {
            return 4;
        }

        protected override byte getTypeId()
        {
            return TYPE_ID;
        }

    }
}
