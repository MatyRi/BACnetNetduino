using System;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class CovSubscription : BaseType
    {
        private readonly RecipientProcess recipient;
        private readonly ObjectPropertyReference monitoredPropertyReference;
        private readonly BBoolean issueConfirmedNotifications;
        private readonly UnsignedInteger timeRemaining;
        private readonly Real covIncrement;

        public CovSubscription(RecipientProcess recipient, ObjectPropertyReference monitoredPropertyReference,
            BBoolean issueConfirmedNotifications, UnsignedInteger timeRemaining, Real covIncrement)
        {
            this.recipient = recipient;
            this.monitoredPropertyReference = monitoredPropertyReference;
            this.issueConfirmedNotifications = issueConfirmedNotifications;
            this.timeRemaining = timeRemaining;
            this.covIncrement = covIncrement;
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
            recipient = (RecipientProcess) read(queue, typeof (RecipientProcess), 0);
            monitoredPropertyReference = (ObjectPropertyReference) read(queue, typeof (ObjectPropertyReference), 1);
            issueConfirmedNotifications = (BBoolean) read(queue, typeof (BBoolean), 2);
            timeRemaining = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 3);
            // TODO covIncrement = readOptional(queue, typeof(Real), 4);
        }

        public RecipientProcess Recipient => recipient;

        public ObjectPropertyReference MonitoredPropertyReference => monitoredPropertyReference;

        public BBoolean IssueConfirmedNotifications => issueConfirmedNotifications;

        public UnsignedInteger TimeRemaining => timeRemaining;

        public Real CovIncrement => covIncrement;
    }
}
