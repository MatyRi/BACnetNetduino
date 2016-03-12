using System;
using BACnetNetduino.DataTypes.Constructed;
using Microsoft.SPOT;

namespace BACnetNetduino.Service.Unconfirmed
{
    internal abstract class UnconfirmedRequestService : Service
    {
        internal static UnconfirmedRequestService createUnconfirmedRequestService(ServicesSupported Service, byte type, ByteStream source)
        {
            if (type == IAmRequest.TYPE_ID)
            {
                //if (services.isIAm())
                    return new IAmRequest(source);
                //return null;
            }

            /*if (type == IHaveRequest.TYPE_ID)
            {
                if (services.isIHave())
                    return new IHaveRequest(source);
                return null;
            }

            if (type == UnconfirmedCovNotificationRequest.TYPE_ID)
            {
                if (services.isUnconfirmedCovNotification())
                    return new UnconfirmedCovNotificationRequest(source);
                return null;
            }

            if (type == UnconfirmedEventNotificationRequest.TYPE_ID)
            {
                if (services.isUnconfirmedEventNotification())
                    return new UnconfirmedEventNotificationRequest(source);
                return null;
            }

            if (type == UnconfirmedPrivateTransferRequest.TYPE_ID)
            {
                if (services.isUnconfirmedPrivateTransfer())
                    return new UnconfirmedPrivateTransferRequest(source);
                return null;
            }

            if (type == UnconfirmedTextMessageRequest.TYPE_ID)
            {
                if (services.isUnconfirmedTextMessage())
                    return new UnconfirmedTextMessageRequest(source);
                return null;
            }

            if (type == TimeSynchronizationRequest.TYPE_ID)
            {
                if (services.isTimeSynchronization())
                    return new TimeSynchronizationRequest(source);
                return null;
            }

            if (type == WhoHasRequest.TYPE_ID)
            {
                if (services.isWhoHas())
                    return new WhoHasRequest(source);
                return null;
            }

            if (type == WhoIsRequest.TYPE_ID)
            {
                if (services.isWhoIs())
                    return new WhoIsRequest(queue);
                return null;
            }

            if (type == UTCTimeSynchronizationRequest.TYPE_ID)
            {
                if (services.isUtcTimeSynchronization())
                    return new UTCTimeSynchronizationRequest(queue);
                return null;
            }*/

            throw new System.Exception("Unsupported unconfirmed service: " + (type & 0xff));
        }
    }
}
