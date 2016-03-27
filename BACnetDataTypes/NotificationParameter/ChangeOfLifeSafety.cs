using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;

namespace BACnetDataTypes.NotificationParameter
{
    class ChangeOfLifeSafety : NotificationParameters
    {
        public static readonly byte TYPE_ID = 8;

        public ChangeOfLifeSafety(LifeSafetyState newState, LifeSafetyMode newMode, StatusFlags statusFlags,
            LifeSafetyOperation operationExpected)
        {
            NewState = newState;
            NewMode = newMode;
            StatusFlags = statusFlags;
            OperationExpected = operationExpected;
        }


        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, NewState, 0);
            write(queue, StatusFlags, 1);
            write(queue, NewMode, 2);
            write(queue, OperationExpected, 3);
        }

        public ChangeOfLifeSafety(ByteStream queue)
        {
            NewState = (LifeSafetyState) read(queue, typeof (LifeSafetyState), 0);
            NewMode = (LifeSafetyMode) read(queue, typeof (LifeSafetyMode), 1);
            StatusFlags = (StatusFlags) read(queue, typeof (StatusFlags), 2);
            OperationExpected = (LifeSafetyOperation) read(queue, typeof (LifeSafetyOperation), 3);
        }


        protected override int TypeId => TYPE_ID;

        public LifeSafetyState NewState { get; }

        public LifeSafetyMode NewMode { get; }

        public StatusFlags StatusFlags { get; }

        public LifeSafetyOperation OperationExpected { get; }
    }
}
