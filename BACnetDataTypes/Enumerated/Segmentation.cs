using BACnetDataTypes.Primitive;

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
            SegmentedBoth, SegmentedTransmit, SegmentedReceive, NoSegmentation,
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
            uint type = ((UnsignedInteger) this).Value;
            if (type == ((UnsignedInteger) SegmentedBoth).Value)
                return "both";
            if (type == ((UnsignedInteger) SegmentedTransmit).Value)
                return "transmit";
            if (type == ((UnsignedInteger) SegmentedReceive).Value)
                return "receive";
            if (type == ((UnsignedInteger) NoSegmentation).Value)
                return "none";
            return "Unknown: " + type;
        }
    }

}
