using System;
using BACnetDataTypes;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class VtDataAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 23;

        public VtDataAck(BBoolean allNewDataAccepted, UnsignedInteger acceptedOctetCount)
        {
            AllNewDataAccepted = allNewDataAccepted;
            AcceptedOctetCount = acceptedOctetCount;
        }


        public override byte ChoiceId => TYPE_ID;

        public void write(ByteStream queue)
        {
            write(queue, AllNewDataAccepted, 0);
            writeOptional(queue, AcceptedOctetCount, 1);
        }

        internal VtDataAck(ByteStream queue)
        {
            AllNewDataAccepted = (BBoolean) read(queue, typeof (BBoolean), 0);
            AcceptedOctetCount = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 1);
        }

        public BBoolean AllNewDataAccepted { get; }

        public UnsignedInteger AcceptedOctetCount { get; }
    }
}
