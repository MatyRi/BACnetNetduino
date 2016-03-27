namespace BACnetDataTypes.Enumerated
{
    class ProgramState : Primitive.Enumerated
    {
        public static readonly ProgramState Idle = new ProgramState(0);
        public static readonly ProgramState Loading = new ProgramState(1);
        public static readonly ProgramState Running = new ProgramState(2);
        public static readonly ProgramState Waiting = new ProgramState(3);
        public static readonly ProgramState Halted = new ProgramState(4);
        public static readonly ProgramState Unloading = new ProgramState(5);

        public static readonly ProgramState[] All = {Idle, Loading, Running, Waiting, Halted, Unloading};

        public ProgramState(uint value) : base(value)
        {
        }

        public ProgramState(ByteStream queue) : base(queue)
        {
        }
    }
}
