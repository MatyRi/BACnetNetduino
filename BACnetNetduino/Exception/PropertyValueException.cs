using System;
using BACnetNetduino.DataTypes.Constructed;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
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
