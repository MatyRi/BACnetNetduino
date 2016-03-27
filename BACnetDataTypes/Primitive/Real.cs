namespace BACnetDataTypes.Primitive
{
    public class Real : Primitive
    {
        public static readonly byte TYPE_ID = 4;

        public float Value { get; }

        public Real(float value)
        {
            Value = value;
        }


        //
        // Reading and writing
        //
        public Real(ByteStream queue)
        {
            readTag(queue);
            Value = queue.ReadFloat();
        }

        protected override void WriteImpl(ByteStream queue)
        {
            queue.WriteInt((int) Value);
            //BACnetUtils.pushInt(queue, Float.floatToIntBits(value));
        }

        protected override long Length => 4;

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => Value.ToString();
    }
}
