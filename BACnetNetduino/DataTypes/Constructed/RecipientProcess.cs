using System;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class RecipientProcess : BaseType
    {
        private readonly Recipient recipient;
        private readonly UnsignedInteger processIdentifier;

        public RecipientProcess(Recipient recipient, UnsignedInteger processIdentifier)
        {
            this.recipient = recipient;
            this.processIdentifier = processIdentifier;
        }

        /*public override void write(ByteStream queue)
        {
            write(queue, recipient, 0);
            write(queue, processIdentifier, 1);
        }*/

        public RecipientProcess(ByteStream queue)
        {
            recipient = (Recipient) read(queue, typeof(Recipient), 0);
            processIdentifier = (UnsignedInteger) read(queue, typeof(UnsignedInteger), 1);
        }

        public Recipient getRecipient()
        {
            return recipient;
        }

        public UnsignedInteger getProcessIdentifier()
        {
            return processIdentifier;
        }
    }
}
