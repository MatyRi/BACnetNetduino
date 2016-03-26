using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using BACnetServices.Objects;
using Microsoft.SPOT;

namespace BACnetServices.Service.Unconfirmed
{
    internal class IAmRequest : UnconfirmedRequestService
    {
        //private static readonly Logger LOGGER = Logger.getLogger(IAmRequest.class.getName());

        public static readonly byte TYPE_ID = 0;

        private readonly ObjectIdentifier iAmDeviceIdentifier;
        private readonly UnsignedInteger maxAPDULengthAccepted;
        private readonly Segmentation segmentationSupported;
        private readonly UnsignedInteger vendorId;

        public IAmRequest(ObjectIdentifier iamDeviceIdentifier, UnsignedInteger maxAPDULengthAccepted,
            Segmentation segmentationSupported, UnsignedInteger vendorId)
        {
            iAmDeviceIdentifier = iamDeviceIdentifier;
            this.maxAPDULengthAccepted = maxAPDULengthAccepted;
            this.segmentationSupported = segmentationSupported;
            this.vendorId = vendorId;
        }

        public override byte getChoiceId()
        {
            return TYPE_ID;
        }

        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            if (!ObjectType.Device.Equals(iAmDeviceIdentifier.ObjectType))
            {
                //LOGGER.warning("Received IAm from an object that is not a device.");
                Debug.Print("Received IAm from an object that is not a device.");
                return;
            }

            // Make sure we're not hearing from ourselves.
            uint myDoi = localDevice.Configuration.getInstanceId();
            uint remoteDoi = iAmDeviceIdentifier.InstanceNumber;
            if (remoteDoi == myDoi)
            {
                // Get my bacnet address and compare the addresses
                foreach (Address addr in localDevice.AllLocalAddresses)
                {
                    if (addr.MACAddress.Equals(from.MACAddress))
                        // This is a local address, so ignore.
                        return;
                    //LOGGER.warning("Another instance with my device instance ID found!");
                    Debug.Print("Another instance with my device instance ID found! Here: " + from.MACAddress.MacAddressDottedString);
                }
            }

            // Register the device in the list of known devices.
            RemoteDevice d = BACnetStack.CreateRemoteDevice(remoteDoi, from, linkService);
            d.MaxAPDULengthAccepted = maxAPDULengthAccepted.Value;
            d.SegmentationSupported = segmentationSupported;
            d.VendorID = vendorId.Value;

            // Fire the appropriate event.
            // TODO localDevice.getEventHandler().fireIAmReceived(d);
            
        }

        public override void write(ByteStream queue)
        {
            write(queue, iAmDeviceIdentifier);
            write(queue, maxAPDULengthAccepted);
            write(queue, segmentationSupported);
            write(queue, vendorId);
        }

        internal IAmRequest(ByteStream queue)
        {
            iAmDeviceIdentifier = new ObjectIdentifier(queue);
            maxAPDULengthAccepted = new UnsignedInteger(queue);
            segmentationSupported = new Segmentation(queue);
            vendorId = new UnsignedInteger(queue);
    }
}
}
