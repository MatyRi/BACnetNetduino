using BACnetDataTypes.Constructed;

namespace BACnetDataTypes.Error
{
    class WritePropertyMultipleError : BaseError
    {
        private readonly ObjectPropertyReference firstFailedWriteAttempt;

        public WritePropertyMultipleError(byte choice, BACnetError error, ObjectPropertyReference firstFailedWriteAttempt) : base(choice, error)
        {
            this.firstFailedWriteAttempt = firstFailedWriteAttempt;
        }

        public override void write(ByteStream queue)
        {
            queue.WriteByte(choice);
            write(queue, Error, 0);
            firstFailedWriteAttempt.write(queue, 1);
        }

        internal WritePropertyMultipleError(byte choice, ByteStream queue) : base(choice, queue, 0)
        {
            firstFailedWriteAttempt = (ObjectPropertyReference) read(queue, typeof(ObjectPropertyReference), 1);
        }
}
}
