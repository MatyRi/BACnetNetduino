namespace BACnetDataTypes.Primitive
{
    public class Enumerated : UnsignedInteger
    {
        public static readonly byte TYPE_ID = 9;

        public Enumerated(uint value) : base(value) { }

        //public Enumerated(BitArray value) : base(value) { }

        public byte Value => (byte) base.Value;

        /*public bool equals(Enumerated that)
        {
            //AdK
            if (that == null) return false;
            return intValue() == that.intValue();
        }*/

        //
        // Reading and writing
        //
        public Enumerated(ByteStream queue) : base(queue) { }

        protected override byte TypeId => TYPE_ID;
    }
}
