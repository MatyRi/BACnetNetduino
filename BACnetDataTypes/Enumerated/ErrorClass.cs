namespace BACnetDataTypes.Enumerated
{
    public class ErrorClass : Primitive.Enumerated
    {
        public static readonly ErrorClass Device = new ErrorClass(0);
        public static readonly ErrorClass ObjectClass = new ErrorClass(1);
        public static readonly ErrorClass Property = new ErrorClass(2);
        public static readonly ErrorClass Resources = new ErrorClass(3);
        public static readonly ErrorClass Security = new ErrorClass(4);
        public static readonly ErrorClass Services = new ErrorClass(5);
        public static readonly ErrorClass Vt = new ErrorClass(6);
        public static readonly ErrorClass Communication = new ErrorClass(7);

        public static readonly ErrorClass[] All = { Device, ObjectClass, Property, Resources, Security, Services, Vt, Communication };

    public ErrorClass(uint value) : base(value) { }

    public ErrorClass(ByteStream queue) : base(queue) { }

    public override string ToString()
    {
        uint type = Value;
        if (type == Device.Value)
            return "Device";
        if (type == ObjectClass.Value)
            return "Object";
        if (type == Property.Value)
            return "Property";
        if (type == Resources.Value)
            return "Resources";
        if (type == Security.Value)
            return "Security";
        if (type == Services.Value)
            return "Services";
        if (type == Vt.Value)
            return "VT";
        if (type == Communication.Value)
            return "Communication";
        return "Unknown: " + type;
    }
}
}
