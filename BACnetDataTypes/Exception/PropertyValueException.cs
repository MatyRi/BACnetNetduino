using BACnetDataTypes.Constructed;

namespace BACnetDataTypes.Exception
{
    class PropertyValueException : System.Exception
    {
        public PropertyValueException(BACnetError error)
        {
            this.Error = error;
        }

        public BACnetError Error { get; }
    }
}
