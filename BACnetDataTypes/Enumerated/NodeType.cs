namespace BACnetDataTypes.Enumerated
{
    class NodeType : Primitive.Enumerated
    {
        public static readonly NodeType Unknown = new NodeType(0);
        public static readonly NodeType System = new NodeType(1);
        public static readonly NodeType Network = new NodeType(2);
        public static readonly NodeType Device = new NodeType(3);
        public static readonly NodeType Organizational = new NodeType(4);
        public static readonly NodeType Area = new NodeType(5);
        public static readonly NodeType Equipment = new NodeType(6);
        public static readonly NodeType Point = new NodeType(7);
        public static readonly NodeType Collection = new NodeType(8);
        public static readonly NodeType Property = new NodeType(9);
        public static readonly NodeType Functional = new NodeType(10);
        public static readonly NodeType Other = new NodeType(11);

        public static readonly NodeType[] All =
        {
            Unknown, System, Network, Device, Organizational, Area, Equipment, Point,
            Collection, Property, Functional, Other
        };

        public NodeType(uint value) : base(value)
        {
        }

        public NodeType(ByteStream queue) : base(queue)
        {
        }
    }
}
