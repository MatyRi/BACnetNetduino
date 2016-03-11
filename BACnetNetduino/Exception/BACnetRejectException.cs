using System;
using BACnetNetduino.DataTypes.Enumerated;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class BACnetRejectException : BACnetException
    {
        private readonly RejectReason rejectReason;

        public BACnetRejectException(RejectReason rejectReason)
        {
            this.rejectReason = rejectReason;
        }

        public RejectReason getRejectReason()
        {
            return rejectReason;
        }
    }
}
