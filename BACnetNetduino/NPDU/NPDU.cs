namespace BACnetNetduino.NPDU
{
    class NPDU
    {
        private int version;
        private BitArray control;
        private int destinationNetwork;
        private int destinationLength;
        private byte[] destinationAddress;
        private int sourceNetwork;
        private int sourceLength;
        private byte[] sourceAddress;
        private int hopCount;
        private int messageType;
        private int vendorId;

        private NPDU()
        {
        }

        public static NPDU Parse(ByteStream source)
        {

            NPDU result = new NPDU();

            result.version = source.ReadIntByte();
            result.control = new BitArray(new[] { (byte) (source.ReadIntByte()) });

            if (result.control.Get(5))
            {
                result.destinationNetwork = source.popU2B();
                result.destinationLength = source.popU1B();
                if (result.destinationLength > 0)
                {
                    result.destinationAddress = new byte[result.destinationLength];
                    source.pop(result.destinationAddress);
                }
            }

            if (result.control.Get(3))
            {
                result.sourceNetwork = source.popU2B();
                result.sourceLength = source.popU1B();
                result.sourceAddress = new byte[result.sourceLength];
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
        /*public NPDU(Address source)
        {
            version = 1;
            control = BigInteger.valueOf(0);

            control = control.setBit(5);
            destinationNetwork = 0xFFFF;
            hopCount = 0xFF;

            setSourceAddress(source);
        }

        public NPDU(Address destination, Address source, boolean expectsReply)
        {
            version = 1;
            control = BigInteger.valueOf(0);

            if (destination != null)
            {
                control = control.setBit(5);
                destinationNetwork = destination.getNetworkNumber().intValue();
                destinationAddress = destination.getMacAddress().getBytes();
                if (destinationAddress != null)
                    destinationLength = destinationAddress.length;
                hopCount = 0xFF;
            }

            setSourceAddress(source);

            if (expectsReply)
                control = control.setBit(2);
        }

        public NPDU(Address destination, Address source, boolean expectsReply, int messageType, int vendorId)
        {
            this(destination, source, expectsReply);

            control = control.setBit(7);
            this.messageType = messageType;
            this.vendorId = vendorId;
        }

        private void setSourceAddress(Address source)
        {
            if (source != null)
            {
                control = control.setBit(3);
                sourceNetwork = source.getNetworkNumber().intValue();
                sourceAddress = source.getMacAddress().getBytes();
                sourceLength = sourceAddress.length;
            }
        }*/

        /*public void write(ByteQueue queue)
        {
            queue.push(version);
            queue.push(control.intValue());

            if (control.testBit(5))
            {
                queue.pushU2B(destinationNetwork);
                queue.push(destinationLength);
                if (destinationAddress != null)
                    queue.push(destinationAddress);
            }

            if (control.testBit(3))
            {
                queue.pushU2B(sourceNetwork);
                queue.push(sourceLength);
                queue.push(sourceAddress);
            }

            if (control.testBit(5))
                queue.push(hopCount);

            if (control.testBit(7))
            {
                queue.push(messageType);
                if (messageType >= 80)
                    queue.pushU2B(vendorId);
            }
        }*/

        public bool hasDestinationInfo()
        {
            return control.Get(5);
        }

        public bool isDestinationBroadcast()
        {
            return destinationLength == 0;
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
            return destinationLength;
        }

        public int getDestinationNetwork()
        {
            return destinationNetwork;
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
            return sourceLength;
        }

        public int getSourceNetwork()
        {
            return sourceNetwork;
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
