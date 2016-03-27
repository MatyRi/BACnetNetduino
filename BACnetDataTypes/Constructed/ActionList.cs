using System;
using Microsoft.SPOT;

namespace BACnetDataTypes.Constructed
{
    class ActionList : BaseType
    {
        public ActionList(SequenceOf action)
        {
            Actions = action;
        }

        public override void write(ByteStream queue)
        {
            write(queue, Actions, 0);
        }

        public ActionList(ByteStream queue)
        {
            Actions = readSequenceOf(queue, typeof (ActionCommand), 0);
        }

        public SequenceOf Actions { get; } //<ActionCommand>
    }
}
