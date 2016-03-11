using System;
using BACnetNetduino.DataTypes.Enumerated;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.Service.Unconfirmed
{
    class IAmRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 0;

        private readonly ObjectIdentifier iAmDeviceIdentifier;
        private readonly UnsignedInteger maxAPDULengthAccepted;
        private readonly Segmentation segmentationSupported;
        private readonly UnsignedInteger vendorId;

        public IAmRequest(ByteStream source)
        {
            iAmDeviceIdentifier = new ObjectIdentifier(source);
            maxAPDULengthAccepted = new UnsignedInteger(source);
            segmentationSupported = new Segmentation(source);
            vendorId = new UnsignedInteger(source);
        }
    }
}
