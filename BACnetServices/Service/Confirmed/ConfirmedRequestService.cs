using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;
using BACnetServices.Service.Acknowledgement;

namespace BACnetServices.Service.Confirmed
{
    public abstract class ConfirmedRequestService : Service
    {
        public static void checkConfirmedRequestService(ServicesSupported services, byte type) 
        {/*
        if (type == AcknowledgeAlarmRequest.TYPE_ID && services.isAcknowledgeAlarm()) // 0
            return;
        if (type == ConfirmedCovNotificationRequest.TYPE_ID && services.isConfirmedCovNotification()) // 1
            return;
        if (type == ConfirmedEventNotificationRequest.TYPE_ID && services.ConfirmedEventNotification()) // 2
            return;
        if (type == GetAlarmSummaryRequest.TYPE_ID && services.isGetAlarmSummary()) // 3
            return;
        if (type == GetEnrollmentSummaryRequest.TYPE_ID && services.isGetEnrollmentSummary()) // 4
            return;
        if (type == SubscribeCOVRequest.TYPE_ID && services.isSubscribeCov()) // 5
            return;
        if (type == AtomicReadFileRequest.TYPE_ID && services.isAtomicReadFile()) // 6
            return;
        if (type == AtomicWriteFileRequest.TYPE_ID && services.isAtomicWriteFile()) // 7
            return;
        if (type == AddListElementRequest.TYPE_ID && services.isAddListElement()) // 8
            return;
        if (type == RemoveListElementRequest.TYPE_ID && services.isRemoveListElement()) // 9
            return;
        if (type == CreateObjectRequest.TYPE_ID && services.isCreateObject()) // 10
            return;
        if (type == DeleteObjectRequest.TYPE_ID && services.isDeleteObject()) // 11
            return;
        if (type == ReadPropertyRequest.TYPE_ID && services.isReadProperty()) // 12
            return;
        if (type == ReadPropertyConditionalRequest.TYPE_ID && services.isReadPropertyConditional()) // 13
            return;
        if (type == ReadPropertyMultipleRequest.TYPE_ID && services.isReadPropertyMultiple()) // 14
            return;
        if (type == WritePropertyRequest.TYPE_ID && services.isWriteProperty()) // 15
            return;
        if (type == WritePropertyMultipleRequest.TYPE_ID && services.isWritePropertyMultiple()) // 16
            return;
        if (type == DeviceCommunicationControlRequest.TYPE_ID && services.isDeviceCommunicationControl()) // 17
            return;
        if (type == ConfirmedPrivateTransferRequest.TYPE_ID && services.isConfirmedPrivateTransfer()) // 18
            return;
        if (type == ConfirmedTextMessageRequest.TYPE_ID && services.isConfirmedTextMessage()) // 19
            return;
        if (type == ReinitializeDeviceRequest.TYPE_ID && services.isReinitializeDevice()) // 20
            return;
        if (type == VtOpenRequest.TYPE_ID && services.isVtOpen()) // 21
            return;
        if (type == VtCloseRequest.TYPE_ID && services.isVtClose()) // 22
            return;
        if (type == VtDataRequest.TYPE_ID && services.isVtData()) // 23
            return;
        if (type == AuthenticateRequest.TYPE_ID && services.isAuthenticate()) // 24
            return;
        if (type == RequestKeyRequest.TYPE_ID && services.isRequestKey()) // 25
            return;
        if (type == ReadRangeRequest.TYPE_ID && services.isReadRange()) // 26
            return;
        if (type == LifeSafetyOperationRequest.TYPE_ID && services.isLifeSafetyOperation()) // 27
            return;
        if (type == SubscribeCOVPropertyRequest.TYPE_ID && services.isSubscribeCovProperty()) // 28
            return;
        if (type == GetEventInformation.TYPE_ID && services.isGetEventInformation()) // 29
            return;
            */
        throw new BACnetErrorException(ErrorClass.Device, ErrorCode.ServiceRequestDenied);
    }

    public static ConfirmedRequestService createConfirmedRequestService(byte type, ByteStream queue)
    {
/*
        if (type == AcknowledgeAlarmRequest.TYPE_ID) // 0
            return new AcknowledgeAlarmRequest(queue);
        if (type == ConfirmedCovNotificationRequest.TYPE_ID) // 1
            return new ConfirmedCovNotificationRequest(queue);
        if (type == ConfirmedEventNotificationRequest.TYPE_ID) // 2
            return new ConfirmedEventNotificationRequest(queue);
        if (type == GetAlarmSummaryRequest.TYPE_ID) // 3
            return new GetAlarmSummaryRequest(queue);
        if (type == GetEnrollmentSummaryRequest.TYPE_ID) // 4
            return new GetEnrollmentSummaryRequest(queue);
        if (type == SubscribeCOVRequest.TYPE_ID) // 5
            return new SubscribeCOVRequest(queue);
        if (type == AtomicReadFileRequest.TYPE_ID) // 6
            return new AtomicReadFileRequest(queue);
        if (type == AtomicWriteFileRequest.TYPE_ID) // 7
            return new AtomicWriteFileRequest(queue);
        if (type == AddListElementRequest.TYPE_ID) // 8
            return new AddListElementRequest(queue);
        if (type == RemoveListElementRequest.TYPE_ID) // 9
            return new RemoveListElementRequest(queue);
        if (type == CreateObjectRequest.TYPE_ID) // 10
            return new CreateObjectRequest(queue);
        if (type == DeleteObjectRequest.TYPE_ID) // 11
            return new DeleteObjectRequest(queue);
        if (type == ReadPropertyRequest.TYPE_ID) // 12
            return new ReadPropertyRequest(queue);
        if (type == ReadPropertyConditionalRequest.TYPE_ID) // 13
            return new ReadPropertyConditionalRequest(queue);
        if (type == ReadPropertyMultipleRequest.TYPE_ID) // 14
            return new ReadPropertyMultipleRequest(queue);
        if (type == WritePropertyRequest.TYPE_ID) // 15
            return new WritePropertyRequest(queue);
        if (type == WritePropertyMultipleRequest.TYPE_ID) // 16
            return new WritePropertyMultipleRequest(queue);
        if (type == DeviceCommunicationControlRequest.TYPE_ID) // 17
            return new DeviceCommunicationControlRequest(queue);
        if (type == ConfirmedPrivateTransferRequest.TYPE_ID) // 18
            return new ConfirmedPrivateTransferRequest(queue);
        if (type == ConfirmedTextMessageRequest.TYPE_ID) // 19
            return new ConfirmedTextMessageRequest(queue);
        if (type == ReinitializeDeviceRequest.TYPE_ID) // 20
            return new ReinitializeDeviceRequest(queue);
        if (type == VtOpenRequest.TYPE_ID) // 21
            return new VtOpenRequest(queue);
        if (type == VtCloseRequest.TYPE_ID) // 22
            return new VtCloseRequest(queue);
        if (type == VtDataRequest.TYPE_ID) // 23
            return new VtDataRequest(queue);
        if (type == AuthenticateRequest.TYPE_ID) // 24
            return new AuthenticateRequest(queue);
        if (type == RequestKeyRequest.TYPE_ID) // 25
            return new RequestKeyRequest(queue);
        if (type == ReadRangeRequest.TYPE_ID) // 26
            return new ReadRangeRequest(queue);
        if (type == LifeSafetyOperationRequest.TYPE_ID) // 27
            return new LifeSafetyOperationRequest(queue);
        if (type == SubscribeCOVPropertyRequest.TYPE_ID) // 28
            return new SubscribeCOVPropertyRequest(queue);
        if (type == GetEventInformation.TYPE_ID) // 29
            return new GetEventInformation(queue);
            */
        throw new BACnetErrorException(ErrorClass.Device, ErrorCode.ServiceRequestDenied);
}

        public abstract AcknowledgementService handle(/*LocalDevice localDevice,*/ Address from, OctetString linkService);
    }
}
