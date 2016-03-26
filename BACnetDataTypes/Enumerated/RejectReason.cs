namespace BACnetDataTypes.Enumerated
{
    public class RejectReason : Primitive.Enumerated
    {
        public static readonly RejectReason other = new RejectReason(0);
        public static readonly RejectReason bufferOverflow = new RejectReason(1);
        public static readonly RejectReason inconsistentParameters = new RejectReason(2);
        public static readonly RejectReason invalidParameterDataType = new RejectReason(3);
        public static readonly RejectReason invalidTag = new RejectReason(4);
        public static readonly RejectReason missingRequiredParameter = new RejectReason(5);
        public static readonly RejectReason parameterOutOfRange = new RejectReason(6);
        public static readonly RejectReason tooManyArguments = new RejectReason(7);
        public static readonly RejectReason undefinedEnumeration = new RejectReason(8);
        public static readonly RejectReason unrecognizedService = new RejectReason(9);

        public static readonly RejectReason[] ALL = { other, bufferOverflow, inconsistentParameters, invalidParameterDataType,
            invalidTag, missingRequiredParameter, parameterOutOfRange, tooManyArguments, undefinedEnumeration,
            unrecognizedService, };

    public RejectReason(uint value) : base(value) { }

    public RejectReason(ByteStream queue) : base(queue) { }
}
}
