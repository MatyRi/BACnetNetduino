namespace BACnetDataTypes.Primitive
{
    class BDouble : Primitive
    {
        public static readonly byte TYPE_ID = 5;

        public BDouble(double value)
        {
            Value = value;
        }

        public double Value { get; }

        //
        // Reading and writing
        //
        public BDouble(ByteStream queue)
        {
            readTag(queue);
            Value = queue.ReadDouble();
        }

        protected override void WriteImpl(ByteStream queue)
        {
            // TODO java.lang.Double.doubleToLongBits(value)
            queue.WriteLong((long) Value);
        }

        protected override long Length { get; } = 8;

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => Value.ToString();
    }
}
