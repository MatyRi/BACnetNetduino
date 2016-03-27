using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    class StatusFlags : BitString
    {
        public StatusFlags(bool inAlarm, bool fault, bool overridden, bool outOfService):
            base(new[] { inAlarm, fault, overridden, outOfService })
        { }

        public StatusFlags(ByteStream queue) : base(queue)
        { }

        public bool InAlarm
        {
            get { return Value[0]; }
            set { Value[0] = value; }
        }

        public bool Fault
        {
            get { return Value[1]; }
            set { Value[1] = value; }
        }

        public bool Overriden
        {
            get { return Value[2]; }
            set { Value[2] = value; }
        }

        public bool OutOfService
        {
            get { return Value[3]; }
            set { Value[3] = value; }
        }
    }
}
