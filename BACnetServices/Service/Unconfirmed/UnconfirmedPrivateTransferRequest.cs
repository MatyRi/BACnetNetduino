using System;
using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Unconfirmed
{
    class UnconfirmedPrivateTransferRequest : UnconfirmedRequestService
    {
        //Map<VendorServiceKey, SequenceDefinition>
        public static readonly Hashtable vendorServiceResolutions = new Hashtable();

        public static readonly byte TYPE_ID = 4;

        private readonly UnsignedInteger vendorId;
        private readonly UnsignedInteger serviceNumber;
        private readonly Encodable serviceParameters;

        public UnconfirmedPrivateTransferRequest(UnsignedInteger vendorId, UnsignedInteger serviceNumber,
            Encodable serviceParameters)
        {
            this.vendorId = vendorId;
            this.serviceNumber = serviceNumber;
            this.serviceParameters = serviceParameters;
        }

        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            // TODO localDevice.getEventHandler().firePrivateTransfer(vendorId, serviceNumber, serviceParameters);
        }

        public override byte ChoiceId => TYPE_ID;

        public override void write(ByteStream queue)
        {
            write(queue, vendorId, 0);
            write(queue, serviceNumber, 1);
            writeOptional(queue, serviceParameters, 2);
        }

        UnconfirmedPrivateTransferRequest(ByteStream queue)
        {
            vendorId = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            serviceNumber = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 1);
            serviceParameters = readVendorSpecific(queue, vendorId, serviceNumber, vendorServiceResolutions, 2);
        }
    }
}
