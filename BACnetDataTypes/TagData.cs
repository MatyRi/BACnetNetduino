namespace BACnetDataTypes
{
    public class TagData
    { 
        public int tagNumber;
        public bool contextSpecific;
        public long length;
        public int tagLength;

        public int getTotalLength()
        {
            return (int)(length + tagLength);
        }

        public bool isStartTag()
        {
            return contextSpecific && ((length & 6) == 6);
        }

        public bool isStartTag(int contextId)
        {
            return isStartTag() && tagNumber == contextId;
        }

        public bool isEndTag()
        {
            return contextSpecific && ((length & 7) == 7);
        }

        public bool isEndTag(int contextId)
        {
            return isEndTag() && tagNumber == contextId;
        }
    }
}
