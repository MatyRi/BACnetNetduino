using BACnetDataTypes;
using BACnetDataTypes.Primitive;

namespace BACnetServices.Service.Acknowledgement
{
    class AuthenticateAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 24;

        public AuthenticateAck(UnsignedInteger modifiedRandomNumber)
        {
            ModifiedRandomNumber = modifiedRandomNumber;
        }

        public override byte ChoiceId => TYPE_ID;

        public override void write(ByteStream queue)
        {
            write(queue, ModifiedRandomNumber);
        }

        internal AuthenticateAck(ByteStream queue)
        {
            ModifiedRandomNumber = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
        }

        public UnsignedInteger ModifiedRandomNumber { get; }
    }
}
