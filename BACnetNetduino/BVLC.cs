using System;
using System.IO;
using BACnetNetduino.Enums;
using BACnetNetduino.NPDU;
using Microsoft.SPOT;

namespace BACnetNetduino
{
    class BVLC
    {
        private BVLCType type;
        private BVLCFunction function;
        private int length;

        private BVLC()
        {
        }

        public static BVLC Parse(ByteStream source)
        {

            BVLC result = new BVLC();

            // Initial parsing of IP message.
            // BACnet/IP
            if (source.ReadByte() != (byte)0x81)
                throw new MessageValidationAssertionException("Protocol id is not BACnet/IP (0x81)");

            byte function = (byte) source.ReadByte();
            if (function != 0xa && function != 0xb && function != 0x4 && function != 0x0)
                throw new MessageValidationAssertionException("Function is not unicast, broadcast, forward"
                        + " or foreign device reg anwser (0xa, 0xb, 0x4 or 0x0)");

            result.length = source.ReadShort();
            if (result.length != source.Length/* + 4*/)
                throw new MessageValidationAssertionException("Length field does not match data: given=" + result.length
                        + ", expected=" + (source.Length/* + 4*/));

            // answer to foreign device registration
            if (function == 0x0)
            {
                int regResult = source.ReadShort();
                if (regResult != 0)
                    Debug.Print("Foreign device registration not successful! result: " + regResult);

                // not APDU received, bail
                return null; // TODO Test
            }

            if (function == 0x4)
            {
                // A forward. Use the address/port as the link service address.
                byte[] addr = new byte[6];
                source.Read(addr);
                // TODO linkService = new OctetString(addr);
            }
            return result;
        }

        public int Length => length;
    }
}
