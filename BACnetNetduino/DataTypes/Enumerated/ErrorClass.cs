using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Enumerated
{
    class ErrorClass : Primitive.Enumerated
    {
        public static readonly ErrorClass device = new ErrorClass(0);
        public static readonly ErrorClass objectClass = new ErrorClass(1);
        public static readonly ErrorClass property = new ErrorClass(2);
        public static readonly ErrorClass resources = new ErrorClass(3);
        public static readonly ErrorClass security = new ErrorClass(4);
        public static readonly ErrorClass services = new ErrorClass(5);
        public static readonly ErrorClass vt = new ErrorClass(6);
        public static readonly ErrorClass communication = new ErrorClass(7);

        public static readonly ErrorClass[] ALL = { device, objectClass, property, resources, security, services, vt, communication, };

    public ErrorClass(uint value) : base(value) { }

    public ErrorClass(ByteStream queue) : base(queue) { }

    public override string ToString()
    {
        uint type = intValue();
        if (type == device.intValue())
            return "Device";
        if (type == objectClass.intValue())
            return "Object";
        if (type == property.intValue())
            return "Property";
        if (type == resources.intValue())
            return "Resources";
        if (type == security.intValue())
            return "Security";
        if (type == services.intValue())
            return "Services";
        if (type == vt.intValue())
            return "VT";
        if (type == communication.intValue())
            return "Communication";
        return "Unknown: " + type;
    }
}
}
