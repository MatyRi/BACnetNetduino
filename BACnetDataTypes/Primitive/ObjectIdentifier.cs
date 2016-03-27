using System;
using BACnetDataTypes.Enumerated;

namespace BACnetDataTypes.Primitive
{
    public class ObjectIdentifier : Primitive
    {
        public static readonly byte TYPE_ID = 12;

        public ObjectIdentifier(ObjectType objectType, uint instanceNumber)
        {
            setValues(objectType, instanceNumber);
        }

        private void setValues(ObjectType objectType, uint instanceNumber)
        {
            if (instanceNumber < 0 || instanceNumber > 0x3FFFFF)
                throw new ArgumentException("Illegal instance number: " + instanceNumber);

            ObjectType = objectType;
            InstanceNumber = instanceNumber;
        }

        public ObjectType ObjectType { get; private set; }

        public uint InstanceNumber { get; private set; }

        public override string ToString() => ObjectType + " " + InstanceNumber;

        //
        // Reading and writing
        //
        public ObjectIdentifier(ByteStream queue)
        {
            readTag(queue);

            uint objectType = (uint) (queue.popU1B() << 2);
            uint i = queue.popU1B();
            objectType |= i >> 6;

            ObjectType = new ObjectType(objectType);

            InstanceNumber = (i & 0x3f) << 16;
            InstanceNumber |= (uint)queue.popU1B() << 8;
            InstanceNumber |= queue.popU1B();
        }

        protected override void WriteImpl(ByteStream queue)
        {
            uint objectType = ObjectType.Value;
            queue.WriteByte((byte) (objectType >> 2));
            queue.WriteByte((byte) (((objectType & 3) << 6) | (InstanceNumber >> 16)));
            queue.WriteByte((byte) (InstanceNumber >> 8));
            queue.WriteByte((byte) InstanceNumber);
        }

        protected override long Length { get; } = 4;

        protected override byte TypeId => TYPE_ID;
    }
}
