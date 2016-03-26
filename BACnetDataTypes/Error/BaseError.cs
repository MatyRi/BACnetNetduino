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
        protected BACnetError error;

        public BaseError(byte choice, BACnetError error)
        {
            this.choice = choice;
            this.error = error;
        }

        /*public override void write(ByteStream queue)
        {
            queue.push(choice);
            write(queue, error);
        }*/

        public BaseError(byte choice, ByteStream queue) // throws BACnetException
        {
            this.choice = choice;
            error = new BACnetError(queue);
        }

        public BaseError(byte choice, ByteStream queue, int contextId) // throws BACnetException
        {
            this.choice = choice;
            error = new BACnetError(queue);
        }

        public override string ToString()
        {
            return "choice=" + (choice & 0xff) + ", " + error;
        }

        public BACnetError getError()
        {
            return error;
        }
    }
}
