namespace BACnetDataTypes.Enumerated
{
    class ProgramRequest : Primitive.Enumerated
    {
        public static readonly ProgramRequest Ready = new ProgramRequest(0);
        public static readonly ProgramRequest Load = new ProgramRequest(1);
        public static readonly ProgramRequest Run = new ProgramRequest(2);
        public static readonly ProgramRequest Halt = new ProgramRequest(3);
        public static readonly ProgramRequest Restart = new ProgramRequest(4);
        public static readonly ProgramRequest Unload = new ProgramRequest(5);

        public static readonly ProgramRequest[] All = {Ready, Load, Run, Halt, Restart, Unload};

        public ProgramRequest(uint value) : base(value)
        {
        }

        public ProgramRequest(ByteStream queue) : base(queue)
        {
        }
    }
}
