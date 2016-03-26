namespace BACnetDataTypes.Primitive
{
    public class Real : Primitive
    {
        public static readonly byte TYPE_ID = 4;

        public Real(float value)
        {
            this.Value = value;
        }

        public float Value { get; }

        //
        // Reading and writing
        //
        public Real(ByteStream queue)
        {
            readTag(queue);
            Value = queue.ReadFloat();
        }


        protected override long Length => 4;

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => Value.ToString();
    }
}
