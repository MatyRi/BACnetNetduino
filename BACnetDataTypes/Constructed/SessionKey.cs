using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class SessionKey : BaseType
    {
        public OctetString SessionKeyValue { get; }
        public Address PeerAddress { get; }

        public SessionKey(OctetString sessionKey, Address peerAddress)
        {
            this.SessionKeyValue = sessionKey;
            this.PeerAddress = peerAddress;
        }

        /*public override void write(ByteStream queue)
        {
            write(queue, sessionKey);
            write(queue, peerAddress);
        }*/

        public SessionKey(ByteStream queue)
        {
            SessionKeyValue = (OctetString) read(queue, typeof(OctetString));
           PeerAddress = (Address) read(queue, typeof(Address));
    }


    }
}
