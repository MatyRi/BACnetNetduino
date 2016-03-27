using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Error
{
    internal class ChangeListError : BaseError
    {
        private readonly UnsignedInteger firstFailedElementNumber;

        public ChangeListError(byte choice, BACnetError error, UnsignedInteger firstFailedElementNumber) : base(choice, error)
        {
            this.firstFailedElementNumber = firstFailedElementNumber;
        }

        public override void write(ByteStream queue)
        {
            queue.WriteByte(choice);
            write(queue, Error, 0);
            write(queue, firstFailedElementNumber, 1);
        }

        internal ChangeListError(byte choice, ByteStream queue) : base(choice, queue, 0)
        {
            firstFailedElementNumber = (UnsignedInteger) read(queue, typeof(UnsignedInteger), 1);
        }
    }
}
