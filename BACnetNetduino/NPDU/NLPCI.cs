using System;
using Microsoft.SPOT;

namespace BACnetNetduino.NPDU
{
    internal class NLPCI
    {
        private byte v;

        public byte Value => v;

        public NLPCI(byte v)
        {
            this.v = v;
        }

        private bool Bit7
        {
            get { return (v & 0x80) != 0; }
            set
            {
                if (value)
                {
                    v = (byte)(v | 0x80);
                }
                else
                {
                    v = (byte)(v & 0x7F);
                }
            }
        }

        private bool Bit6
        {
            get { return (v & 0x40) != 0; }
            set
            {
                if (value)
                {
                    v = (byte)(v | 0x40);
                }
                else
                {
                    v = (byte)(v & 0xBF);
                }
            }
        }

        private bool Bit5
        {
            get { return (v & 0x20) != 0; }
            set
            {
                if (value)
                {
                    v = (byte)(v | 0x20);
                }
                else
                {
                    v = (byte)(v & 0xDF);
                }
            }
        }

        private bool Bit4
        {
            get { return (v & 0x10) != 0; }
            set
            {
                if (value)
                {
                    v = (byte)(v | 0x10);
                }
                else
                {
                    v = (byte)(v & 0xEF);
                }
            }
        }

        private bool Bit3
        {
            get { return (v & 0x08) != 0; }
            set {
                if (value)
                {
                    v = (byte) (v | 0x08);
                }
                else
                {
                    v = (byte) (v & 0xF7);
                }
            }
        }

        private bool Bit2
        {
            get
            {
                return (v & 0x04) != 0;
            }
            set
            {
                if (value)
                {
                    v = (byte)(v | 0x04);
                }
                else
                {
                    v = (byte)(v & 0xFB);
                }
            }
        } 
        public bool Bit1 => (v & 0x02) != 0;
        public bool Bit0 => (v & 0x01) != 0;


        public bool IsNetworkLayerMessage
        {
            get { return Bit7; }
            set { Bit7 = value; }
        }
        public bool IsBACnetAPDU => !Bit7;

        public bool IsDestinationSpecific
        {
            get { return Bit5; }
            set { Bit5 = value; }
        }
        public bool IsSourceSpecific
        {
            get { return Bit3; }
            set { Bit3 = value; }
        }

        public bool ExpectsReply
        {
            get { return Bit2; }
            set { Bit2 = value; }
        }

        public bool IsLifeSafetyMessage => Bit1 && Bit0;
        public bool IsCriticalEquipmentMessage  => Bit1 && !Bit0;
        public bool IsUrgentMessage => !Bit1 && Bit0;
        public bool IsNormalMessage => !Bit1 && !Bit0;
    }
}
