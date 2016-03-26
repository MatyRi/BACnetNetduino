using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class ServicesSupported : BitString
    {
        public ServicesSupported() : base(new bool[40]) { }
        public ServicesSupported(ByteStream queue) : base(queue) { }

        public bool AcknowledgeAlarm
        {
            get { return Value[0]; }
            set { Value[0] = value; }
        }

        public bool ConfirmedCovNotification
        {
            get { return Value[1]; }
            set { Value[1] = value; }
        }

        public bool ConfirmedEventNotification
        {
            get { return Value[2]; }
            set { Value[2] = value; }
        }

        public bool GetAlarmSummary
        {
            get { return Value[3]; }
            set { Value[3] = value; }
        }

        public bool GetEnrollmentSummary
        {
            get { return Value[4]; }
            set { Value[4] = value; }
        }

        public bool SubscribeCov
        {
            get { return Value[5]; }
            set { Value[5] = value; }
        }

        public bool isAtomicReadFile()
        {
            return Value[6];
        }

        public void setAtomicReadFile(bool atomicReadFile)
        {
            Value[6] = atomicReadFile;
        }

        public bool isAtomicWriteFile()
        {
            return Value[7];
        }

        public void setAtomicWriteFile(bool atomicWriteFile)
        {
            Value[7] = atomicWriteFile;
        }

        public bool isAddListElement()
        {
            return Value[8];
        }

        public void setAddListElement(bool addListElement)
        {
            Value[8] = addListElement;
        }

        public bool isRemoveListElement()
        {
            return Value[9];
        }

        public void setRemoveListElement(bool removeListElement)
        {
            Value[9] = removeListElement;
        }

        public bool isCreateObject()
        {
            return Value[10];
        }

        public void setCreateObject(bool createObject)
        {
            Value[10] = createObject;
        }

        public bool isDeleteObject()
        {
            return Value[11];
        }

        public void setDeleteObject(bool deleteObject)
        {
            Value[11] = deleteObject;
        }

        public bool isReadProperty()
        {
            return Value[12];
        }

        public void setReadProperty(bool readProperty)
        {
            Value[12] = readProperty;
        }

        public bool isReadPropertyConditional()
        {
            return Value[13];
        }

        public void setReadPropertyConditional(bool readPropertyConditional)
        {
            Value[13] = readPropertyConditional;
        }

        public bool isReadPropertyMultiple()
        {
            return Value[14];
        }

        public void setReadPropertyMultiple(bool readPropertyMultiple)
        {
            Value[14] = readPropertyMultiple;
        }

        public bool isWriteProperty()
        {
            return Value[15];
        }

        public void setWriteProperty(bool writeProperty)
        {
            Value[15] = writeProperty;
        }

        public bool isWritePropertyMultiple()
        {
            return Value[16];
        }

        public void setWritePropertyMultiple(bool writePropertyMultiple)
        {
            Value[16] = writePropertyMultiple;
        }

        public bool isDeviceCommunicationControl()
        {
            return Value[17];
        }

        public void setDeviceCommunicationControl(bool deviceCommunicationControl)
        {
            Value[17] = deviceCommunicationControl;
        }

        public bool isConfirmedPrivateTransfer()
        {
            return Value[18];
        }

        public void setConfirmedPrivateTransfer(bool confirmedPrivateTransfer)
        {
            Value[18] = confirmedPrivateTransfer;
        }

        public bool isConfirmedTextMessage()
        {
            return Value[19];
        }

        public void setConfirmedTextMessage(bool confirmedTextMessage)
        {
            Value[19] = confirmedTextMessage;
        }

        public bool isReinitializeDevice()
        {
            return Value[20];
        }

        public void setReinitializeDevice(bool reinitializeDevice)
        {
            Value[20] = reinitializeDevice;
        }

        public bool isVtOpen()
        {
            return Value[21];
        }

        public void setVtOpen(bool vtOpen)
        {
            Value[21] = vtOpen;
        }

        public bool isVtClose()
        {
            return Value[22];
        }

        public void setVtClose(bool vtClose)
        {
            Value[22] = vtClose;
        }

        public bool isVtData()
        {
            return Value[23];
        }

        public void setVtData(bool vtData)
        {
            Value[23] = vtData;
        }

        public bool isAuthenticate()
        {
            return Value[24];
        }

        public void setAuthenticate(bool authenticate)
        {
            Value[24] = authenticate;
        }

        public bool isRequestKey()
        {
            return Value[25];
        }

        public void setRequestKey(bool requestKey)
        {
            Value[25] = requestKey;
        }

        public bool isIAm()
        {
            return Value[26];
        }

        public void setIAm(bool iAm)
        {
            Value[26] = iAm;
        }

        public bool isIHave()
        {
            return Value[27];
        }

        public void setIHave(bool iHave)
        {
            Value[27] = iHave;
        }

        public bool isUnconfirmedCovNotification()
        {
            return Value[28];
        }

        public void setUnconfirmedCovNotification(bool unconfirmedCovNotification)
        {
            Value[28] = unconfirmedCovNotification;
        }

        public bool isUnconfirmedEventNotification()
        {
            return Value[29];
        }

        public void setUnconfirmedEventNotification(bool unconfirmedEventNotification)
        {
            Value[29] = unconfirmedEventNotification;
        }

        public bool isUnconfirmedPrivateTransfer()
        {
            return Value[30];
        }

        public void setUnconfirmedPrivateTransfer(bool unconfirmedPrivateTransfer)
        {
            Value[30] = unconfirmedPrivateTransfer;
        }

        public bool isUnconfirmedTextMessage()
        {
            return Value[31];
        }

        public void setUnconfirmedTextMessage(bool unconfirmedTextMessage)
        {
            Value[31] = unconfirmedTextMessage;
        }

        public bool isTimeSynchronization()
        {
            return Value[32];
        }

        public void setTimeSynchronization(bool timeSynchronization)
        {
            Value[32] = timeSynchronization;
        }

        public bool isWhoHas()
        {
            return Value[33];
        }

        public void setWhoHas(bool whoHas)
        {
            Value[33] = whoHas;
        }

        public bool isWhoIs()
        {
            return Value[34];
        }

        public void setWhoIs(bool whoIs)
        {
            Value[34] = whoIs;
        }

        public bool isReadRange()
        {
            return Value[35];
        }

        public void setReadRange(bool readRange)
        {
            Value[36] = readRange;
        }

        public bool isUtcTimeSynchronization()
        {
            return Value[36];
        }

        public void setUtcTimeSynchronization(bool utcTimeSynchronization)
        {
            Value[36] = utcTimeSynchronization;
        }

        public bool isLifeSafetyOperation()
        {
            return Value[37];
        }

        public void setLifeSafetyOperation(bool lifeSafetyOperation)
        {
            Value[37] = lifeSafetyOperation;
        }

        public bool isSubscribeCovProperty()
        {
            return Value[38];
        }

        public void setSubscribeCovProperty(bool subscribeCovProperty)
        {
            Value[38] = subscribeCovProperty;
        }

        public bool isGetEventInformation()
        {
            return Value[39];
        }

        public void setGetEventInformation(bool getEventInformation)
        {
            Value[39] = getEventInformation;
        }
    }
}
