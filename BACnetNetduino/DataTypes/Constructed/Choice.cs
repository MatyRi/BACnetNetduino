using System;
using System.Collections;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class Choice : BaseType
    {
        private readonly int contextId;
        private readonly Encodable datum;

        public Choice(int contextId, Encodable datum)
        {
            this.contextId = contextId;
            this.datum = datum;
        }

        public int ContextId => contextId;

        public Encodable Datum => datum;

        /*public override void write(ByteStream queue)
        {
            write(queue, datum, contextId);
        }*/

        public Choice(ByteStream queue, IList types)
        {
            Choice c = (Choice) read(queue, types);
            this.contextId = c.contextId;
            this.datum = c.datum;
        }

        public Choice(ByteStream queue, IList types, int contextId)
        {
            popStart(queue, contextId);
            Choice c = read(queue, types);
            popEnd(queue, contextId);
            this.contextId = c.contextId;
            this.datum = c.datum;
        }

        private Choice read(ByteStream queue, IList types)
        {
            int tContextId = peekTagNumber(queue);
            Encodable tDatum = read(queue, (Type) types[tContextId], tContextId);
            return new Choice(tContextId, tDatum);
        }
    }
}
