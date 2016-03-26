using BACnetDataTypes.Primitive;

namespace BACnetServices.Objects
{
    public class RemoteObject
    {
        private readonly ObjectIdentifier _oid;

        public RemoteObject(ObjectIdentifier oid)
        {
            _oid = oid;
        }

        public ObjectIdentifier ObjectIdentifier => _oid;

        public string ObjectName { get; set; }

        public override string ToString()
        {
            return _oid.ToString();
        }
    }
}
