using System;
using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using BACnetServices.Objects;
using Microsoft.SPOT;

namespace BACnetServices.Service.Unconfirmed
{
    class WhoHasRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 7;

        private static IList classes = new ArrayList()
        {
            typeof (Encodable),
            typeof (Encodable),
            typeof (ObjectIdentifier),
            typeof (CharacterString)
        };


        private readonly Limits limits;
        private readonly Choice @object;

        public WhoHasRequest(Limits limits, ObjectIdentifier identifier)
        {
            this.limits = limits;
            @object = new Choice(2, identifier);
        }

        public WhoHasRequest(Limits limits, CharacterString name)
        {
            this.limits = limits;
            @object = new Choice(3, name);
        }


        public override byte ChoiceId => TYPE_ID;


        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            // Check if we're in the device id range.
            if (limits != null)
            {
                uint localId = localDevice.Configuration.getInstanceId();
                if (localId < limits.DeviceInstanceRangeLowLimit.Value
                    || localId > limits.getDeviceInstanceRangeHighLimit().Value)
                    return;
            }

            // Check if we have the thing being looking for.
            BACnetObject result;
            if (@object.ContextId == 2)
            {
                ObjectIdentifier oid = (ObjectIdentifier) @object.Data;
                result = localDevice.getObject(oid);
            }
            else if (@object.ContextId == 3)
            {
                string name = ((CharacterString) @object.Data).ToString();
                result = localDevice.getObject(name);
            }
            else
                return;

            if (result != null)
            {
                // Return the result in an i have message.
                IHaveRequest response = new IHaveRequest(localDevice.Configuration.getId(), result.getId(),
                    result.getRawObjectName());
                localDevice.sendGlobalBroadcast(response);
            }
        }


        public override void write(ByteStream queue)
        {
            writeOptional(queue, limits);
            write(queue, @object);
        }

        public WhoHasRequest(ByteStream queue)
        {
            Limits l = new Limits(queue);
            limits = l.DeviceInstanceRangeLowLimit== null ? null : l;
            @object = new Choice(queue, classes);
        }
    }


    public class Limits : BaseType
    {
        public override void write(ByteStream queue)
        {
            write(queue, DeviceInstanceRangeLowLimit, 0);
            write(queue, DeviceInstanceRangeHighLimit, 1);
        }

        internal Limits(ByteStream queue)
        {
            DeviceInstanceRangeLowLimit = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 0);
            DeviceInstanceRangeHighLimit = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 1);
        }

        public Limits(UnsignedInteger deviceInstanceRangeLowLimit, UnsignedInteger deviceInstanceRangeHighLimit)
        {
            if (deviceInstanceRangeLowLimit == null || deviceInstanceRangeHighLimit == null)
                throw new System.Exception("Both the low and high limits must be set");
            this.DeviceInstanceRangeLowLimit = deviceInstanceRangeLowLimit;
            this.DeviceInstanceRangeHighLimit = deviceInstanceRangeHighLimit;
        }

        public UnsignedInteger DeviceInstanceRangeLowLimit { get; set; }

        public UnsignedInteger DeviceInstanceRangeHighLimit { get; set; }
    }
}
