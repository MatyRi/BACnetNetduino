using System;
using System.Collections;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.Constructed
{
    class PropertyStates : BaseType
    {
        private static IList _classes;

        private void Init()
        {
            _classes = new ArrayList();

            _classes.Add(typeof (BBoolean)); // 0
            _classes.Add(typeof (BinaryPV)); // 1
            // TODO classes.Add(typeof (EventType)); // 2
            // TODO classes.Add(typeof (Polarity)); // 3
            // TODO classes.Add(typeof (ProgramRequest)); // 4;
            // TODO classes.Add(typeof (ProgramState)); // 5
            // TODO classes.Add(typeof (ProgramError)); // 6
            // TODO classes.Add(typeof (Reliability)); // 7
            // TODO classes.Add(typeof (EventState)); // 8
            _classes.Add(typeof (DeviceStatus)); // 9
            // TODO classes.Add(typeof (EngineeringUnits)); // 10
            _classes.Add(typeof (UnsignedInteger)); // 11
            _classes.Add(typeof (LifeSafetyMode)); // 12
            _classes.Add(typeof (LifeSafetyState)); // 13
            _classes.Add(typeof (RestartReason)); // 14
            // TODO classes.Add(typeof (DoorAlarmState)); // 15
            _classes.Add(typeof (Encodable)); // 16
            _classes.Add(typeof (Encodable)); // 17
            _classes.Add(typeof (Encodable)); // 18
            _classes.Add(typeof (Encodable)); // 19
            _classes.Add(typeof (Encodable)); // 20
            _classes.Add(typeof (Encodable)); // 21
            _classes.Add(typeof (Encodable)); // 22
            _classes.Add(typeof (Encodable)); // 23
            _classes.Add(typeof (Encodable)); // 24
            _classes.Add(typeof (Encodable)); // 25
            _classes.Add(typeof (Encodable)); // 26
            _classes.Add(typeof (Encodable)); // 27
            _classes.Add(typeof (Encodable)); // 28
            _classes.Add(typeof (Encodable)); // 29
            _classes.Add(typeof (Encodable)); // 30
            _classes.Add(typeof (Encodable)); // 31
            _classes.Add(typeof (Encodable)); // 32
            _classes.Add(typeof (Encodable)); // 33
            _classes.Add(typeof (Encodable)); // 34
            _classes.Add(typeof (Encodable)); // 35
            _classes.Add(typeof (BackupState)); // 36
        }

        public enum Types
        {
            Boolean = 0,
            BinaryPv = 1,
            EventType = 2,
            Polarity = 3,
            ProgramRequest = 4,
            ProgramState = 5,
            ProgramError = 6,
            Reliability = 7,
            EventState = 8,
            DeviceStatus = 9,
            EngineeringUnits = 10,
            Unsigned = 11,
            LifeSafetyMode = 12,
            LifeSafetyState = 13,
            RestartReason = 14,
            DoorAlarmState = 15,
            BackupState = 36,
        }

        private readonly Choice _state;

        public PropertyStates(int type, BaseType state)
        {
            _state = new Choice(type, state);
        }

        public int Type => _state.ContextId;

        public BaseType State => (BaseType)_state.Data;

        public override void write(ByteStream queue)
        {
            write(queue, _state);
        }

        public PropertyStates(ByteStream queue)
        {
            _state = new Choice(queue, _classes);
        }
    }
}
