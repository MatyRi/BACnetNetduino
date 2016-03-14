using System;
using System.Collections;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class Recipient : BaseType
    {
        private readonly Choice choice;

        private static IList classes = new ArrayList()
        {
            typeof (ObjectIdentifier),
            typeof (Address),
        };

        public Recipient(ObjectIdentifier device)
        {
            choice = new Choice(0, device);
        }

        public Recipient(Address address)
        {
            choice = new Choice(1, address);
        }

        public bool isObjectIdentifier()
        {
            return choice.ContextId == 0;
        }

        public ObjectIdentifier getObjectIdentifier()
        {
            return (ObjectIdentifier) choice.Datum;
        }

        public bool isAddress()
        {
            return choice.ContextId == 1;
        }

        public Address getAddress()
        {
            return (Address) choice.Datum;
        }

        /*public override void write(ByteQueue queue)
        {
            write(queue, choice);
        }*/

        public Recipient(ByteStream queue)
        {
            choice = new Choice(queue, classes);
        }
    }
}
