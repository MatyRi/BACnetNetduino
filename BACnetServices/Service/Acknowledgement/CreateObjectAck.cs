using System;
using BACnetDataTypes;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class CreateObjectAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 10;

        public CreateObjectAck(ObjectIdentifier objectIdentifier)
        {
            ObjectIdentifier = objectIdentifier;
        }

        public override byte ChoiceId => TYPE_ID;

        public ObjectIdentifier ObjectIdentifier { get; }

        public void write(ByteStream queue)
        {
            write(queue, ObjectIdentifier);
        }

        internal CreateObjectAck(ByteStream queue)
        {
            ObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier));
        }

        public override string ToString() => "CreateObjectAck(" + ObjectIdentifier + ")";
    }
}
