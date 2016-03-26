using BACnetDataTypes;
using BACnetDataTypes.Primitive;
using BACnetNetwork.NPDU;
using Microsoft.SPOT;

namespace BACnetNetwork.BVLC
{
    class BVLC
    {
        // 4 bytes total of BVLC
        private BVLCType type;
        private BVLCFunction function;
        private short length; // total packet length including NPDU + APDU

        private BVLC()
        {
        }

        public BVLC(ByteStream source)
        {
            // Initial parsing of IP message.
            // BACnet/IP
            type = (BVLCType) source.ReadByte();
            if (type != BVLCType.BACnetIP_AnnexJ) // NO BVLC !!
                throw new MessageValidationAssertionException("Protocol id is not BACnet/IP (0x81)");

            function = (BVLCFunction) source.ReadByte();
            if (function != BVLCFunction.OriginalUnicastNPDU 
                && function != BVLCFunction.OriginalBroadcastNPDU
                && function != BVLCFunction.ForwardedNPDU
                && function != 0x0)
                throw new MessageValidationAssertionException("Function is not unicast, broadcast, forward"
                        + " or foreign device reg anwser (0xa, 0xb, 0x4 or 0x0)");

            length = source.ReadShort();
            if (length != source.Length/* + 4*/)
                throw new MessageValidationAssertionException("Length field does not match data: given=" + length
                        + ", expected=" + (source.Length/* + 4*/));

            // answer to foreign device registration
            if (function == 0x0)
            {
                int regResult = source.ReadShort();
                if (regResult != 0)
                    Debug.Print("Foreign device registration not successful! result: " + regResult);

                // not APDU received, bail
                //return null; // TODO Test
            }

            if (function == BVLCFunction.ForwardedNPDU)
            {
                // A forward. Use the address/port as the link service address.
                byte[] addr = new byte[6];
                source.Read(addr);
                var linkService = new OctetString(addr);
            }
        }

        public int Length => length;
    }
}
