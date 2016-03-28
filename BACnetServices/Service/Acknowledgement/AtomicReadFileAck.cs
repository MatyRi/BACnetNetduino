using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetServices.Service.Acknowledgement
{
    class AtomicReadFileAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 6;

        public AtomicReadFileAck(BBoolean endOfFile, SignedInteger fileStartPosition, OctetString fileData) : base()
        {
            EndOfFile = endOfFile;
            FileStartPosition = fileStartPosition;
            FileData = fileData;
            ReturnedRecordCount = null;
            FileRecordData = null;
        }

        public AtomicReadFileAck(BBoolean endOfFile, SignedInteger fileStartPosition,
            UnsignedInteger returnedRecordCount,
            SequenceOf fileRecordData) : base()
        {
            EndOfFile = endOfFile;
            FileStartPosition = fileStartPosition;
            FileData = null;
            ReturnedRecordCount = returnedRecordCount;
            FileRecordData = fileRecordData;
        }

        public override byte ChoiceId => TYPE_ID;

        public override void write(ByteStream queue)
        {
            write(queue, EndOfFile);
            if (FileData != null)
            {
                writeContextTag(queue, 0, true);
                write(queue, FileStartPosition);
                write(queue, FileData);
                writeContextTag(queue, 0, false);
            }
            else
            {
                writeContextTag(queue, 1, true);
                write(queue, FileStartPosition);
                write(queue, ReturnedRecordCount);
                write(queue, FileRecordData);
                writeContextTag(queue, 1, false);
            }
        }

        internal AtomicReadFileAck(ByteStream queue)
        {
            EndOfFile = (BBoolean) read(queue, typeof (BBoolean));
            if (popStart(queue) == 0)
            {
                FileStartPosition = (SignedInteger) read(queue, typeof (SignedInteger));
                FileData = (OctetString) read(queue, typeof (OctetString));
                ReturnedRecordCount = null;
                FileRecordData = null;
                popEnd(queue, 0);
            }
            else
            {
                FileStartPosition = (SignedInteger) read(queue, typeof (SignedInteger));
                ReturnedRecordCount = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
                FileData = null;
                IList records = new ArrayList();
                for (int i = 0; i < ReturnedRecordCount.Value; i++)
                    records.Add(read(queue, typeof (OctetString)));
                FileRecordData = new SequenceOf(records);
                popEnd(queue, 1);
            }
        }

        public BBoolean EndOfFile { get; }

        public SignedInteger FileStartPosition { get; }

        public OctetString FileData { get; }

        public UnsignedInteger ReturnedRecordCount { get; }

        public SequenceOf FileRecordData { get; }
    }
}
