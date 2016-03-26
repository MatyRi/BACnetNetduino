namespace BACnetDataTypes.Enumerated
{
    public class RejectReason : Primitive.Enumerated
    {
        public static readonly RejectReason Other = new RejectReason(0);
        public static readonly RejectReason BufferOverflow = new RejectReason(1);
        public static readonly RejectReason InconsistentParameters = new RejectReason(2);
        public static readonly RejectReason InvalidParameterDataType = new RejectReason(3);
        public static readonly RejectReason InvalidTag = new RejectReason(4);
        public static readonly RejectReason MissingRequiredParameter = new RejectReason(5);
        public static readonly RejectReason ParameterOutOfRange = new RejectReason(6);
        public static readonly RejectReason TooManyArguments = new RejectReason(7);
        public static readonly RejectReason UndefinedEnumeration = new RejectReason(8);
        public static readonly RejectReason UnrecognizedService = new RejectReason(9);

        public static readonly RejectReason[] All = { Other, BufferOverflow, InconsistentParameters, InvalidParameterDataType,
            InvalidTag, MissingRequiredParameter, ParameterOutOfRange, TooManyArguments, UndefinedEnumeration,
            UnrecognizedService, };

    public RejectReason(uint value) : base(value) { }

    public RejectReason(ByteStream queue) : base(queue) { }
}
}
