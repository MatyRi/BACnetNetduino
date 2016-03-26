using BACnetDataTypes.Exception;
using BACnetServices.APDU;

namespace BACnetServices.Exception
{
    class SegmentedMessageAbortedException : BACnetException
    {
        private readonly Abort abort;

    public SegmentedMessageAbortedException(Abort abort)
        {
            this.abort = abort;
        }

        public Abort getAbort()
        {
            return abort;
        }
    }
}
