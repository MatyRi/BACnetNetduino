using System.Collections;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Error
{
    class ConfirmedPrivateTransferError : BaseError
    {
        //Map<VendorServiceKey, SequenceDefinition>
        public static readonly Hashtable vendorServiceResolutions = new Hashtable();

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
            queue.WriteByte(choice);
            write(queue, Error, 0);
            write(queue, vendorId, 1);
            write(queue, serviceNumber, 2);
            writeOptional(queue, errorParameters, 3);
        }

        internal ConfirmedPrivateTransferError(byte choice, ByteStream queue) : base(choice, queue, 0)
        {
            vendorId = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 1);
            serviceNumber = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 2);
            errorParameters = readVendorSpecific(queue, vendorId, serviceNumber, vendorServiceResolutions, 3);
        }
    }
}
