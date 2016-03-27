using BACnetDataTypes.Primitive;

namespace BACnetServices.Objects
{
    public class RemoteObject
    {
        public RemoteObject(ObjectIdentifier oid)
        {
            ObjectIdentifier = oid;
        }

        public ObjectIdentifier ObjectIdentifier { get; }

        public string ObjectName { get; set; }

        public override string ToString() => ObjectIdentifier.ToString();
    }
}
