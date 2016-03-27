namespace BACnetDataTypes.Enumerated
{
    class AbortReason : Primitive.Enumerated
    {
        public static readonly AbortReason Other = new AbortReason(0);
        public static readonly AbortReason BufferOverflow = new AbortReason(1);
        public static readonly AbortReason InvalidApduInThisState = new AbortReason(2);
        public static readonly AbortReason PreemptedByHigherPriorityTask = new AbortReason(3);
        public static readonly AbortReason SegmentationNotSupported = new AbortReason(4);

        public static readonly AbortReason[] All =
        {
            Other, BufferOverflow, InvalidApduInThisState,
            PreemptedByHigherPriorityTask, SegmentationNotSupported
        };

        public AbortReason(uint value) : base(value)
        {
        }

        public AbortReason(ByteStream queue) : base(queue)
        {
        }


        public override string ToString()
        {
            uint type = Value;
            if (type == Other.Value)
                return "Other";
            if (type == BufferOverflow.Value)
                return "Buffer overflow";
            if (type == InvalidApduInThisState.Value)
                return "Invalid APDU in this state";
            if (type == PreemptedByHigherPriorityTask.Value)
                return "Preempted by higher priority task";
            if (type == SegmentationNotSupported.Value)
                return "Segmentation not supported";
            return "Unknown abort reason(" + type + ")";
        }
    }
}
