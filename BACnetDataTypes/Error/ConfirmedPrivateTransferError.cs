using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Error
{
    class ConfirmedPrivateTransferError : BaseError
    {
        // TODO public static readonly Map<VendorServiceKey, SequenceDefinition> vendorServiceResolutions = new HashMap<VendorServiceKey, SequenceDefinition>();

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

        /*public override void write(ByteStream queue)
        {
            queue.push(choice);
            write(queue, error, 0);
            write(queue, vendorId, 1);
            write(queue, serviceNumber, 2);
            writeOptional(queue, errorParameters, 3);
        }*/

        internal ConfirmedPrivateTransferError(byte choice, ByteStream queue) : base(choice, queue, 0) // throws BACnetException
        {
            // TODO vendorId = read(queue, typeof(UnsignedInteger), 1);
            // TODO  serviceNumber = read(queue, typeof(UnsignedInteger), 2);
            // TODO errorParameters = readVendorSpecific(queue, vendorId, serviceNumber, vendorServiceResolutions, 3);
        }
    }
}
