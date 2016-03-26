using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using BACnetServices.Objects;

namespace BACnetServices.Service.Unconfirmed
{
    class IHaveRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 1;

        private readonly ObjectIdentifier deviceIdentifier;
    private readonly ObjectIdentifier objectIdentifier;
    private readonly CharacterString objectName;

        public IHaveRequest(ObjectIdentifier deviceIdentifier, ObjectIdentifier objectIdentifier, CharacterString objectName)
        {
            this.deviceIdentifier = deviceIdentifier;
            this.objectIdentifier = objectIdentifier;
            this.objectName = objectName;
        }

        
        public override byte getChoiceId()
        {
            return TYPE_ID;
        }

        
        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            // TODO RemoteDevice d = localDevice.getRemoteDeviceCreate(deviceIdentifier.getInstanceNumber(), from, linkService);
            RemoteObject o = new RemoteObject(objectIdentifier);
            o.ObjectName = objectName.ToString();
            // TODO d.setObject(o);

            // TODO localDevice.getEventHandler().fireIHaveReceived(d, o);
        }

        
        public override void write(ByteStream queue)
        {
            write(queue, deviceIdentifier);
            write(queue, objectIdentifier);
            write(queue, objectName);
        }

        public IHaveRequest(ByteStream queue)
        {
            deviceIdentifier = (ObjectIdentifier) read(queue, typeof(ObjectIdentifier));
        objectIdentifier = (ObjectIdentifier) read(queue, typeof(ObjectIdentifier));
        objectName = (CharacterString) read(queue, typeof(CharacterString));
    }
}
}
