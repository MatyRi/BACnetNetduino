using BACnetDataTypes.Constructed;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Error
{

    internal class CreateObjectError : BaseError
    {
        private readonly UnsignedInteger firstFailedElementNumber;

        public CreateObjectError(byte choice, BACnetError error, UnsignedInteger firstFailedElementNumber) : base(choice, error)
        {
            this.firstFailedElementNumber = firstFailedElementNumber;
        }

        public CreateObjectError(byte choice, BACnetServiceException e, UnsignedInteger firstFailedElementNumber) : base(choice, new BACnetError(e))
        { 
            this.firstFailedElementNumber = firstFailedElementNumber;
        }

        public override void write(ByteStream queue)
        {
            queue.WriteByte(choice);
            write(queue, Error, 0);
            firstFailedElementNumber.write(queue, 1);
        }

        internal CreateObjectError(byte choice, ByteStream queue) : base(choice, queue, 0)
        {
            firstFailedElementNumber = (UnsignedInteger) read(queue, typeof(UnsignedInteger), 1);
        }
    }
}
