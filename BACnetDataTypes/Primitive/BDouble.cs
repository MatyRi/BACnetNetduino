namespace BACnetDataTypes.Primitive
{
    class BDouble : Primitive
    {
        public static readonly byte TYPE_ID = 5;

        public BDouble(double value)
        {
            this.Value = value;
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


        /*public override void writeImpl(ByteStream queue)
        {
            BACnetUtils.pushLong(queue, java.lang.Double.doubleToLongBits(value));
        }*/


        protected override long Length { get; } = 8;

        protected override byte TypeId => TYPE_ID;


        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
