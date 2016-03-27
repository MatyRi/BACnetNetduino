namespace BACnetDataTypes.Primitive
{
    public class Enumerated : UnsignedInteger
    {
        public static readonly byte TYPE_ID = 9;

        public Enumerated(uint value) : base(value) { }

        //public Enumerated(Decimal value) : base(value) { }

        //public virtual byte Value => (byte) base.Value;

        public bool Equals(Enumerated that)
        {
            //AdK
            if (that == null) return false;
            return Value == that.Value;
        }

        //
        // Reading and writing
        //
        public Enumerated(ByteStream queue) : base(queue) { }

        protected override byte TypeId => TYPE_ID;
    }
}
