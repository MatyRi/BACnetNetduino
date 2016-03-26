using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class ObjectTypesSupported : BitString
    {
        public ObjectTypesSupported() : base(new bool[31]) { }

        public ObjectTypesSupported(ByteStream queue) : base(queue) { }

        public bool AnalogInput
        {
            get { return Value[0]; }
            set { Value[0] = value; }
        }

        public bool isAnalogOutput()
        {
            return Value[1];
        }

        public void setAnalogOutput(bool analogOutput)
        {
            Value[1] = analogOutput;
        }

        public bool isAnalogValue()
        {
            return Value[2];
        }

        public void setAnalogValue(bool analogValue)
        {
            Value[2] = analogValue;
        }

        public bool isBinaryInput()
        {
            return Value[3];
        }

        public void setBinaryInput(bool binaryInput)
        {
            Value[3] = binaryInput;
        }

        public bool isBinaryOutput()
        {
            return Value[4];
        }

        public void setBinaryOutput(bool binaryOutput)
        {
            Value[4] = binaryOutput;
        }

        public bool isBinaryValue()
        {
            return Value[5];
        }

        public void setBinaryValue(bool binaryValue)
        {
            Value[5] = binaryValue;
        }

        public bool isCalendar()
        {
            return Value[6];
        }

        public void setCalendar(bool calendar)
        {
            Value[6] = calendar;
        }

        public bool isCommand()
        {
            return Value[7];
        }

        public void setCommand(bool command)
        {
            Value[7] = command;
        }

        public bool isDevice()
        {
            return Value[8];
        }

        public void setDevice(bool device)
        {
            Value[8] = device;
        }

        public bool isEventEnrollment()
        {
            return Value[9];
        }

        public void setEventEnrollment(bool eventEnrollment)
        {
            Value[9] = eventEnrollment;
        }

        public bool isFile()
        {
            return Value[10];
        }

        public void setFile(bool file)
        {
            Value[10] = file;
        }

        public bool isGroup()
        {
            return Value[11];
        }

        public void setGroup(bool group)
        {
            Value[11] = group;
        }

        public bool isLoop()
        {
            return Value[12];
        }

        public void setLoop(bool loop)
        {
            Value[12] = loop;
        }

        public bool isMultiStateInput()
        {
            return Value[13];
        }

        public void setMultiStateInput(bool multiStateInput)
        {
            Value[13] = multiStateInput;
        }

        public bool isMultiStateOutput()
        {
            return Value[14];
        }

        public void setMultiStateOutput(bool multiStateOutput)
        {
            Value[14] = multiStateOutput;
        }

        public bool isNotificationClass()
        {
            return Value[15];
        }

        public void setNotificationClass(bool notificationClass)
        {
            Value[15] = notificationClass;
        }

        public bool isProgram()
        {
            return Value[16];
        }

        public void setProgram(bool program)
        {
            Value[16] = program;
        }

        public bool isSchedule()
        {
            return Value[17];
        }

        public void setSchedule(bool schedule)
        {
            Value[17] = schedule;
        }

        public bool isAveraging()
        {
            return Value[18];
        }

        public void setAveraging(bool averaging)
        {
            Value[18] = averaging;
        }

        public bool isMultiStateValue()
        {
            return Value[19];
        }

        public void setMultiStateValue(bool multiStateValue)
        {
            Value[19] = multiStateValue;
        }

        public bool isTrendLog()
        {
            return Value[20];
        }

        public void setTrendLog(bool trendLog)
        {
            Value[20] = trendLog;
        }

        public bool isLifeSafetyPoint()
        {
            return Value[21];
        }

        public void setLifeSafetyPoint(bool lifeSafetyPoint)
        {
            Value[21] = lifeSafetyPoint;
        }

        public bool isLifeSafetyZone()
        {
            return Value[22];
        }

        public void setLifeSafetyZone(bool lifeSafetyZone)
        {
            Value[22] = lifeSafetyZone;
        }

        public bool isAccumulator()
        {
            return Value[23];
        }

        public void setAccumulator(bool accumulator)
        {
            Value[23] = accumulator;
        }

        public bool isPulseConverter()
        {
            return Value[24];
        }

        public void setPulseConverter(bool pulseConverter)
        {
            Value[24] = pulseConverter;
        }

        public bool isEventLog()
        {
            return Value[25];
        }

        public void setEventLog(bool eventLog)
        {
            Value[25] = eventLog;
        }

        public bool isTrendLogMultiple()
        {
            return Value[27];
        }

        public void setTrendLogMultiple(bool trendLogMultiple)
        {
            Value[27] = trendLogMultiple;
        }

        public bool isLoadControl()
        {
            return Value[28];
        }

        public void setLoadControl(bool loadControl)
        {
            Value[28] = loadControl;
        }

        public bool isStructuredView()
        {
            return Value[29];
        }

        public void setStructuredView(bool structuredView)
        {
            Value[29] = structuredView;
        }

        public bool isAccessDoor()
        {
            return Value[30];
        }

        public void setAccessDoor(bool accessDoor)
        {
            Value[30] = accessDoor;
        }
    }
}
