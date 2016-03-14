using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    internal abstract class BaseType : Encodable
    {
        public override void write(ByteStream queue, int contextId)
        {
            // Write a start tag
            writeContextTag(queue, contextId, true);
            write(queue);
            // Write an end tag
            writeContextTag(queue, contextId, false);
        }
    }
}
