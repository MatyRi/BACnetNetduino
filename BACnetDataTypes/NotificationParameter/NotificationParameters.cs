using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;

namespace BACnetDataTypes.NotificationParameter
{
    public abstract class NotificationParameters : BaseType
    {
        public static NotificationParameters createNotificationParameters(ByteStream queue, int contextId)
        {
            popStart(queue, contextId);
            NotificationParameters result = createNotificationParameters(queue);
            popEnd(queue, contextId);
            return result;
        }

        public static NotificationParameters createNotificationParametersOptional(ByteStream queue, int contextId)
        {
            if (readStart(queue) != contextId)
                return null;
            return createNotificationParameters(queue, contextId);
        }

        public static NotificationParameters createNotificationParameters(ByteStream queue)
        {
            // Get the first byte. It will tell us what the service type is.
            int type = popStart(queue);

            NotificationParameters result;
            if (type == ChangeOfBitString.TYPE_ID) // 0
                result = new ChangeOfBitString(queue);
            else if (type == ChangeOfState.TYPE_ID) // 1
                result = new ChangeOfState(queue);
            else if (type == ChangeOfValue.TYPE_ID) // 2
                result = new ChangeOfValue(queue);
            else if (type == CommandFailure.TYPE_ID) // 3
                result = new CommandFailure(queue);
            else if (type == FloatingLimit.TYPE_ID) // 4
                result = new FloatingLimit(queue);
            else if (type == OutOfRange.TYPE_ID) // 5
                result = new OutOfRange(queue);
            else if (type == ComplexEventType.TYPE_ID) // 6
                result = new ComplexEventType(queue);
            else if (type == ChangeOfLifeSafety.TYPE_ID) // 8
                result = new ChangeOfLifeSafety(queue);
            else if (type == Extended.TYPE_ID) // 9
                result = new Extended(queue);
            else if (type == BufferReady.TYPE_ID) // 10
                result = new BufferReady(queue);
            else if (type == UnsignedRange.TYPE_ID) // 11
                result = new UnsignedRange(queue);
            else
                throw new BACnetErrorException(ErrorClass.Property, ErrorCode.InvalidParameterDataType);

            popEnd(queue, type);
            return result;
        }

        public sealed override void write(ByteStream queue)
        {
            writeContextTag(queue, TypeId, true);
            WriteImpl(queue);
            writeContextTag(queue, TypeId, false);
        }

        protected abstract int TypeId { get; }

        protected abstract void WriteImpl(ByteStream queue);
    }
}
