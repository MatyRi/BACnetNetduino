using System;
using System.Collections;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using BACnetServices.Objects;

namespace BACnetServices
{
    internal class BACnetStack
    {

        private static readonly IList remoteDevices = new ArrayList();

        private static bool strict = true;


        internal static RemoteDevice CreateRemoteDevice(uint instanceId, Address address, OctetString linkService)
        {
            RemoteDevice d = getRemoteDeviceImpl(instanceId, address, linkService);
            if (d == null)
            {
                if (address == null)
                    throw new NullReferenceException("addr cannot be null");
                d = new RemoteDevice(instanceId, address, linkService);
                remoteDevices.Add(d);
            }
            return d;
        }

        private static RemoteDevice getRemoteDeviceImpl(uint instanceId, Address address, OctetString linkService)
        {
            foreach (RemoteDevice d in remoteDevices)
            {
                if (strict || address == null)
                {
                    // Only compare by device id, as should be sufficient according to the spec's insistence on 
                    // unique device ids.
                    if (d.InstanceNumber == instanceId)
                        return d;
                }
                else {
                    // Compare device ids and address.
                    if (d.InstanceNumber == instanceId && d.Address.Equals(address) && linkService.Equals(d.LinkService))
                        return d;
                }
            }
            return null;
        }
    }
}
