using System;
using Microsoft.SPOT;

namespace BACnetDataTypes.Enumerated
{
    class SilencedState : Primitive.Enumerated
    {
        public static readonly SilencedState Unsilenced = new SilencedState(0);
        public static readonly SilencedState AudibleSilenced = new SilencedState(1);
        public static readonly SilencedState VisibleSilenced = new SilencedState(2);
        public static readonly SilencedState AllSilenced = new SilencedState(3);

        public static readonly SilencedState[] All = { Unsilenced, AudibleSilenced, VisibleSilenced, AllSilenced, };

    public SilencedState(uint value) : base(value) { }

    public SilencedState(ByteStream queue) : base(queue) { }
}
}
