using BACnetNetduino.DataTypes.Constructed;

namespace BACnetNetduino.NPDU
{
    class NPDU
    {
        private byte version;
        private BitArray control; // 1 byte

        private short destinationNetworkAddress;
        private byte destinationMacLyerAddressLength;
        private byte[] destinationAddress;

        private short sourceNetworkAddress;
        private byte sourceMacLyerAddressLength;
        private byte[] sourceAddress;

        private byte hopCount;

        private byte messageType;
        private short vendorId;

        private NPDU()
        {
        }

        public static NPDU Parse(ByteStream source)
        {

            NPDU result = new NPDU();

            result.version = source.ReadByte();
            result.control = new BitArray(new[] { source.ReadByte() });

            if (result.control.Get(5))
            {
                result.destinationNetworkAddress = source.popU2B();
                result.destinationMacLyerAddressLength = source.popU1B();
                if (result.destinationMacLyerAddressLength > 0)
                {
                    result.destinationAddress = new byte[result.destinationMacLyerAddressLength];
                    source.pop(result.destinationAddress);
                }
            }

            if (result.control.Get(3))
            {
                // TODO Check address length
                result.sourceNetworkAddress = source.popU2B();
                result.sourceMacLyerAddressLength = source.popU1B();
                result.sourceAddress = new byte[result.sourceMacLyerAddressLength];
                source.pop(result.destinationAddress);
            }

            if (result.control.Get(5))
                result.hopCount = source.popU1B();

            if (result.control.Get(7))
            {
                result.messageType = source.popU1B();
                if (result.messageType >= 80)
                    result.vendorId = source.popU2B();
            }

            return result;
        }


        /**
         * For sending global broadcasts
         * 
         * @param source
         *            optional source address
         */
        public NPDU(Address source)
        {
            version = 1;
            control = new BitArray(1);

            control.Set(5, true);
            destinationNetworkAddress = (short) 0xFFFF;
            hopCount = 0xFF;

            setSourceAddress(source);
        }

        public NPDU(Address destination, Address source, bool expectsReply)
        {
            version = 1;
            control = new BitArray(1);

            if (destination != null)
            {
                control.Set(5, true);
                destinationNetworkAddress = destination.getNetworkNumber().intValue();
                destinationAddress = destination.getMacAddress().getBytes();
                if (destinationAddress != null)
                    destinationMacLyerAddressLength = (byte) destinationAddress.Length;
                hopCount = 0xFF;
            }

            setSourceAddress(source);

            if (expectsReply)
                control.Set(2, true);
        }

        public NPDU(Address destination, Address source, bool expectsReply, byte messageType, byte vendorId) : this(destination, source, expectsReply)
        {

            control.Set(7, true);
            this.messageType = messageType;
            this.vendorId = vendorId;
        }

        /*private void setSourceAddress(Address source)
        {
            if (source != null)
            {
                control = control.setBit(3);
                sourceNetwork = source.getNetworkNumber().intValue();
                sourceAddress = source.getMacAddress().getBytes();
                sourceLength = sourceAddress.length;
            }
        }*/

        public void write(ByteStream queue)
        {
            queue.WriteByte(version);
            queue.WriteByte(control);

            if (control.Get(5))
            {
                queue.pushU2B(destinationNetworkAddress);
                queue.WriteByte(destinationMacLyerAddressLength);
                if (destinationAddress != null)
                    queue.WriteByte(destinationAddress);
            }

            if (control.Get(3))
            {
                queue.pushU2B(sourceNetwork);
                queue.WriteByte(sourceLength);
                queue.WriteByte(sourceAddress);
            }

            if (control.Get(5))
                queue.WriteByte(hopCount);

            if (control.Get(7))
            {
                queue.WriteByte(messageType);
                if (messageType >= 80)
                    queue.pushU2B(vendorId);
            }
        }

        public bool hasDestinationInfo()
        {
            return control.Get(5);
        }

        public bool isDestinationBroadcast()
        {
            return destinationMacLyerAddressLength == 0;
        }

        public bool hasSourceInfo()
        {
            return control.Get(3);
        }

        public bool isExpectingReply()
        {
            return control.Get(2);
        }

        public bool isNetworkMessage()
        {
            return control.Get(7);
        }

        public bool isVendorSpecificNetworkMessage()
        {
            return isNetworkMessage() && messageType >= 80;
        }

        public int getNetworkPriority()
        {
            return (control.Get(1) ? 2 : 0) | (control.Get(0) ? 1 : 0);
        }

        public byte[] getDestinationAddress()
        {
            return destinationAddress;
        }

        public int getDestinationLength()
        {
            return destinationMacLyerAddressLength;
        }

        public int getDestinationNetwork()
        {
            return destinationNetworkAddress;
        }

        public int getHopCount()
        {
            return hopCount;
        }

        public int getMessageType()
        {
            return messageType;
        }

        public byte[] getSourceAddress()
        {
            return sourceAddress;
        }

        public int getSourceLength()
        {
            return sourceMacLyerAddressLength;
        }

        public int getSourceNetwork()
        {
            return sourceNetworkAddress;
        }

        public int getVendorId()
        {
            return vendorId;
        }

        public int getVersion()
        {
            return version;
        }
    }
}
