namespace BACnetDataTypes.Enumerated
{
    class Maintenance : Primitive.Enumerated
    {
        public static readonly Maintenance None = new Maintenance(0);
        public static readonly Maintenance PeriodicTest = new Maintenance(1);
        public static readonly Maintenance NeedServiceOperational = new Maintenance(2);
        public static readonly Maintenance NeedServiceInoperative = new Maintenance(3);

        public static readonly Maintenance[] All = {None, PeriodicTest, NeedServiceOperational, NeedServiceInoperative};

        public Maintenance(uint value) : base(value)
        {
        }

        public Maintenance(ByteStream queue) : base(queue)
        {
        }
    }
}
