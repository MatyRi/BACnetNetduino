
namespace BACnetDataTypes.Primitive
{
    public class BBoolean : Primitive
    {
        public static readonly byte TYPE_ID = 1;

        public BBoolean(bool value)
        {
            this.Value = value;
        }

        public bool Value { get; }

        public BBoolean(ByteStream queue)
        {
            long length = readTag(queue);
            if (contextSpecific)
                Value = queue.ReadByte() == 1;
            else
                Value = length == 1;
        }

        /*public override void writeImpl(ByteStream queue)
        {
            if (contextSpecific)
                queue.push((byte)(value ? 1 : 0));
        }*/

        protected override long Length
        {
            get
            {
                if (contextSpecific)
                    return 1;
                return (byte)(Value ? 1 : 0);
            }
        }

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => Value.ToString();
    }
}
