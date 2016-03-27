using System;
using BACnetDataTypes.Constructed;
using Microsoft.SPOT;

namespace BACnetDataTypes.NotificationParameter
{
    class CommandFailure : NotificationParameters
    {
        public static readonly byte TYPE_ID = 3;

        public CommandFailure(Encodable commandValue, StatusFlags statusFlags, Encodable feedbackValue)
        {
            CommandValue = commandValue;
            StatusFlags = statusFlags;
            FeedbackValue = feedbackValue;
        }

        protected override void WriteImpl(ByteStream queue)
        {
            writeEncodable(queue, CommandValue, 0);
            write(queue, StatusFlags, 1);
            writeEncodable(queue, FeedbackValue, 2);
        }

        public CommandFailure(ByteStream queue)
        {
            CommandValue = new AmbiguousValue(queue, 0);
            StatusFlags = (StatusFlags) read(queue, typeof (StatusFlags), 1);
            FeedbackValue = new AmbiguousValue(queue, 2);
        }

        protected override int TypeId => TYPE_ID;

        public Encodable CommandValue { get; }

        public StatusFlags StatusFlags { get; }

        public Encodable FeedbackValue { get; }
    }
}
