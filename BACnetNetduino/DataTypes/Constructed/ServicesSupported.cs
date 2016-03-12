using System;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class ServicesSupported : BitString
    {
        public ServicesSupported() : base(new bool[40]) { }
        public ServicesSupported(ByteStream queue) : base(queue) { }

        public bool isAcknowledgeAlarm()
        {
            return getValue()[0];
        }

        public void setAcknowledgeAlarm(bool acknowledgeAlarm)
        {
            getValue()[0] = acknowledgeAlarm;
        }

        public bool isConfirmedCovNotification()
        {
            return getValue()[1];
        }

        public void setConfirmedCovNotification(bool confirmedCovNotification)
        {
            getValue()[1] = confirmedCovNotification;
        }

        public bool isConfirmedEventNotification()
        {
            return getValue()[2];
        }

        public void setConfirmedEventNotification(bool confirmedEventNotification)
        {
            getValue()[2] = confirmedEventNotification;
        }

        public bool isGetAlarmSummary()
        {
            return getValue()[3];
        }

        public void setGetAlarmSummary(bool getAlarmSummary)
        {
            getValue()[3] = getAlarmSummary;
        }

        public bool isGetEnrollmentSummary()
        {
            return getValue()[4];
        }

        public void setGetEnrollmentSummary(bool getEnrollmentSummary)
        {
            getValue()[4] = getEnrollmentSummary;
        }

        public bool isSubscribeCov()
        {
            return getValue()[5];
        }

        public void setSubscribeCov(bool subscribeCov)
        {
            getValue()[5] = subscribeCov;
        }

        public bool isAtomicReadFile()
        {
            return getValue()[6];
        }

        public void setAtomicReadFile(bool atomicReadFile)
        {
            getValue()[6] = atomicReadFile;
        }

        public bool isAtomicWriteFile()
        {
            return getValue()[7];
        }

        public void setAtomicWriteFile(bool atomicWriteFile)
        {
            getValue()[7] = atomicWriteFile;
        }

        public bool isAddListElement()
        {
            return getValue()[8];
        }

        public void setAddListElement(bool addListElement)
        {
            getValue()[8] = addListElement;
        }

        public bool isRemoveListElement()
        {
            return getValue()[9];
        }

        public void setRemoveListElement(bool removeListElement)
        {
            getValue()[9] = removeListElement;
        }

        public bool isCreateObject()
        {
            return getValue()[10];
        }

        public void setCreateObject(bool createObject)
        {
            getValue()[10] = createObject;
        }

        public bool isDeleteObject()
        {
            return getValue()[11];
        }

        public void setDeleteObject(bool deleteObject)
        {
            getValue()[11] = deleteObject;
        }

        public bool isReadProperty()
        {
            return getValue()[12];
        }

        public void setReadProperty(bool readProperty)
        {
            getValue()[12] = readProperty;
        }

        public bool isReadPropertyConditional()
        {
            return getValue()[13];
        }

        public void setReadPropertyConditional(bool readPropertyConditional)
        {
            getValue()[13] = readPropertyConditional;
        }

        public bool isReadPropertyMultiple()
        {
            return getValue()[14];
        }

        public void setReadPropertyMultiple(bool readPropertyMultiple)
        {
            getValue()[14] = readPropertyMultiple;
        }

        public bool isWriteProperty()
        {
            return getValue()[15];
        }

        public void setWriteProperty(bool writeProperty)
        {
            getValue()[15] = writeProperty;
        }

        public bool isWritePropertyMultiple()
        {
            return getValue()[16];
        }

        public void setWritePropertyMultiple(bool writePropertyMultiple)
        {
            getValue()[16] = writePropertyMultiple;
        }

        public bool isDeviceCommunicationControl()
        {
            return getValue()[17];
        }

        public void setDeviceCommunicationControl(bool deviceCommunicationControl)
        {
            getValue()[17] = deviceCommunicationControl;
        }

        public bool isConfirmedPrivateTransfer()
        {
            return getValue()[18];
        }

        public void setConfirmedPrivateTransfer(bool confirmedPrivateTransfer)
        {
            getValue()[18] = confirmedPrivateTransfer;
        }

        public bool isConfirmedTextMessage()
        {
            return getValue()[19];
        }

        public void setConfirmedTextMessage(bool confirmedTextMessage)
        {
            getValue()[19] = confirmedTextMessage;
        }

        public bool isReinitializeDevice()
        {
            return getValue()[20];
        }

        public void setReinitializeDevice(bool reinitializeDevice)
        {
            getValue()[20] = reinitializeDevice;
        }

        public bool isVtOpen()
        {
            return getValue()[21];
        }

        public void setVtOpen(bool vtOpen)
        {
            getValue()[21] = vtOpen;
        }

        public bool isVtClose()
        {
            return getValue()[22];
        }

        public void setVtClose(bool vtClose)
        {
            getValue()[22] = vtClose;
        }

        public bool isVtData()
        {
            return getValue()[23];
        }

        public void setVtData(bool vtData)
        {
            getValue()[23] = vtData;
        }

        public bool isAuthenticate()
        {
            return getValue()[24];
        }

        public void setAuthenticate(bool authenticate)
        {
            getValue()[24] = authenticate;
        }

        public bool isRequestKey()
        {
            return getValue()[25];
        }

        public void setRequestKey(bool requestKey)
        {
            getValue()[25] = requestKey;
        }

        public bool isIAm()
        {
            return getValue()[26];
        }

        public void setIAm(bool iAm)
        {
            getValue()[26] = iAm;
        }

        public bool isIHave()
        {
            return getValue()[27];
        }

        public void setIHave(bool iHave)
        {
            getValue()[27] = iHave;
        }

        public bool isUnconfirmedCovNotification()
        {
            return getValue()[28];
        }

        public void setUnconfirmedCovNotification(bool unconfirmedCovNotification)
        {
            getValue()[28] = unconfirmedCovNotification;
        }

        public bool isUnconfirmedEventNotification()
        {
            return getValue()[29];
        }

        public void setUnconfirmedEventNotification(bool unconfirmedEventNotification)
        {
            getValue()[29] = unconfirmedEventNotification;
        }

        public bool isUnconfirmedPrivateTransfer()
        {
            return getValue()[30];
        }

        public void setUnconfirmedPrivateTransfer(bool unconfirmedPrivateTransfer)
        {
            getValue()[30] = unconfirmedPrivateTransfer;
        }

        public bool isUnconfirmedTextMessage()
        {
            return getValue()[31];
        }

        public void setUnconfirmedTextMessage(bool unconfirmedTextMessage)
        {
            getValue()[31] = unconfirmedTextMessage;
        }

        public bool isTimeSynchronization()
        {
            return getValue()[32];
        }

        public void setTimeSynchronization(bool timeSynchronization)
        {
            getValue()[32] = timeSynchronization;
        }

        public bool isWhoHas()
        {
            return getValue()[33];
        }

        public void setWhoHas(bool whoHas)
        {
            getValue()[33] = whoHas;
        }

        public bool isWhoIs()
        {
            return getValue()[34];
        }

        public void setWhoIs(bool whoIs)
        {
            getValue()[34] = whoIs;
        }

        public bool isReadRange()
        {
            return getValue()[35];
        }

        public void setReadRange(bool readRange)
        {
            getValue()[36] = readRange;
        }

        public bool isUtcTimeSynchronization()
        {
            return getValue()[36];
        }

        public void setUtcTimeSynchronization(bool utcTimeSynchronization)
        {
            getValue()[36] = utcTimeSynchronization;
        }

        public bool isLifeSafetyOperation()
        {
            return getValue()[37];
        }

        public void setLifeSafetyOperation(bool lifeSafetyOperation)
        {
            getValue()[37] = lifeSafetyOperation;
        }

        public bool isSubscribeCovProperty()
        {
            return getValue()[38];
        }

        public void setSubscribeCovProperty(bool subscribeCovProperty)
        {
            getValue()[38] = subscribeCovProperty;
        }

        public bool isGetEventInformation()
        {
            return getValue()[39];
        }

        public void setGetEventInformation(bool getEventInformation)
        {
            getValue()[39] = getEventInformation;
        }
    }
}
