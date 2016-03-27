namespace BACnetDataTypes.Enumerated
{
    class ProgramError : Primitive.Enumerated
    {
        public static readonly ProgramError Normal = new ProgramError(0);
        public static readonly ProgramError LoadFailed = new ProgramError(1);
        public static readonly ProgramError Internal = new ProgramError(2);
        public static readonly ProgramError Program = new ProgramError(3);
        public static readonly ProgramError Other = new ProgramError(4);

        public static readonly ProgramError[] All = {Normal, LoadFailed, Internal, Program, Other};

        public ProgramError(uint value) : base(value)
        {
        }

        public ProgramError(ByteStream queue) : base(queue)
        {
        }
    }
}
