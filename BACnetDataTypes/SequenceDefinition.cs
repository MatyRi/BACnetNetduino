using System;
using System.Collections;

namespace BACnetDataTypes
{
    public class SequenceDefinition
    {
        //private readonly List<ElementSpecification> elements;

        public SequenceDefinition(params ElementSpecification[] specs)
        {
            Elements = new ArrayList();
            foreach (ElementSpecification spec in specs)
                Elements.Add(spec);
        }

        public SequenceDefinition(IList elements)
        {
            Elements = elements;
        }

        public IList Elements { get; }

        public class ElementSpecification
        {
            public ElementSpecification(string id, Type type, bool sequenceOf, bool optional)
            {
                Id = id;
                Type = type;
                ContextId = -1;
                IsSequenceOf = sequenceOf;
                IsOptional = optional;
            }

            public ElementSpecification(string id, Type type, int contextId, bool sequenceOf, bool optional)
            {
                Id = id;
                Type = type;
                ContextId = contextId;
                IsSequenceOf = sequenceOf;
                IsOptional = optional;
            }

            public string Id { get; }

            public Type Type { get; }

            public int ContextId { get; }

            public bool IsOptional { get; }

            public bool IsSequenceOf { get; }

            public bool HasContextId => ContextId != -1;
        }
    }
}
