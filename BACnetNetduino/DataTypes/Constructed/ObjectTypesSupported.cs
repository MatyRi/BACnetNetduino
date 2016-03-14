using System;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class ObjectTypesSupported : BitString
    {
        public ObjectTypesSupported() : base(new bool[31]) { }

        public ObjectTypesSupported(ByteStream queue) : base(queue) { }

        public bool isAnalogInput()
        {
            return getValue()[0];
        }

        public void setAnalogInput(bool analogInput)
        {
            getValue()[0] = analogInput;
        }

        public bool isAnalogOutput()
        {
            return getValue()[1];
        }

        public void setAnalogOutput(bool analogOutput)
        {
            getValue()[1] = analogOutput;
        }

        public bool isAnalogValue()
        {
            return getValue()[2];
        }

        public void setAnalogValue(bool analogValue)
        {
            getValue()[2] = analogValue;
        }

        public bool isBinaryInput()
        {
            return getValue()[3];
        }

        public void setBinaryInput(bool binaryInput)
        {
            getValue()[3] = binaryInput;
        }

        public bool isBinaryOutput()
        {
            return getValue()[4];
        }

        public void setBinaryOutput(bool binaryOutput)
        {
            getValue()[4] = binaryOutput;
        }

        public bool isBinaryValue()
        {
            return getValue()[5];
        }

        public void setBinaryValue(bool binaryValue)
        {
            getValue()[5] = binaryValue;
        }

        public bool isCalendar()
        {
            return getValue()[6];
        }

        public void setCalendar(bool calendar)
        {
            getValue()[6] = calendar;
        }

        public bool isCommand()
        {
            return getValue()[7];
        }

        public void setCommand(bool command)
        {
            getValue()[7] = command;
        }

        public bool isDevice()
        {
            return getValue()[8];
        }

        public void setDevice(bool device)
        {
            getValue()[8] = device;
        }

        public bool isEventEnrollment()
        {
            return getValue()[9];
        }

        public void setEventEnrollment(bool eventEnrollment)
        {
            getValue()[9] = eventEnrollment;
        }

        public bool isFile()
        {
            return getValue()[10];
        }

        public void setFile(bool file)
        {
            getValue()[10] = file;
        }

        public bool isGroup()
        {
            return getValue()[11];
        }

        public void setGroup(bool group)
        {
            getValue()[11] = group;
        }

        public bool isLoop()
        {
            return getValue()[12];
        }

        public void setLoop(bool loop)
        {
            getValue()[12] = loop;
        }

        public bool isMultiStateInput()
        {
            return getValue()[13];
        }

        public void setMultiStateInput(bool multiStateInput)
        {
            getValue()[13] = multiStateInput;
        }

        public bool isMultiStateOutput()
        {
            return getValue()[14];
        }

        public void setMultiStateOutput(bool multiStateOutput)
        {
            getValue()[14] = multiStateOutput;
        }

        public bool isNotificationClass()
        {
            return getValue()[15];
        }

        public void setNotificationClass(bool notificationClass)
        {
            getValue()[15] = notificationClass;
        }

        public bool isProgram()
        {
            return getValue()[16];
        }

        public void setProgram(bool program)
        {
            getValue()[16] = program;
        }

        public bool isSchedule()
        {
            return getValue()[17];
        }

        public void setSchedule(bool schedule)
        {
            getValue()[17] = schedule;
        }

        public bool isAveraging()
        {
            return getValue()[18];
        }

        public void setAveraging(bool averaging)
        {
            getValue()[18] = averaging;
        }

        public bool isMultiStateValue()
        {
            return getValue()[19];
        }

        public void setMultiStateValue(bool multiStateValue)
        {
            getValue()[19] = multiStateValue;
        }

        public bool isTrendLog()
        {
            return getValue()[20];
        }

        public void setTrendLog(bool trendLog)
        {
            getValue()[20] = trendLog;
        }

        public bool isLifeSafetyPoint()
        {
            return getValue()[21];
        }

        public void setLifeSafetyPoint(bool lifeSafetyPoint)
        {
            getValue()[21] = lifeSafetyPoint;
        }

        public bool isLifeSafetyZone()
        {
            return getValue()[22];
        }

        public void setLifeSafetyZone(bool lifeSafetyZone)
        {
            getValue()[22] = lifeSafetyZone;
        }

        public bool isAccumulator()
        {
            return getValue()[23];
        }

        public void setAccumulator(bool accumulator)
        {
            getValue()[23] = accumulator;
        }

        public bool isPulseConverter()
        {
            return getValue()[24];
        }

        public void setPulseConverter(bool pulseConverter)
        {
            getValue()[24] = pulseConverter;
        }

        public bool isEventLog()
        {
            return getValue()[25];
        }

        public void setEventLog(bool eventLog)
        {
            getValue()[25] = eventLog;
        }

        public bool isTrendLogMultiple()
        {
            return getValue()[27];
        }

        public void setTrendLogMultiple(bool trendLogMultiple)
        {
            getValue()[27] = trendLogMultiple;
        }

        public bool isLoadControl()
        {
            return getValue()[28];
        }

        public void setLoadControl(bool loadControl)
        {
            getValue()[28] = loadControl;
        }

        public bool isStructuredView()
        {
            return getValue()[29];
        }

        public void setStructuredView(bool structuredView)
        {
            getValue()[29] = structuredView;
        }

        public bool isAccessDoor()
        {
            return getValue()[30];
        }

        public void setAccessDoor(bool accessDoor)
        {
            getValue()[30] = accessDoor;
        }
    }
}
