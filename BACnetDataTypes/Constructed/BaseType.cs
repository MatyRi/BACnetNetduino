namespace BACnetDataTypes.Constructed
{
    public abstract class BaseType : Encodable
    {
        public override void write(ByteStream queue, int contextId)
        {
            // Write a start tag
            writeContextTag(queue, contextId, true);
            write(queue);
            // Write an end tag
            writeContextTag(queue, contextId, false);
        }
    }
}
