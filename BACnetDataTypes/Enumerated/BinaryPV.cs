namespace BACnetDataTypes.Enumerated
{
    public class BinaryPV : Primitive.Enumerated
    {
        public static readonly BinaryPV Inactive = new BinaryPV(0);
        public static readonly BinaryPV Active = new BinaryPV(1);

        public static readonly BinaryPV[] All = { Inactive, Active, };

    public BinaryPV(uint value) : base(value) { }

    public BinaryPV(ByteStream queue) : base(queue) { }
}
}
