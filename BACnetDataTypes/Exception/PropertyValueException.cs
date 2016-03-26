using BACnetDataTypes.Constructed;

namespace BACnetDataTypes.Exception
{
    class PropertyValueException : System.Exception
    {
        private readonly BACnetError error;

        public PropertyValueException(BACnetError error)
        {
            this.error = error;
        }

        public BACnetError getError()
        {
            return error;
        }
    }
}
