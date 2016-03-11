using System;
using BACnetNetduino.APDU;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
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
