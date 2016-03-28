using System;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.Constructed
{
    public class ResultFlags : BitString
    {
        public ResultFlags(bool firstItem, bool lastItem, bool moreItems) : base (new[] { firstItem, lastItem, moreItems }) { }

        public ResultFlags(ByteStream queue): base(queue) { }

        public bool IsFirstItem => Value[0];

        public bool IsLastItem => Value[1];

        public bool IsMoreItems => Value[2];
    }
}
