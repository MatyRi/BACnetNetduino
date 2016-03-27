namespace BACnetDataTypes.Enumerated
{
    class DoorStatus : Primitive.Enumerated
    {
        public static readonly DoorStatus Closed = new DoorStatus(0);
        public static readonly DoorStatus Open = new DoorStatus(1);
        public static readonly DoorStatus Unknown = new DoorStatus(2);

        public static readonly DoorStatus[] All = {Closed, Open, Unknown};

        public DoorStatus(uint value) : base(value)
        {
        }

        public DoorStatus(ByteStream queue) : base(queue)
        {
        }
    }
}
