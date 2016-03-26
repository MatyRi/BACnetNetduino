using BACnetDataTypes.Enumerated;

namespace BACnetDataTypes.Exception
{
    public class BACnetRejectException : BACnetException
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
