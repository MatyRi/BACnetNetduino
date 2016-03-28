using System;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.Constructed
{
    public class EventTransitionBits : BitString
    {
        public EventTransitionBits(bool toOffnormal, bool toFault, bool toNormal) : base(new[] { toOffnormal, toFault, toNormal }) { }

        public EventTransitionBits(ByteStream queue) : base(queue) { }

        public bool IsToOffnormal => Value[0];

        public bool IsToFault => Value[1];

        public bool IsToNormal => Value[2];

        public bool Contains(EventState toState)
        {
            if (toState.Equals(EventState.Normal) && IsToNormal)
                return true;

            if (toState.Equals(EventState.Fault) && IsToFault)
                return true;

            // All other event states are considered off-normal
            return IsToOffnormal;
        }
    }
}
