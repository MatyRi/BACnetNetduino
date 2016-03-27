using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.EventParameter
{
    class BufferReady : EventParameter
    {
        public static readonly byte TYPE_ID = 10;

        public BufferReady(UnsignedInteger notificationThreshold, UnsignedInteger previousNotificationCount)
        {
            NotificationThreshold = notificationThreshold;
            PreviousNotificationCount = previousNotificationCount;
        }

        protected override void writeImpl(ByteStream queue)
        {
            write(queue, NotificationThreshold, 0);
            write(queue, PreviousNotificationCount, 1);
        }

        public BufferReady(ByteStream queue)
        {
            NotificationThreshold = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            PreviousNotificationCount = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 1);
        }


        protected override int TypeId => TYPE_ID;

        public UnsignedInteger NotificationThreshold { get; }

        public UnsignedInteger PreviousNotificationCount { get; }
    }
}
