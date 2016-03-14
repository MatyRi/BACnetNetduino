using System;
using Microsoft.SPOT;

namespace BACnetNetduino.NPDU
{
    class NLPCI
    {
        private readonly byte v;

        public NLPCI(byte v)
        {
            this.v = v;
        }

        private bool Bit7 => (v & 0x80) != 0;
        private bool Bit6 => (v & 0x40) != 0;
        private bool Bit5 => (v & 0x20) != 0;
        private bool Bit4 => (v & 0x10) != 0;
        private bool Bit3 => (v & 0x08) != 0;
        private bool Bit2 => (v & 0x04) != 0;
        public bool Bit1 => (v & 0x02) != 0;
        public bool Bit0 => (v & 0x01) != 0;


        public bool IsNetworkLayerMessage => Bit7;
        public bool IsBACnetAPDU => !Bit7;
        public bool IsDestinationSpecific => Bit5;
        public bool IsSourceSpecific => Bit3;
        public bool ExpectsReply => Bit2;

        public bool IsLifeSafetyMessage => Bit1 && Bit0;
        public bool IsCriticalEquipmentMessage  => Bit1 && !Bit0;
        public bool IsUrgentMessage => !Bit1 && Bit0;
        public bool IsNormalMessage => !Bit1 && !Bit0;
    }
}
