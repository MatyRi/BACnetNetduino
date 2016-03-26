using BACnetDataTypes.Enumerated;

namespace BACnetDataTypes.Exception
{
    public class BACnetRejectException : BACnetException
    {
        public BACnetRejectException(RejectReason rejectReason)
        {
            this.RejectReason = rejectReason;
        }

        public RejectReason RejectReason { get; }
    }
}
