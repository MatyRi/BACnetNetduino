using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class VtSession : BaseType
    {
        private readonly UnsignedInteger localVtSessionId;
        private readonly UnsignedInteger remoteVtSessionId;
        private readonly Address remoteVtAddress;

        public VtSession(UnsignedInteger localVtSessionId, UnsignedInteger remoteVtSessionId, Address remoteVtAddress)
        {
            this.localVtSessionId = localVtSessionId;
            this.remoteVtSessionId = remoteVtSessionId;
            this.remoteVtAddress = remoteVtAddress;
        }

        /*public override void write(ByteStream queue)
        {
            write(queue, localVtSessionId);
            write(queue, remoteVtSessionId);
            write(queue, remoteVtAddress);
        }*/

        public VtSession(ByteStream queue)
        {
            localVtSessionId = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            remoteVtSessionId = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            remoteVtAddress = (Address) read(queue, typeof (Address));
        }

        public UnsignedInteger getLocalVtSessionId()
        {
            return localVtSessionId;
        }

        public UnsignedInteger getRemoteVtSessionId()
        {
            return remoteVtSessionId;
        }

        public Address getRemoteVtAddress()
        {
            return remoteVtAddress;
        }
    }
}
