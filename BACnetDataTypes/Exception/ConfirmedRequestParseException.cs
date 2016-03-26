namespace BACnetDataTypes.Exception
{
    class ConfirmedRequestParseException : BACnetException
    {
        private readonly int originalInvokeId;

        public ConfirmedRequestParseException(int originalInvokeId)
        {
            this.originalInvokeId = originalInvokeId;
        }

        public ConfirmedRequestParseException(int originalInvokeId, System.Exception cause) : base(cause)
        {
            this.originalInvokeId = originalInvokeId;
        }

        public int getOriginalInvokeId()
        {
            return originalInvokeId;
        }
    }
}
