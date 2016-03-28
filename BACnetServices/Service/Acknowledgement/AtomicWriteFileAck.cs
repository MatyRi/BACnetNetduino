using System;
using BACnetDataTypes;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class AtomicWriteFileAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 7;

        public AtomicWriteFileAck(bool recordAccess, SignedInteger fileStart)
        {
            IsRecordAccess = recordAccess;
            FileStart = fileStart;
        }

        public override byte ChoiceId => TYPE_ID;

        public override void write(ByteStream queue)
        {
            write(queue, FileStart, IsRecordAccess ? 1 : 0);
        }

        internal AtomicWriteFileAck(ByteStream queue)
        {
            IsRecordAccess = peekTagNumber(queue) == 1;
            FileStart = (SignedInteger) read(queue, typeof (SignedInteger), IsRecordAccess ? 1 : 0);
        }

        public bool IsRecordAccess { get; }

        public SignedInteger FileStart { get; }
    }
}
