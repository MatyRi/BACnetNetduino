using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Enumerated
{
    class Segmentation : Primitive.Enumerated
    {
        public static readonly Segmentation segmentedBoth = new Segmentation(0);
        public static readonly Segmentation segmentedTransmit = new Segmentation(1);
        public static readonly Segmentation segmentedReceive = new Segmentation(2);
        public static readonly Segmentation noSegmentation = new Segmentation(3);

        public static readonly Segmentation[] ALL = { segmentedBoth, segmentedTransmit, segmentedReceive, noSegmentation, };

        public Segmentation(uint value) : base(value) { }

        public Segmentation(ByteStream queue) : base(queue) { }

    public bool hasTransmitSegmentation()
    {
        return this.Equals(segmentedBoth) || this.Equals(segmentedTransmit);
    }

    public bool hasReceiveSegmentation()
    {
        return this.Equals(segmentedBoth) || this.Equals(segmentedReceive);
    }

    public override string ToString()
    {
        uint type = intValue();
        if (type == segmentedBoth.intValue())
            return "both";
        if (type == segmentedTransmit.intValue())
            return "transmit";
        if (type == segmentedReceive.intValue())
            return "receive";
        if (type == noSegmentation.intValue())
            return "none";
        return "Unknown: " + type;
    }
}
}
