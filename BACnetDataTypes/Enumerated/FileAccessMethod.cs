namespace BACnetDataTypes.Enumerated
{
    class FileAccessMethod : Primitive.Enumerated
    {
        public static readonly FileAccessMethod RecordAccess = new FileAccessMethod(0);
        public static readonly FileAccessMethod StreamAccess = new FileAccessMethod(1);

        public static readonly FileAccessMethod[] All = {RecordAccess, StreamAccess};

        public FileAccessMethod(uint value) : base(value)
        {
        }

        public FileAccessMethod(ByteStream queue) : base(queue)
        {
        }
    }
}
