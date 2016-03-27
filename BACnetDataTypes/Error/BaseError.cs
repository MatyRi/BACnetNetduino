using BACnetDataTypes.Constructed;

namespace BACnetDataTypes.Error
{
    public class BaseError : BaseType
    {
        public static BaseError createBaseError(ByteStream queue)
        {
            byte choice = queue.ReadByte();

            switch (choice)
            {
                case 8:
                case 9:
                    return new ChangeListError(choice, queue);
                case 10:
                    return new CreateObjectError(choice, queue);
                case 16:
                    return new WritePropertyMultipleError(choice, queue);
                case 18:
                    return new ConfirmedPrivateTransferError(choice, queue);
                case 22:
                    return new VTCloseError(choice, queue);
            }
            return new BaseError(choice, queue);
        }

        protected byte choice;

        public BaseError(byte choice, BACnetError error)
        {
            this.choice = choice;
            this.Error = error;
        }

        public override void write(ByteStream queue)
        {
            queue.WriteByte(choice);
            write(queue, Error);
        }

        public BaseError(byte choice, ByteStream queue) 
        {
            this.choice = choice;
            Error = (BACnetError) read(queue, typeof (BACnetError));
        }

        public BaseError(byte choice, ByteStream queue, int contextId)
        {
            this.choice = choice;
            Error = (BACnetError) read(queue, typeof(BACnetError), contextId);
        }

        public override string ToString() => "choice=" + (choice & 0xff) + ", " + Error;

        public BACnetError Error { get; }
    }
}
