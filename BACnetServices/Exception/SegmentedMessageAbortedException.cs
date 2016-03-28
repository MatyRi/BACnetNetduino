using BACnetDataTypes.Exception;
using BACnetServices.APDU;

namespace BACnetServices.Exception
{
    class SegmentedMessageAbortedException : BACnetException
    {
        public SegmentedMessageAbortedException(Abort abort)
        {
            this.Abort = abort;
        }

        public Abort Abort { get; }
    }
}
