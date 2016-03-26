using System.Collections;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class Recipient : BaseType
    {
        private readonly Choice _choice;

        private static readonly IList Classes = new ArrayList()
        {
            typeof (ObjectIdentifier),
            typeof (Address),
        };

        public Recipient(ObjectIdentifier device)
        {
            _choice = new Choice(0, device);
        }

        public Recipient(Address address)
        {
            _choice = new Choice(1, address);
        }

        public bool IsObjectIdentifier => _choice.ContextId == 0;

        public ObjectIdentifier ObjectIdentifier => (ObjectIdentifier)_choice.Data;

        public bool IsAddress => _choice.ContextId == 1;

        public Address Address => (Address)_choice.Data;

        /*public override void write(ByteQueue queue)
        {
            write(queue, choice);
        }*/

        public Recipient(ByteStream queue)
        {
            _choice = new Choice(queue, Classes);
        }
    }
}
