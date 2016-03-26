namespace BACnetDataTypes.Primitive
{
    public class Null : Primitive
    {
        public static readonly byte TYPE_ID = 0;

        public Null()
        {
            // no op
        }

        public Null(ByteStream queue)
        {
            readTag(queue);
        }

        /*public override void writeImpl(ByteStream queue)
        {
            // no op
        }*/


        protected override long Length => 0;

        protected override byte TypeId => TYPE_ID;

        public override string ToString()
        {
            return "Null";
        }
    }
}
