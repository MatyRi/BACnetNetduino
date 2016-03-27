using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.NotificationParameter
{
    class BufferReady : NotificationParameters
    {
        public static readonly byte TYPE_ID = 10;

        public BufferReady(DeviceObjectPropertyReference bufferProperty, UnsignedInteger previousNotification,
            UnsignedInteger currentNotification)
        {
            BufferProperty = bufferProperty;
            PreviousNotification = previousNotification;
            CurrentNotification = currentNotification;
        }


        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, BufferProperty, 0);
            write(queue, PreviousNotification, 1);
            write(queue, CurrentNotification, 2);
        }

        public BufferReady(ByteStream queue)
        {
            BufferProperty = (DeviceObjectPropertyReference)read(queue, typeof(DeviceObjectPropertyReference), 0);
            PreviousNotification = (UnsignedInteger)read(queue, typeof(UnsignedInteger), 1);
            CurrentNotification = (UnsignedInteger)read(queue, typeof(UnsignedInteger), 2);
        }

        protected override int TypeId => TYPE_ID;

        public DeviceObjectPropertyReference BufferProperty { get; }

        public UnsignedInteger PreviousNotification { get; }

        public UnsignedInteger CurrentNotification { get; }
    }
}
