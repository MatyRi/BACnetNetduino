namespace BACnetDataTypes.Enumerated
{
    public class EnableDisable : Primitive.Enumerated
    {
    public static readonly EnableDisable enable = new EnableDisable(0);
    public static readonly EnableDisable disable = new EnableDisable(1);
    public static readonly EnableDisable disableInitiation = new EnableDisable(2);

    internal EnableDisable(uint value) : base(value) { }

    internal EnableDisable(ByteStream queue) : base(queue) { }
}
}
