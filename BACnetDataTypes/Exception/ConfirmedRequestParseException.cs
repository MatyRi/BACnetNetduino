namespace BACnetDataTypes.Exception
{
    class ConfirmedRequestParseException : BACnetException
    {
        public ConfirmedRequestParseException(int originalInvokeId)
        {
            this.OriginalInvokeId = originalInvokeId;
        }

        public ConfirmedRequestParseException(int originalInvokeId, System.Exception cause) : base(cause)
        {
            this.OriginalInvokeId = originalInvokeId;
        }

        public int OriginalInvokeId { get; }
    }
}
