using System;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Enumerated;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.Service.Unconfirmed
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
            this.iAmDeviceIdentifier = iamDeviceIdentifier;
            this.maxAPDULengthAccepted = maxAPDULengthAccepted;
            this.segmentationSupported = segmentationSupported;
            this.vendorId = vendorId;
        }

        public override byte getChoiceId()
        {
            return TYPE_ID;
        }

        //public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        //{
            /*if (!ObjectType.device.Equals(iAmDeviceIdentifier.getObjectType()))
            {
                //LOGGER.warning("Received IAm from an object that is not a device.");
                Debug.Print("Received IAm from an object that is not a device.");
                return;
            }

            // Make sure we're not hearing from ourselves.
            int myDoi = localDevice.getConfiguration().getInstanceId();
            int remoteDoi = iAmDeviceIdentifier.getInstanceNumber();
            if (remoteDoi == myDoi)
            {
                // Get my bacnet address and compare the addresses
                for (Address addr : localDevice.getAllLocalAddresses())
                {
                    if (addr.getMacAddress().equals(from.getMacAddress()))
                        // This is a local address, so ignore.
                        return;
                    //LOGGER.warning("Another instance with my device instance ID found!");
                    System.err.println("Another instance with my device instance ID found! Here: " + from.getMacAddress().getMacAddressDottedString());
                }
            }

            // Register the device in the list of known devices.
            RemoteDevice d = localDevice.getRemoteDeviceCreate(remoteDoi, from, linkService);
            d.setMaxAPDULengthAccepted(maxAPDULengthAccepted.intValue());
            d.setSegmentationSupported(segmentationSupported);
            d.setVendorId(vendorId.intValue());

            // Fire the appropriate event.
            localDevice.getEventHandler().fireIAmReceived(d);
            */
        //}

        /*public override void write(ByteStream queue)
        {
            write(queue, iAmDeviceIdentifier);
            write(queue, maxAPDULengthAccepted);
            write(queue, segmentationSupported);
            write(queue, vendorId);
        }*/

        internal IAmRequest(ByteStream queue)
        {
            iAmDeviceIdentifier = new ObjectIdentifier(queue);
            maxAPDULengthAccepted = new UnsignedInteger(queue);
            segmentationSupported = new Segmentation(queue);
            vendorId = new UnsignedInteger(queue);
    }
}
}
