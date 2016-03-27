using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Error
{
    class VTCloseError : BaseError
    {
        private readonly SequenceOf listOfVTSessionIdentifiers; // UnsignedInteger

        public VTCloseError(byte choice, BACnetError error, SequenceOf listOfVTSessionIdentifiers) : base(choice, error)
        {
            this.listOfVTSessionIdentifiers = listOfVTSessionIdentifiers;
        }

        public override void write(ByteStream queue)
        {
            queue.WriteByte(choice);
            write(queue, Error, 0);
            writeOptional(queue, listOfVTSessionIdentifiers, 1);
        }

        internal VTCloseError(byte choice, ByteStream queue) : base(choice, queue, 0)
        {
            listOfVTSessionIdentifiers = readOptionalSequenceOf(queue, typeof(UnsignedInteger), 1);
        }
    }
}
