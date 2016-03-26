namespace BACnetDataTypes.Exception
{
    public class BACnetException : System.Exception
    {
        public BACnetException() : base() { }

        public BACnetException(string message, System.Exception cause) : base(message, cause) { }

        public BACnetException(string message) : base(message) { }

        public BACnetException(System.Exception cause) : base(string.Empty, cause) { }
    }
}
