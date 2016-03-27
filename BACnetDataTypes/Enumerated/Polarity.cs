namespace BACnetDataTypes.Enumerated
{
    class Polarity : Primitive.Enumerated
    {
        public static readonly Polarity Normal = new Polarity(0);
        public static readonly Polarity Reverse = new Polarity(1);

        public static readonly Polarity[] All = {Normal, Reverse};

        public Polarity(uint value) : base(value)
        {
        }

        public Polarity(ByteStream queue) : base(queue)
        {
        }
    }
}
