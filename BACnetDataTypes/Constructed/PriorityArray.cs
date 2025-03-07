using System.Collections;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class PriorityArray : SequenceOf
    {
        private static readonly int LENGTH = 16;

        public PriorityArray() : base(new ArrayList())
        {
            EnsureLength();
        }

        public PriorityArray(IList priorityValues) : base(priorityValues)
        {
            EnsureLength();
        }

        public PriorityArray(ByteStream queue, int contextId) : base(queue, typeof (PriorityValue), contextId)
        {
            EnsureLength();
        }

        private void EnsureLength()
        {
            while (getCount() < LENGTH)
                add(new PriorityValue(new Null()));
            while (getCount() > LENGTH)
                remove(getCount());
        }

        public /*override*/ void set(int indexBase1, PriorityValue value)
        {
            if (indexBase1 < 1 || indexBase1 > LENGTH)
                throw new System.Exception("Invalid priority value");
            if (value == null)
                value = new PriorityValue(new Null());
            base.set(indexBase1, value);
        }

        /*public override void add(PriorityValue value)
    {
        throw new System.Exception("Use set method instead");
    }

    public override void remove(int indexBase1)
    {
        throw new System.Exception("Use set method instead");
    }

    public override void remove(PriorityValue value)
    {
        throw new System.Exception("Use set method instead");
    }

    public override void removeAll(PriorityValue value)
    {
        throw new System.Exception("Use set method instead");
    }*/
    }
}
