namespace BACnetDataTypes.Enumerated
{
    class LockStatus : Primitive.Enumerated
    {
        public static readonly LockStatus Locked = new LockStatus(0);
        public static readonly LockStatus Unlocked = new LockStatus(1);
        public static readonly LockStatus Fault = new LockStatus(2);
        public static readonly LockStatus Unknown = new LockStatus(3);

        public static readonly LockStatus[] All = {Locked, Unlocked, Fault, Unknown};

        public LockStatus(uint value) : base(value)
        {
        }

        public LockStatus(ByteStream queue) : base(queue)
        {
        }
    }
}
