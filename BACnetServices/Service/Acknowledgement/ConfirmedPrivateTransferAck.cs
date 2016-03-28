using System;
using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class ConfirmedPrivateTransferAck : AcknowledgementService
    {
        public static readonly Hashtable vendorServiceResolutions = new Hashtable();

        public static readonly byte TYPE_ID = 18;

        public ConfirmedPrivateTransferAck(UnsignedInteger vendorId, UnsignedInteger serviceNumber, BaseType resultBlock)
        {
            VendorId = vendorId;
            ServiceNumber = serviceNumber;
            ResultBlock = resultBlock;
        }

        public override byte ChoiceId => TYPE_ID;

        public override void write(ByteStream queue)
        {
            write(queue, VendorId, 0);
            write(queue, ServiceNumber, 1);
            writeOptional(queue, ResultBlock, 2);
        }

        internal ConfirmedPrivateTransferAck(ByteStream queue)
        {
            VendorId = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            ServiceNumber = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 1);
            ResultBlock = readVendorSpecific(queue, VendorId, ServiceNumber, vendorServiceResolutions, 2);
        }

        public UnsignedInteger VendorId { get; }

        public UnsignedInteger ServiceNumber { get; }

        public Encodable ResultBlock { get; }
    }
}
