namespace BACnetDataTypes.Enumerated
{
    class DoorSecuredStatus : Primitive.Enumerated
    {
        public static readonly DoorSecuredStatus Secured = new DoorSecuredStatus(0);
        public static readonly DoorSecuredStatus Unsecured = new DoorSecuredStatus(1);
        public static readonly DoorSecuredStatus Unknown = new DoorSecuredStatus(2);

        public static readonly DoorSecuredStatus[] All = {Secured, Unsecured, Unknown};

        public DoorSecuredStatus(uint value) : base(value)
        {
        }

        public DoorSecuredStatus(ByteStream queue) : base(queue)
        {
        }
    }
}
