using System;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class CovSubscription : BaseType
    {
        public RecipientProcess Recipient { get; }
        public ObjectPropertyReference MonitoredPropertyReference { get; }
        public BBoolean IssueConfirmedNotifications { get; }
        public UnsignedInteger TimeRemaining { get; }
        public Real CovIncrement { get; }

        public CovSubscription(RecipientProcess recipient, ObjectPropertyReference monitoredPropertyReference,
            BBoolean issueConfirmedNotifications, UnsignedInteger timeRemaining, Real covIncrement)
        {
            this.Recipient = recipient;
            this.MonitoredPropertyReference = monitoredPropertyReference;
            this.IssueConfirmedNotifications = issueConfirmedNotifications;
            this.TimeRemaining = timeRemaining;
            this.CovIncrement = covIncrement;
        }

        public override void write(ByteStream queue)
        {
            throw new NotImplementedException();
            /*write(queue, recipient, 0);
            write(queue, monitoredPropertyReference, 1);
            write(queue, issueConfirmedNotifications, 2);
            write(queue, timeRemaining, 3);
            writeOptional(queue, covIncrement, 4);*/
        }

        public CovSubscription(ByteStream queue)
        {
            Recipient = (RecipientProcess) read(queue, typeof (RecipientProcess), 0);
            MonitoredPropertyReference = (ObjectPropertyReference) read(queue, typeof (ObjectPropertyReference), 1);
            IssueConfirmedNotifications = (BBoolean) read(queue, typeof (BBoolean), 2);
            TimeRemaining = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 3);
            // TODO covIncrement = readOptional(queue, typeof(Real), 4);
        }


    }
}
