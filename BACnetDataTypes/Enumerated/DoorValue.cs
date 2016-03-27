namespace BACnetDataTypes.Enumerated
{
    class DoorValue : Primitive.Enumerated
    {
        public static readonly DoorValue Lock = new DoorValue(0);
        public static readonly DoorValue Unlock = new DoorValue(1);
        public static readonly DoorValue PulseUnlock = new DoorValue(2);
        public static readonly DoorValue ExtendedPulseUnlock = new DoorValue(3);

        public static readonly DoorValue[] All = {Lock, Unlock, PulseUnlock, ExtendedPulseUnlock};

        public DoorValue(uint value) : base(value)
        {
        }

        public DoorValue(ByteStream queue) : base(queue)
        {
        }
    }
}
