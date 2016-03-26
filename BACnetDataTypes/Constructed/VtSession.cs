using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class VtSession : BaseType
    {

        public UnsignedInteger LocalVtSessionId { get; }
        public UnsignedInteger RemoteVtSessionId { get; }
        public Address RemoteVtAddress { get; }


        public VtSession(UnsignedInteger localVtSessionId, UnsignedInteger remoteVtSessionId, Address remoteVtAddress)
        {
            this.LocalVtSessionId = localVtSessionId;
            this.RemoteVtSessionId = remoteVtSessionId;
            this.RemoteVtAddress = remoteVtAddress;
        }

        /*public override void write(ByteStream queue)
        {
            write(queue, localVtSessionId);
            write(queue, remoteVtSessionId);
            write(queue, remoteVtAddress);
        }*/

        public VtSession(ByteStream queue)
        {
            LocalVtSessionId = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            RemoteVtSessionId = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            RemoteVtAddress = (Address) read(queue, typeof (Address));
        }


    }
}
