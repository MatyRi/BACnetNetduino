using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class SessionKey : BaseType
    {
        private readonly OctetString sessionKey;
    private readonly Address peerAddress;

    public SessionKey(OctetString sessionKey, Address peerAddress)
        {
            this.sessionKey = sessionKey;
            this.peerAddress = peerAddress;
        }

        /*public override void write(ByteStream queue)
        {
            write(queue, sessionKey);
            write(queue, peerAddress);
        }*/

        public SessionKey(ByteStream queue)
        {
            sessionKey = (OctetString) read(queue, typeof(OctetString));
           peerAddress = (Address) read(queue, typeof(Address));
    }

    public OctetString getSessionKey()
    {
        return sessionKey;
    }

    public Address getPeerAddress()
    {
        return peerAddress;
    }
}
}
