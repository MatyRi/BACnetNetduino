
namespace BACnetDataTypes.Primitive
{
    public class BBoolean : Primitive
    {
        public static readonly byte TYPE_ID = 1;

        public BBoolean(bool value)
        {
            Value = value;
        }

        public bool Value { get; }

        public BBoolean(ByteStream queue)
        {
            long length = readTag(queue);
            if (ContextSpecific)
                Value = queue.ReadByte() == 1;
            else
                Value = length == 1;
        }

        protected override void WriteImpl(ByteStream queue)
        {
            if (ContextSpecific)
                queue.WriteByte((byte)(Value ? 1 : 0));
        }

        protected override long Length
        {
            get
            {
                if (ContextSpecific)
                    return 1;
                return (byte)(Value ? 1 : 0);
            }
        }

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => Value.ToString();
    }
}
