namespace BACnetDataTypes.Enumerated
{
    public class VtClass : Primitive.Enumerated
    {
        public static readonly VtClass DefaultTerminal = new VtClass(0);
        public static readonly VtClass AnsiX364 = new VtClass(1);
        public static readonly VtClass DecVt52 = new VtClass(2);
        public static readonly VtClass DecVt100 = new VtClass(3);
        public static readonly VtClass DecVt220 = new VtClass(4);
        public static readonly VtClass Hp70094 = new VtClass(5);
        public static readonly VtClass Ibm3130 = new VtClass(6);

        public static readonly VtClass[] All = { DefaultTerminal, AnsiX364, DecVt52, DecVt100, DecVt220, Hp70094, Ibm3130, };

    public VtClass(uint value) : base(value) { }

    public VtClass(ByteStream queue) : base(queue) { }
}
}
