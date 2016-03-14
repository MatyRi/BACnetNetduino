using System;
using System.Collections;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes
{
    class SequenceDefinition
    {
        private readonly IList elements;
        //private readonly List<ElementSpecification> elements;

        public SequenceDefinition(params ElementSpecification[] specs)
        {
            elements = new ArrayList();
            foreach (ElementSpecification spec in specs)
                elements.Add(spec);
        }

        public SequenceDefinition(IList elements)
        {
            this.elements = elements;
        }

        public IList getElements()
        {
            return elements;
        }

        public class ElementSpecification
        {
            private readonly string id;
            private readonly Type type;
            private readonly int contextId;
            private readonly bool sequenceOf;
            private readonly bool optional;

            public ElementSpecification(string id, Type type, bool sequenceOf, bool optional)
            {
                this.id = id;
                this.type = type;
                this.contextId = -1;
                this.sequenceOf = sequenceOf;
                this.optional = optional;
            }

            public ElementSpecification(string id, Type type, int contextId, bool sequenceOf, bool optional)
            {
                this.id = id;
                this.type = type;
                this.contextId = contextId;
                this.sequenceOf = sequenceOf;
                this.optional = optional;
            }

            public string getId()
            {
                return id;
            }

            public Type getType()
            {
                return type;
            }

            public int getContextId()
            {
                return contextId;
            }

            public bool isOptional()
            {
                return optional;
            }

            public bool isSequenceOf()
            {
                return sequenceOf;
            }

            public bool hasContextId()
            {
                return contextId != -1;
            }
        }
    }
}
