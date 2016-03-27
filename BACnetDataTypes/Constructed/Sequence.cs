using System;
using System.Collections;
using Microsoft.SPOT;

namespace BACnetDataTypes.Constructed
{
    public class Sequence : BaseType
    {
        public Sequence(SequenceDefinition definition, Hashtable values)
        {
            this.Definition = definition;
            this.Values = values;
        }

    public override void write(ByteStream queue)
        {
            IList specs = Definition.Elements;
            foreach (SequenceDefinition.ElementSpecification spec in specs)
            {
                if (spec.IsOptional)
                {
                    if (spec.HasContextId)
                        writeOptional(queue, (Encodable) Values[spec.Id], spec.ContextId);
                    else
                        writeOptional(queue, (Encodable) Values[spec.Id]);
                }
                else {
                    if (spec.HasContextId)
                        write(queue, (Encodable) Values[spec.Id], spec.ContextId);
                    else
                        write(queue, (Encodable) Values[spec.Id]);
                }
            }
        }

        public Sequence(SequenceDefinition definition, ByteStream queue, int contextId)
        :
        this(definition, popStart0(queue, contextId))
        {
            Encodable.popEnd(queue, contextId);
        }

        // The constructor call must be the first statement in the constructor (a nuisance of a rule), so this static 
        // method is required as a workaround. Ugly, but it works.
        private static ByteStream popStart0(ByteStream queue, int contextId)
        {
            popStart(queue, contextId);
            return queue;
        }

        public Sequence(SequenceDefinition definition, ByteStream queue)
        {
        this.Definition = definition;
            Values = new Hashtable();
        IList specs = definition.Elements;
        for (int i = 0; i<specs.Count; i++) {
            SequenceDefinition.ElementSpecification spec = (SequenceDefinition.ElementSpecification) specs[i];
            if (spec.IsSequenceOf) {
                if (spec.IsOptional)
                    Values[spec.Id] = readOptionalSequenceOf(queue, spec.Type, spec.ContextId);
                else {
                    if (spec.HasContextId)
                        Values[spec.Id] = readSequenceOf(queue, spec.Type, spec.ContextId);
                    else
                        Values[spec.Id] = readSequenceOf(queue, spec.Type);
                }
}
            else if (spec.IsOptional)
                Values[spec.Id] = readOptional(queue, spec.Type, spec.ContextId);
            else if (spec.HasContextId)
                Values[spec.Id] = read(queue, spec.Type, spec.ContextId);
            else
                Values[spec.Id] = read(queue, spec.Type);
        }
    }

        public SequenceDefinition Definition { get; }

        public Hashtable Values { get; }
    }
}
