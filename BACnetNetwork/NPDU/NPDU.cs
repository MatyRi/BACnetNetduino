using BACnetDataTypes;
using BACnetDataTypes.Constructed;

namespace BACnetNetwork.NPDU
{
    public class NPDU
    {
        private byte version;
        private NLPCI control; // 1 byte

        private ushort destinationNetworkAddress;
        private byte destinationMacLyerAddressLength;
        private byte[] destinationAddress;

        private ushort sourceNetworkAddress;
        private byte sourceMacLyerAddressLength;
        private byte[] sourceAddress;

        private byte hopCount;

        private byte messageType;
        private ushort vendorId;


        public NPDU(ByteStream source)
        {

            version = source.ReadByte();
            control = new NLPCI(source.ReadByte());

            if (control.IsDestinationSpecific)
            {
                destinationNetworkAddress = source.popU2B();
                destinationMacLyerAddressLength = source.popU1B();
                if (destinationMacLyerAddressLength > 0)
                {
                    destinationAddress = new byte[destinationMacLyerAddressLength];
                    source.Read(destinationAddress);
                }
            }

            if (control.IsSourceSpecific)
            {
                // TODO Check address length
                sourceNetworkAddress = source.popU2B();
                sourceMacLyerAddressLength = source.popU1B();
                sourceAddress = new byte[sourceMacLyerAddressLength];
                source.Read(destinationAddress);
            }

            if (control.IsDestinationSpecific)
                hopCount = source.popU1B();

            if (control.IsNetworkLayerMessage)
            {
                messageType = source.popU1B();
                if (messageType >= 80)
                    vendorId = source.popU2B();
            }
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
            control = new NLPCI(0); //new BitArray(1));

            control.IsDestinationSpecific = true;
            destinationNetworkAddress = ushort.MaxValue; //(ushort) 0xFFFF;
            hopCount = 0xFF;

            setSourceAddress(source);
        }

        public NPDU(Address destination, Address source, bool expectsReply)
        {
            version = 1;
            control = new NLPCI(1); //new BitArray(1));

            if (destination != null)
            {
                control.IsDestinationSpecific = true;
                destinationNetworkAddress = (ushort) destination.NetworkNumber.Value;
                destinationAddress = destination.MACAddress.Bytes;
                if (destinationAddress != null)
                    destinationMacLyerAddressLength = (byte) destinationAddress.Length;
                hopCount = 0xFF;
            }

            setSourceAddress(source);

            if (expectsReply)
                control.ExpectsReply = true;
        }

        public NPDU(Address destination, Address source, bool expectsReply, byte messageType, byte vendorId) : this(destination, source, expectsReply)
        {

            control.IsNetworkLayerMessage = true;
            this.messageType = messageType;
            this.vendorId = vendorId;
        }

        private void setSourceAddress(Address source)
        {
            if (source != null)
            {
                control.IsSourceSpecific = true;
                sourceNetworkAddress = (ushort) source.NetworkNumber.Value;
                sourceAddress = source.MACAddress.Bytes;
                sourceMacLyerAddressLength = (byte) sourceAddress.Length;
            }
        }

        public void write(ByteStream queue)
        {
            queue.WriteByte(version);
            queue.WriteByte(control.Value);

            if (control.IsDestinationSpecific)
            {
                queue.pushU2B(destinationNetworkAddress);
                queue.WriteByte(destinationMacLyerAddressLength);
                if (destinationAddress != null)
                    queue.Write(destinationAddress);
            }

            if (control.IsSourceSpecific)
            {
                queue.pushU2B(sourceNetworkAddress);
                queue.WriteByte(sourceMacLyerAddressLength);
                queue.Write(sourceAddress);
            }

            if (control.IsDestinationSpecific)
                queue.WriteByte(hopCount);

            if (control.IsNetworkLayerMessage)
            {
                queue.WriteByte(messageType);
                if (messageType >= 80)
                    queue.pushU2B(vendorId);
            }
        }

        public bool HasDestinationInfo => control.IsDestinationSpecific;

        public bool IsDestinationBroadcast => destinationMacLyerAddressLength == 0;

        public bool HasSourceInfo => control.IsSourceSpecific;

        public bool IsExpectingReply => control.ExpectsReply;

        public bool IsNetworkMessage => control.IsNetworkLayerMessage;

        public bool IsVendorSpecificNetworkMessage => IsNetworkMessage && messageType >= 80;

        public int NetworkPriority => (control.Bit1 ? 2 : 0) | (control.Bit0 ? 1 : 0);

        public byte[] DestinationAddress => destinationAddress;

        public byte DestinationLength => destinationMacLyerAddressLength;

        public ushort DestinationNetwork => destinationNetworkAddress;

        public byte HopCount => hopCount;

        public byte MessageType => messageType;

        public byte[] SourceAddress => sourceAddress;

        public byte SourceLength => sourceMacLyerAddressLength;

        public ushort SourceNetwork => sourceNetworkAddress;

        public ushort VendorId => vendorId;

        public byte Version => version;
    }
}
