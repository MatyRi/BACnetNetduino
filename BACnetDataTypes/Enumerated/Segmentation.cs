namespace BACnetDataTypes.Enumerated
{
    public class Segmentation : Primitive.Enumerated
    {
        public static readonly Segmentation SegmentedBoth = new Segmentation(0);
        public static readonly Segmentation SegmentedTransmit = new Segmentation(1);
        public static readonly Segmentation SegmentedReceive = new Segmentation(2);
        public static readonly Segmentation NoSegmentation = new Segmentation(3);

        public static readonly Segmentation[] All =
        {
            SegmentedBoth, SegmentedTransmit, SegmentedReceive, NoSegmentation
        };

        public Segmentation(uint value) : base(value)
        {
        }

        public Segmentation(ByteStream queue) : base(queue)
        {
        }

        public bool HasTransmitSegmentation => Equals(SegmentedBoth) || Equals(SegmentedTransmit);

        public bool HasReceiveSegmentation => Equals(SegmentedBoth) || Equals(SegmentedReceive);

        public override string ToString()
        {
            uint type = Value;
            if (type == SegmentedBoth.Value)
                return "both";
            if (type == SegmentedTransmit.Value)
                return "transmit";
            if (type == SegmentedReceive.Value)
                return "receive";
            if (type == NoSegmentation.Value)
                return "none";
            return "Unknown: " + type;
        }
    }

}
