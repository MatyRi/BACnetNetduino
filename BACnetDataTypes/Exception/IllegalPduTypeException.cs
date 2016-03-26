namespace BACnetDataTypes.Exception
{
    public class IllegalPduTypeException : BACnetRuntimeException
    {
        public IllegalPduTypeException(string message) : base(message) { }
    }
}
