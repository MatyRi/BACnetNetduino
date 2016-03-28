using System;
using BACnetDataTypes;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class VtOpenAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 21;

        public VtOpenAck(UnsignedInteger remoteVTSessionIdentifier)
        {
            RemoteVtSessionIdentifier = remoteVTSessionIdentifier;
        }

        public override byte ChoiceId => TYPE_ID;

        public void write(ByteStream queue)
        {
            write(queue, RemoteVtSessionIdentifier);
        }

        internal VtOpenAck(ByteStream queue)
        {
            RemoteVtSessionIdentifier = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
        }

        public UnsignedInteger RemoteVtSessionIdentifier { get; }
    }
}
