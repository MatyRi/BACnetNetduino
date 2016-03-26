namespace BACnetDataTypes.Enumerated
{
    public class EnableDisable : Primitive.Enumerated
    {
    public static readonly EnableDisable Enable = new EnableDisable(0);
    public static readonly EnableDisable Disable = new EnableDisable(1);
    public static readonly EnableDisable DisableInitiation = new EnableDisable(2);

    internal EnableDisable(uint value) : base(value) { }

    internal EnableDisable(ByteStream queue) : base(queue) { }
}
}
