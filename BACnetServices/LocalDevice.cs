using System;
using System.Collections;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;
using BACnetServices.APDU;
using BACnetServices.Objects;
using BACnetServices.Service.Unconfirmed;
using Microsoft.SPOT;
using DateTime = System.DateTime;

namespace BACnetServices
{
    /**
 * Enhancements: - default character string encoding - BIBBs (B-OWS) (services to implement) - AE-N-A - AE-ACK-A -
 * AE-INFO-A - AE-ESUM-A - SCHED-A - T-VMT-A - T-ATR-A - DM-DDB-A,B - DM-DOB-A,B - DM-DCC-A - DM-TS-A - DM-UTC-A -
 * DM-RD-A - DM-BR-A - NM-CE-A
 * 
 * @author mlohbihler
 */
    public class LocalDevice
    {
        private static readonly uint VENDOR_ID = 888; // Safecontrol Vendor ID
        private static readonly string VENDOR_STRING = "MatyRi Soft";

        private static readonly string FIRMWARE_REVISION = "1.0.0";
        private static readonly string APPLICATION_SOFTWARE_VERSION = "1.0.1";

        private readonly ApplicationLayer applicationLayer;
        private BACnetObject configuration;
        //private readonly List<BACnetObject> localObjects = new CopyOnWriteArrayList<BACnetObject>();
        private readonly IList localObjects = new ArrayList();
        //private readonly List<RemoteDevice> remoteDevices = new CopyOnWriteArrayList<RemoteDevice>();
        private bool initialized;
        //private ExecutorService executorService;
        private bool ownsExecutorService;


        /**
         * The local password of the device. Used in the ReinitializeDeviceRequest service.
         */
        private string password = "";

        private bool strict;

        // Event listeners
        //private readonly DeviceEventHandler eventHandler = new DeviceEventHandler();
        //private readonly DeviceEventHandler eventHandler = new DeviceEventAsyncHandler();

        public LocalDevice(uint deviceId, ApplicationLayer applicationLayer, string deviceName, string modelName)
        {
            this.applicationLayer = applicationLayer;
            applicationLayer.Device = this;

            initEventHandlers();

            try
            {
                ObjectIdentifier deviceIdentifier = new ObjectIdentifier(ObjectType.device, deviceId);

                configuration = new BACnetObject(this, deviceIdentifier);
                configuration.setProperty(PropertyIdentifier.maxApduLengthAccepted, new UnsignedInteger(1476));
                configuration.setProperty(PropertyIdentifier.vendorIdentifier, new Unsigned16(VENDOR_ID));
                configuration.setProperty(PropertyIdentifier.vendorName, new CharacterString(VENDOR_STRING));
                configuration.setProperty(PropertyIdentifier.segmentationSupported, Segmentation.segmentedBoth);

                /*TODO SequenceOf<ObjectIdentifier> objectList = new SequenceOf<ObjectIdentifier>();
                objectList.add(deviceIdentifier);
                configuration.setProperty(PropertyIdentifier.objectList, objectList);*/

                // Set up the supported services indicators. Remove lines as services get implemented.
                ServicesSupported servicesSupported = new ServicesSupported();
                servicesSupported.setAll(false);
                servicesSupported.setAcknowledgeAlarm(true);
                servicesSupported.setConfirmedCovNotification(true);
                servicesSupported.setConfirmedEventNotification(true);
                servicesSupported.setGetAlarmSummary(true);
                servicesSupported.setGetEnrollmentSummary(true);
                servicesSupported.setGetEventInformation(true);
                servicesSupported.setIAm(true);
                servicesSupported.setIHave(true);
                servicesSupported.setReadProperty(true);
                servicesSupported.setReadPropertyMultiple(true);
                servicesSupported.setReinitializeDevice(true);
                servicesSupported.setSubscribeCov(true);
                servicesSupported.setTimeSynchronization(true);
                servicesSupported.setUnconfirmedCovNotification(true);
                servicesSupported.setUnconfirmedEventNotification(true);
                servicesSupported.setWhoHas(true);
                servicesSupported.setWhoIs(true);
                servicesSupported.setWriteProperty(true);
                servicesSupported.setWritePropertyMultiple(true);
                servicesSupported.setDeviceCommunicationControl(true);

                //servicesSupported.setAll(true);
                //AdK
                //servicesSupported.setAcknowledgeAlarm(false);
                /*
                servicesSupported.setGetAlarmSummary(true);
                servicesSupported.setGetEnrollmentSummary(true);
                servicesSupported.setAtomicReadFile(false);
                servicesSupported.setAtomicWriteFile(false);
                servicesSupported.setAddListElement(false);
                servicesSupported.setRemoveListElement(false);
                servicesSupported.setReadPropertyConditional(false);
                servicesSupported.setDeviceCommunicationControl(false);
                servicesSupported.setReinitializeDevice(false);
                servicesSupported.setVtOpen(false);
                servicesSupported.setVtClose(false);
                servicesSupported.setVtData(false);
                servicesSupported.setAuthenticate(false);
                servicesSupported.setRequestKey(false);
                servicesSupported.setTimeSynchronization(true);
                servicesSupported.setReadRange(false);
                servicesSupported.setUtcTimeSynchronization(true);
                servicesSupported.setLifeSafetyOperation(false);
                //servicesSupported.setSubscribeCovProperty(true);
                //servicesSupported.setGetEventInformation(true);
                */

                configuration.setProperty(PropertyIdentifier.protocolServicesSupported, servicesSupported);

                // Set up the object types supported.
                /* TODO ObjectTypesSupported objectTypesSupported = new ObjectTypesSupported();
                objectTypesSupported.setAll(false);

                objectTypesSupported.setDevice(true);

                objectTypesSupported.setAnalogInput(true);
                objectTypesSupported.setAnalogOutput(true);
                objectTypesSupported.setAnalogValue(true);

                objectTypesSupported.setBinaryInput(true);
                objectTypesSupported.setBinaryOutput(true);
                objectTypesSupported.setBinaryValue(true);

                objectTypesSupported.setMultiStateInput(true);
                objectTypesSupported.setMultiStateOutput(true);
                objectTypesSupported.setMultiStateValue(true);

                objectTypesSupported.setNotificationClass(true);

                configuration.setProperty(PropertyIdentifier.protocolObjectTypesSupported, objectTypesSupported);*/

                // Set some other required values to defaults
                configuration.setProperty(PropertyIdentifier.objectName, new CharacterString(deviceName));
                configuration.setProperty(PropertyIdentifier.systemStatus, DeviceStatus.operational);
                configuration.setProperty(PropertyIdentifier.modelName, new CharacterString(modelName));
                configuration.setProperty(PropertyIdentifier.firmwareRevision, new CharacterString(FIRMWARE_REVISION));
                configuration.setProperty(PropertyIdentifier.applicationSoftwareVersion, new CharacterString(APPLICATION_SOFTWARE_VERSION));
                configuration.setProperty(PropertyIdentifier.protocolVersion, new UnsignedInteger(1));
                configuration.setProperty(PropertyIdentifier.protocolRevision, new UnsignedInteger(0));
                configuration.setProperty(PropertyIdentifier.databaseRevision, new UnsignedInteger(0));
            }
            catch (BACnetServiceException e)
            {
                // Should never happen, but wrap in an unchecked just in case.
                throw new BACnetRuntimeException(e);
            }
        }

        private void initEventHandlers()
        {
            applicationLayer.UnconfirmedRequestReceived += OnUnconfirmedRequestReceived;
            applicationLayer.ConfirmedRequestReceived += OnConfirmedRequestReceived;
        }

        private void OnConfirmedRequestReceived(Address fromAddress, OctetString linkService, int invokeId, ConfirmedRequest request)
        {
            if (request.getServiceRequest() == null) { return; }

            try
            {
                request.getServiceRequest().handle(fromAddress, linkService);
            }
            catch (NotImplementedException e)
            {
                Debug.Print("Unsupported confirmed request: invokeId=" + invokeId + ", from=" + fromAddress + ", request=" + request.getServiceRequest().GetType().FullName);
                throw new BACnetErrorException(ErrorClass.services, ErrorCode.serviceRequestDenied);
            }
            catch (BACnetErrorException e)
            {
                throw e;
            }
            catch (System.Exception e)
            {
                throw new BACnetErrorException(ErrorClass.device, ErrorCode.operationalProblem);
            }




            // TODO X BACNET Original
            // TODO sendResponse(address, linkService, confAPDU, ackService);

            // TODO X BACNET Maty - oprava NPEx
            /*new Thread(new Runnable() {
                    @Override
                    public void run() {
                        try {
                            sendResponse(address, linkService, confAPDU, ackService);
                        }
                        catch (BACnetException e) {
                            e.printStackTrace();
                        }
                    }
                }).start();*/
        }

        private void OnUnconfirmedRequestReceived(Address fromAddress, OctetString linkService, UnconfirmedRequest request)
        {
            if (request.getService() == null) { return; } // HOT FIX

            try
            {
                request.getService().handle(this, fromAddress, linkService);
            }
            catch (BACnetException e)
            {
                // TODO ExceptionDispatch.fireReceivedException(e);
            }
        }

        //        public ExecutorService getExecutorService()
        //        {
        //            return executorService;
        //        }

        //        public void setExecutorService(ExecutorService executorService)
        //        {
        //            if (initialized)
        //                throw new IllegalStateException("Cannot set the executor service. Already initialized");
        //            this.executorService = executorService;
        //        }

        //        public NetworkIdentifier getNetworkIdentifier()
        //        {
        //            return applicationLayer.getNetworkIdentifier();
        //        }

        //        /**
        //         * @return the strict
        //         */
        //        public bool isStrict()
        //        {
        //            return strict;
        //        }

        //        /**
        //         * @param strict
        //         *            the strict to set
        //         */
        //        public void setStrict(bool strict)
        //        {
        //            this.strict = strict;
        //        }

        //        public void initialize() // Sync
        //        {
        //        if (executorService == null) {
        //                executorService = Executors.newCachedThreadPool();
        //                ownsExecutorService = true;
        //            }
        //        else
        //            ownsExecutorService = false;
        //            // For the async handler
        //            //eventHandler.initialize(executorService);
        //            applicationLayer.initialize();
        //            initialized = true;
        //        }

        //        public void terminate() // Sync
        //        {
        //            applicationLayer.terminate();
        //            initialized = false;

        //            if (ownsExecutorService)
        //            {
        //                ExecutorService temp = executorService;
        //                executorService = null;
        //                if (temp != null)
        //                {
        //                    temp.shutdown();
        //                    try
        //                    {
        //                        temp.awaitTermination(3, TimeUnit.SECONDS);
        //                    }
        //                    catch (InterruptedException e)
        //                    {
        //                        // no op
        //                    }
        //                }
        //            }
        //        }

        //        public bool isInitialized()
        //        {
        //            return initialized;
        //        }

        internal bool Initialized => initialized;

        internal BACnetObject Configuration => configuration;


        //        public DeviceEventHandler getEventHandler()
        //        {
        //            return eventHandler;
        //        }

        internal string Password
        {
            get { return password;}
            set { password = value ?? ""; }
        }

        //        //
        //        //
        //        // Local object management
        //        //
        //        public BACnetObject getObjectRequired(ObjectIdentifier id)
        //        {
        //            BACnetObject o = getObject(id);
        //        if (o == null)
        //            throw new BACnetServiceException(ErrorClass.object, ErrorCode.unknownObject);
        //        return o;
        //    }

        public IList LocalObjects => localObjects;

        //    public BACnetObject getObject(ObjectIdentifier id)
        //    {
        //        if (id.getObjectType().intValue() == ObjectType.device.intValue())
        //        {
        //            // Check if we need to look into the local device.
        //            if (id.getInstanceNumber() == 0x3FFFFF || id.getInstanceNumber() == configuration.getInstanceId())
        //                return configuration;
        //        }

        //        for (BACnetObject obj : localObjects)
        //        {
        //            if (obj.getId().equals(id))
        //                return obj;
        //        }
        //        return null;
        //    }

        //    public BACnetObject getObject(string name)
        //    {
        //        // Check if we need to look into the local device.
        //        if (name.equals(configuration.getObjectName()))
        //            return configuration;

        //        for (BACnetObject obj : localObjects)
        //        {
        //            if (name.equals(obj.getObjectName()))
        //                return obj;
        //        }
        //        return null;
        //    }

        //    public void addObject(BACnetObject obj)
        //    {
        //        if (getObject(obj.getId()) != null)
        //            throw new BACnetServiceException(ErrorClass.object, ErrorCode.objectIdentifierAlreadyExists, obj.getId().toString());
        //        if (getObject(obj.getObjectName()) != null)
        //            throw new BACnetServiceException(ErrorClass.object, ErrorCode.duplicateName);
        //    obj.validate();
        //        localObjects.add(obj);

        //        // Create a reference in the device's object list for the new object.
        //        getObjectList().add(obj.getId());
        //    }

        //// TODO MATY - Reuse
        //public ObjectIdentifier getNextInstanceObjectIdentifier(ObjectType objectType)
        //{
        //    // Make a list of existing ids.
        //    List<Integer> ids = new ArrayList<Integer>();
        //    int type = objectType.intValue();
        //    ObjectIdentifier id;
        //    for (BACnetObject obj : localObjects)
        //    {
        //        id = obj.getId();
        //        if (id.getObjectType().intValue() == type)
        //            ids.add(id.getInstanceNumber());
        //    }

        //    // Sort the list.
        //    Collections.sort(ids);

        //    // Find the first hole in the list.
        //    int i = 0;
        //    for (; i < ids.size(); i++)
        //    {
        //        if (ids.get(i) != i)
        //            break;
        //    }
        //    return new ObjectIdentifier(objectType, i);
        //}

        //public void removeObject(ObjectIdentifier id)
        //{
        //    BACnetObject obj = getObject(id);
        //        if (obj != null)
        //            localObjects.remove(obj);
        //        else
        //            throw new BACnetServiceException(ErrorClass.object, ErrorCode.unknownObject);

        //        // Remove the reference in the device's object list for this id.
        //        getObjectList().remove(id);
        //    }

        //    private SequenceOf<ObjectIdentifier> getObjectList()
        //{
        //    try
        //    {
        //        return (SequenceOf<ObjectIdentifier>)configuration.getProperty(PropertyIdentifier.objectList);
        //    }
        //    catch (BACnetServiceException e)
        //    {
        //        // Should never happen, so just wrap in a RuntimeException
        //        throw new RuntimeException(e);
        //    }
        //}

        internal ServicesSupported ServicesSupported
            =>
                (ServicesSupported)
                    Configuration.getProperty(PropertyIdentifier.protocolServicesSupported);

        ////
        ////
        //// Message sending
        ////
        //public AcknowledgementService send(RemoteDevice d, ConfirmedRequestService serviceRequest)
        //{
        //        return applicationLayer.send(d.getAddress(), d.getLinkService(), d.getMaxAPDULengthAccepted(),
        //                d.getSegmentationSupported(), serviceRequest);
        //}

        //public AcknowledgementService send(Address address, MaxApduLength maxAPDULength,
        //        Segmentation segmentationSupported, ConfirmedRequestService serviceRequest)
        //{
        //        return applicationLayer.send(address, null, maxAPDULength.getMaxLength(), segmentationSupported, serviceRequest);
        //}

        //public AcknowledgementService send(Address address, OctetString linkService, MaxApduLength maxAPDULength,
        //        Segmentation segmentationSupported, ConfirmedRequestService serviceRequest)
        //{
        //        return applicationLayer
        //                .send(address, linkService, maxAPDULength.getMaxLength(), segmentationSupported, serviceRequest);
        //}

        //public void sendUnconfirmed(Address address, UnconfirmedRequestService serviceRequest)
        //{
        //    applicationLayer.sendUnconfirmed(address, null, serviceRequest, false);
        //}

        //public void sendUnconfirmed(Address address, OctetString linkService, UnconfirmedRequestService serviceRequest)
        //            throws BACnetException
        //{
        //    applicationLayer.sendUnconfirmed(address, linkService, serviceRequest, false);
        //}

        //public void sendLocalBroadcast(UnconfirmedRequestService serviceRequest)
        //{
        //    Address bcast = applicationLayer.getLocalBroadcastAddress();
        //    applicationLayer.sendUnconfirmed(bcast, null, serviceRequest, true);
        //}

        internal void sendGlobalBroadcast(UnconfirmedRequestService serviceRequest)
        {
            applicationLayer.sendUnconfirmed(Address.GLOBAL, null, serviceRequest, true);
        }

        //AdK - DCC
        internal void sendGlobalBroadcast(UnconfirmedRequestService serviceRequest, bool initiated)
        {
            applicationLayer.sendUnconfirmed(Address.GLOBAL, null, serviceRequest, true, initiated);
        }

        //public void sendBroadcast(Address address, OctetString linkService, UnconfirmedRequestService serviceRequest)
        //{
        //    applicationLayer.sendUnconfirmed(address, linkService, serviceRequest, true);
        //}

        ////
        ////
        //// Remote device management
        ////
        //public RemoteDevice getRemoteDevice(int instanceId) 
        //{
        //    RemoteDevice d = getRemoteDeviceImpl(instanceId, null, null);
        //        if (d == null)
        //            throw new BACnetException("Unknown device: instance id=" + instanceId);
        //        return d;
        //    }

        //    public RemoteDevice getRemoteDevice(int instanceId, Address address, OctetString linkService)
        //            throws BACnetException
        //{
        //    RemoteDevice d = getRemoteDeviceImpl(instanceId, address, linkService);
        //        if (d == null)
        //            throw new BACnetException("Unknown device: instance id=" + instanceId + ", address=" + address
        //                    + ", linkService=" + linkService);
        //        return d;
        //    }

        //    public RemoteDevice getRemoteDeviceCreate(int instanceId, Address address, OctetString linkService)
        //{
        //    RemoteDevice d = getRemoteDeviceImpl(instanceId, address, linkService);
        //    if (d == null)
        //    {
        //        if (address == null)
        //            throw new NullPointerException("addr cannot be null");
        //        d = new RemoteDevice(instanceId, address, linkService);
        //        remoteDevices.add(d);
        //    }
        //    return d;
        //}

        //public void addRemoteDevice(RemoteDevice d)
        //{
        //    remoteDevices.add(d);
        //}

        //private RemoteDevice getRemoteDeviceImpl(int instanceId, Address address, OctetString linkService)
        //{
        //    for (RemoteDevice d : remoteDevices)
        //    {
        //        if (strict || address == null)
        //        {
        //            // Only compare by device id, as should be sufficient according to the spec's insistence on 
        //            // unique device ids.
        //            if (d.getInstanceNumber() == instanceId)
        //                return d;
        //        }
        //        else {
        //            // Compare device ids and address.
        //            if (d.getInstanceNumber() == instanceId && d.getAddress().equals(address)
        //                    && ObjectUtils.equals(d.getLinkService(), linkService))
        //                return d;
        //        }
        //    }
        //    return null;
        //}

        //public List<RemoteDevice> getRemoteDevices()
        //{
        //    return remoteDevices;
        //}

        //public RemoteDevice getRemoteDevice(Address address)
        //{
        //    for (RemoteDevice d : remoteDevices)
        //    {
        //        if (d.getAddress().equals(address))
        //            return d;
        //    }
        //    return null;
        //}

        //public RemoteDevice getRemoteDeviceByUserData(Object userData)
        //{
        //    for (RemoteDevice d : remoteDevices)
        //    {
        //        if (ObjectUtils.equals(userData, d.getUserData()))
        //            return d;
        //    }
        //    return null;
        //}

        //    //
        //    //
        //    // Intrinsic events
        //    //
        //    public List<BACnetException> sendIntrinsicEvent(ObjectIdentifier eventObjectIdentifier, TimeStamp timeStamp,
        //            int notificationClassId, EventType eventType, CharacterString messageText, NotifyType notifyType,
        //            EventState fromState, EventState toState, NotificationParameters eventValues)
        //{

        //    // Try to find a notification class with the given id in the local objects.
        //    BACnetObject nc = null;
        //        foreach (BACnetObject obj : localObjects) {
        //        if (ObjectType.notificationClass.equals(obj.getId().getObjectType()))
        //        {
        //            try
        //            {
        //                UnsignedInteger ncId = (UnsignedInteger)obj.getProperty(PropertyIdentifier.notificationClass);
        //                if (ncId != null && ncId.intValue() == notificationClassId)
        //                {
        //                    nc = obj;
        //                    break;
        //                }
        //            }
        //            catch (BACnetServiceException e)
        //            {
        //                // Should never happen, so wrap in a RTE
        //                throw new RuntimeException(e);
        //            }
        //        }
        //    }

        //        if (nc == null)
        //            throw new BACnetException("Notification class object not found for given id: " + notificationClassId);

        //// Get the required properties from the notification class object.
        //SequenceOf<Destination> recipientList = null;
        //Boolean ackRequired = null;
        //UnsignedInteger priority = null;
        //        try {
        //            recipientList = (SequenceOf<Destination>) nc.getPropertyRequired(PropertyIdentifier.recipientList);
        //            ackRequired = new Boolean(
        //                    ((EventTransitionBits) nc.getPropertyRequired(PropertyIdentifier.ackRequired)).contains(toState));

        //            // Determine which priority value to use based upon the toState.
        //            SequenceOf<UnsignedInteger> priorities = (SequenceOf<UnsignedInteger>)nc
        //                    .getPropertyRequired(PropertyIdentifier.priority);
        //            if (toState.equals(EventState.normal))
        //                priority = priorities.get(3);
        //            else if (toState.equals(EventState.fault))
        //                priority = priorities.get(2);
        //            else
        //                // everything else is offnormal
        //                priority = priorities.get(1);
        //        }
        //        catch (BACnetServiceException e) {
        //            // Should never happen, so wrap in a RTE
        //            throw new RuntimeException(e);
        //        }

        //        // Send the message to the destinations that are interested in it, while recording any exceptions in the result
        //        // list
        //        List<BACnetException> sendExceptions = new ArrayList<BACnetException>();
        //        for (Destination destination : recipientList) {
        //            if (destination.isSuitableForEvent(timeStamp, toState)) {
        //                if (destination.getIssueConfirmedNotifications().boolValue()) {
        //                    RemoteDevice remoteDevice = null;
        //                    if (destination.getRecipient().isAddress())
        //                        remoteDevice = getRemoteDevice(destination.getRecipient().getAddress());
        //                    else {
        //                    	//AdK
        //                    	try {
        //                    		remoteDevice = getRemoteDevice(destination.getRecipient().getObjectIdentifier()
        //                                .getInstanceNumber());
        //                    	} catch (BACnetException e) {
        //                    		System.out.println("Unknown device " + destination.getRecipient().getObjectIdentifier()
        //                                    .getInstanceNumber());
        //                    		continue;
        //                    	}
        //                    }
        //                    if (remoteDevice != null) {
        //                        ConfirmedEventNotificationRequest req = new ConfirmedEventNotificationRequest(
        //                                destination.getProcessIdentifier(), configuration.getId(), eventObjectIdentifier,
        //                                timeStamp, new UnsignedInteger(notificationClassId), priority, eventType, messageText,
        //                                notifyType, ackRequired, fromState, toState, eventValues);

        //                        try {
        //                            send(remoteDevice, req);
        //                        }
        //                        catch (BACnetException e) {
        //                            sendExceptions.add(e);
        //                        }
        //                    }
        //                }
        //                else {
        //                    Address address = null;
        //                    if (destination.getRecipient().isAddress())
        //                        address = destination.getRecipient().getAddress();
        //                    else {
        //                        RemoteDevice remoteDevice = getRemoteDevice(destination.getRecipient().getObjectIdentifier()
        //                                .getInstanceNumber());
        //                        if (remoteDevice != null)
        //                            address = remoteDevice.getAddress();
        //                    }

        //                    if (address != null) {
        //                        UnconfirmedEventNotificationRequest req = new UnconfirmedEventNotificationRequest(
        //                                destination.getProcessIdentifier(), configuration.getId(), eventObjectIdentifier,
        //                                timeStamp, new UnsignedInteger(notificationClassId), priority, eventType, messageText,
        //                                notifyType, ackRequired, fromState, toState, eventValues);
        //                        try {
        //                            applicationLayer.sendUnconfirmed(address, null, req, false);
        //                        }
        //                        catch (BACnetException e) {
        //                            sendExceptions.add(e);
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        return sendExceptions;
        //    }

        //    //
        //    //
        //    // Convenience methods
        //    //
        internal Address[] AllLocalAddresses => applicationLayer.NetworkLayer.AllLocalAddresses;

        internal IAmRequest MakeIAmRequest()
        {
            try
            {
                return new IAmRequest(configuration.getId(),
                        (UnsignedInteger)configuration.getProperty(PropertyIdentifier.maxApduLengthAccepted),
                        (Segmentation)configuration.getProperty(PropertyIdentifier.segmentationSupported),
                        (Unsigned16)configuration.getProperty(PropertyIdentifier.vendorIdentifier));
            }
            catch (BACnetServiceException e)
            {
                // Should never happen, so just wrap in a RuntimeException
                throw new System.Exception(e.Message);
            }
        }

        ////
        //// Manual device discovery
        //public RemoteDevice findRemoteDevice(Address address, OctetString linkService, int deviceId) 
        //{
        //    RemoteDevice d = getRemoteDeviceImpl(deviceId, address, linkService);
        //        if (d != null)
        //            return d;

        //    ObjectIdentifier deviceOid = new ObjectIdentifier(ObjectType.device, deviceId);
        //ReadPropertyRequest req = new ReadPropertyRequest(deviceOid, PropertyIdentifier.maxApduLengthAccepted);
        //ReadPropertyAck ack = (ReadPropertyAck)applicationLayer.send(address, linkService,
        //        MaxApduLength.UP_TO_50.getMaxLength(), Segmentation.noSegmentation, req);

        //// If we got this far, then we got a response. Now get the other required properties.
        //d = new RemoteDevice(deviceOid.getInstanceNumber(), address, linkService);
        //        d.setMaxAPDULengthAccepted(((UnsignedInteger) ack.getValue()).intValue());
        //        d.setSegmentationSupported(Segmentation.noSegmentation);

        //        Map<PropertyIdentifier, Encodable> map = RequestUtils.getProperties(this, d, null,
        //                PropertyIdentifier.segmentationSupported, PropertyIdentifier.vendorIdentifier,
        //                PropertyIdentifier.protocolServicesSupported);
        //d.setSegmentationSupported((Segmentation) map.get(PropertyIdentifier.segmentationSupported));
        //        d.setVendorId(((Unsigned16) map.get(PropertyIdentifier.vendorIdentifier)).intValue());
        //        d.setServicesSupported((ServicesSupported) map.get(PropertyIdentifier.protocolServicesSupported));

        //        addRemoteDevice(d);

        //        return d;
        //    }


        public int NetworkNumber => applicationLayer.NetworkLayer.LocalNetworkNumber;

        //    public int getNetworkNumber()
        //{
        //    return this.applicationLayer.getNetwork().getLocalNetworkNumber();
        //}

        ////AdK - support for DeviceCommunicationControl
        private EnableDisable enableDisable = EnableDisable.enable;
        private DateTime endTime = DateTime.MinValue;
        
        internal EnableDisable DCCEnableDisable
        {
            get
            {
                // check if disable is still active
                // TODO Test
                if (endTime != DateTime.MinValue && DateTime.Now.CompareTo(endTime) > 0) // is after endTime
                {
                    enableDisable = EnableDisable.enable;
                    endTime = DateTime.MinValue;
                }

                return enableDisable;
            }
            set
            {
                Debug.Print("DCC state changed: " + value);
                enableDisable = value;
            }
        }

        public DateTime DCCEndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }
}
