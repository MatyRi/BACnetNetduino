namespace BACnetDataTypes
{
    public class TagData
    {
        public int TagNumber;
        public bool ContextSpecific;
        public long Length;
        public int TagLength;

        public int TotalLength => (int)(Length + TagLength);

        public bool IsStartTag()
        {
            return ContextSpecific && ((Length & 6) == 6);
        }

        public bool IsStartTag(int contextId)
        {
            return IsStartTag() && TagNumber == contextId;
        }

        public bool IsEndTag()
        {
            return ContextSpecific && ((Length & 7) == 7);
        }

        public bool IsEndTag(int contextId)
        {
            return IsEndTag() && TagNumber == contextId;
        }
    }
}
