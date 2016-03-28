using System;
using System.Collections;

namespace BACnetDataTypes.Constructed
{
    public class Choice : BaseType
    {
        public int ContextId { get; }
        public Encodable Data { get; }

        public Choice(int contextId, Encodable data)
        {
            ContextId = contextId;
            Data = data;
        }

        public override void write(ByteStream queue)
        {
            write(queue, Data, ContextId);
        }

        public Choice(ByteStream queue, IList types)
        {
            Choice c = read(queue, types);
            ContextId = c.ContextId;
            Data = c.Data;
        }

        public Choice(ByteStream queue, IList types, int contextId)
        {
            popStart(queue, contextId);
            Choice c = read(queue, types);
            popEnd(queue, contextId);
            ContextId = c.ContextId;
            Data = c.Data;
        }

        private Choice read(ByteStream queue, IList types)
        {
            int tContextId = peekTagNumber(queue);
            Encodable tDatum = read(queue, (Type) types[tContextId], tContextId);
            return new Choice(tContextId, tDatum);
        }

        public override string ToString() => Data.ToString();
    }
}
