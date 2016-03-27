using BACnetDataTypes.Constructed;

namespace BACnetDataTypes.NotificationParameter
{
    class ChangeOfState : NotificationParameters
    {
        public static readonly byte TYPE_ID = 1;

        public ChangeOfState(PropertyStates newState, StatusFlags statusFlags)
        {
            NewState = newState;
            StatusFlags = statusFlags;
        }


        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, NewState, 0);
            write(queue, StatusFlags, 1);
        }

        public ChangeOfState(ByteStream queue)
        {
            NewState = (PropertyStates) read(queue, typeof (PropertyStates), 0);
            StatusFlags = (StatusFlags) read(queue, typeof (StatusFlags), 1);
        }


        protected override int TypeId => TYPE_ID;

        public PropertyStates NewState { get; }

        public StatusFlags StatusFlags { get; }
    }
}
