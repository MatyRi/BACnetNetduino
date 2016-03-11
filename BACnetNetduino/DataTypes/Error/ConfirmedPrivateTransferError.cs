using System;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Primitive;
using BACnetNetduino.Service;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Error
{
    class ConfirmedPrivateTransferError : BaseError
    {
        public static readonly Map<VendorServiceKey, SequenceDefinition> vendorServiceResolutions = new HashMap<VendorServiceKey, SequenceDefinition>();

        private readonly UnsignedInteger vendorId;
        private readonly UnsignedInteger serviceNumber;
        private readonly Encodable errorParameters;

    public ConfirmedPrivateTransferError(byte choice, BACnetError error, UnsignedInteger vendorId,
            UnsignedInteger serviceNumber, BaseType errorParameters) : base(choice, error)
        {
            this.vendorId = vendorId;
            this.serviceNumber = serviceNumber;
            this.errorParameters = errorParameters;
        }

        public override void write(ByteStream queue)
        {
            queue.push(choice);
            write(queue, error, 0);
            write(queue, vendorId, 1);
            write(queue, serviceNumber, 2);
            writeOptional(queue, errorParameters, 3);
        }

        ConfirmedPrivateTransferError(byte choice, ByteStream queue) : base(choice, queue, 0) // throws BACnetException
        {
            vendorId = read(queue, typeof(UnsignedInteger), 1);
            serviceNumber = read(queue, typeof(UnsignedInteger), 2);
            errorParameters = readVendorSpecific(queue, vendorId, serviceNumber, vendorServiceResolutions, 3);
        }
    }
}
