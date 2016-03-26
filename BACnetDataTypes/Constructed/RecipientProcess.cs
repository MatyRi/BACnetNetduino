using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class RecipientProcess : BaseType
    {
        public Recipient Recipient { get; }
        public UnsignedInteger ProcessIdentifier { get; }

        public RecipientProcess(Recipient recipient, UnsignedInteger processIdentifier)
        {
            this.Recipient = recipient;
            this.ProcessIdentifier = processIdentifier;
        }

        /*public override void write(ByteStream queue)
        {
            write(queue, recipient, 0);
            write(queue, processIdentifier, 1);
        }*/

        public RecipientProcess(ByteStream queue)
        {
            Recipient = (Recipient) read(queue, typeof(Recipient), 0);
            ProcessIdentifier = (UnsignedInteger) read(queue, typeof(UnsignedInteger), 1);
        }

    }
}
