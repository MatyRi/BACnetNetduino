using System.Collections;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetServices.Objects
{
    public class RemoteDevice
    {
        private readonly uint instanceNumber;
        private readonly Address address;
        private readonly OctetString linkService;
        private uint maxAPDULengthAccepted;
        private Segmentation segmentationSupported;
        private uint vendorId;
        private string vendorName;
        private string name;
        private string modelName;
        private UnsignedInteger protocolVersion;
        private UnsignedInteger protocolRevision;
        private ServicesSupported servicesSupported;
        //private readonly Map<ObjectIdentifier, RemoteObject> objects = new HashMap<ObjectIdentifier, RemoteObject>();
        private readonly Hashtable objects = new Hashtable();
        private object userData;
        private int maxReadMultipleReferences = -1;

        public RemoteDevice(uint instanceNumber, Address address, OctetString linkService)
        {
            this.instanceNumber = instanceNumber;
            this.address = address;
            this.linkService = linkService;
        }

        public ObjectIdentifier ObjectIdentifier => new ObjectIdentifier(ObjectType.device, instanceNumber);
        
        public override string ToString()
        {
            return "RemoteDevice(instanceNumber=" + instanceNumber + ", address=" + address + ", linkServiceAddress="
                    + linkService + ")";
        }

        public string ToExtendedString()
        {
            return "RemoteDevice \n" +
                    " - instanceNumber = " + instanceNumber + ", \n" +
                    " - address = " + address + ", \n" +
                    " - linkServiceAddress = " + linkService + ", \n" +
                    " - maxAPDULengthAccepted = " + maxAPDULengthAccepted + ", \n" +
                    " - segmentationSupported = " + segmentationSupported + ", \n" +
                    " - vendorId = " + vendorId + ", \n" +
                    " - vendorName = " + vendorName + ", \n" +
                    " - protocol version = " + protocolVersion + ", \n" +
                    " - protocol revision = " + protocolRevision + ", \n" +
                    " - model name = " + modelName + ", \n" +
                    " - name = " + name + ", \n" +
                    " - servicesSupported = " + servicesSupported + ", \n" +
                    " - objects = " + objects + "\n";
        }

        public void setObject(RemoteObject o)
        {
            objects[o.ObjectIdentifier] = o;
        }

        public RemoteObject this[ObjectIdentifier oid] => (RemoteObject) objects[oid];

        public ICollection Objects => objects.Values;

        public void clearObjects()
        {
            objects.Clear();
        }

        public Address Address => address;

        public OctetString LinkService => linkService;

        public uint MaxAPDULengthAccepted
        {
            get { return maxAPDULengthAccepted; }
            set { maxAPDULengthAccepted = value; }
        }

        public Segmentation SegmentationSupported
        {
            get { return segmentationSupported;}
            set { segmentationSupported = value; }
        }

        public uint VendorID
        {
            get { return vendorId;}
            set { vendorId = value; }
        }

        public string VendorName
        {
            get { return vendorName; }
            set { vendorName = value; }
        }

        public uint InstanceNumber => instanceNumber;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }

        public UnsignedInteger ProtocolVersion 
        {
            get { return protocolVersion; }
            set { protocolVersion = value; }
        }

        public UnsignedInteger ProtocolRevision
        {
            get { return protocolRevision; }
            set { protocolRevision = value; }
        }

        public ServicesSupported ServicesSupported
        {
            get { return servicesSupported; }
            set { servicesSupported = value; }
        }

        public object UserData
        {
            get { return userData; }
            set { userData = value; }
        }

        public int MaxReadMultipleReferences
        {
            get
            {
                if (maxReadMultipleReferences == -1)
                    maxReadMultipleReferences = segmentationSupported.hasTransmitSegmentation() ? 200 : 20;
                return maxReadMultipleReferences;
            }
        }

        public void reduceMaxReadMultipleReferences()
        {
            if (maxReadMultipleReferences > 1)
                maxReadMultipleReferences = (int)(maxReadMultipleReferences * 0.75);
        }
    }
}
