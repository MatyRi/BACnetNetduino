namespace BACnetDataTypes.Enumerated
{
    class MessagePriority : Primitive.Enumerated
    {
        public static readonly MessagePriority Normal = new MessagePriority(0);
        public static readonly MessagePriority Urgent = new MessagePriority(1);

        public static readonly MessagePriority[] All = {Normal, Urgent};

        public MessagePriority(uint value) : base(value)
        {
        }

        public MessagePriority(ByteStream queue) : base(queue)
        {
        }
    }
}
