namespace BACnetDataTypes.Enumerated
{
    class Action : Primitive.Enumerated
    {
        public static readonly Action Direct = new Action(0);
        public static readonly Action Reverse = new Action(1);

        public static readonly Action[] All = {Direct, Reverse};

        public Action(uint value) : base(value)
        {
        }

        public Action(ByteStream queue) : base(queue)
        {
        }
    }
}
