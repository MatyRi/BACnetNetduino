using System;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes
{
    class VendorServiceKey
    {
        private readonly UnsignedInteger vendorId;
        private readonly UnsignedInteger serviceNumber;

        public VendorServiceKey(uint vendorId, uint serviceNumber)
            : this(new UnsignedInteger(vendorId), new UnsignedInteger(serviceNumber))
        {
        }

        public VendorServiceKey(UnsignedInteger vendorId, UnsignedInteger serviceNumber)
        {
            this.vendorId = vendorId;
            this.serviceNumber = serviceNumber;
        }
    }
}
