namespace BACnetDataTypes.Enumerated
{
    public class BackupState : Primitive.Enumerated
    {
        public static readonly BackupState Idle = new BackupState(0);
        public static readonly BackupState PreparingForBackup = new BackupState(1);
        public static readonly BackupState PreparingForRestore = new BackupState(2);
        public static readonly BackupState PerformingABackup = new BackupState(3);
        public static readonly BackupState PerformingARestore = new BackupState(4);
        public static readonly BackupState BackupFailure = new BackupState(5);
        public static readonly BackupState RestoreFailure = new BackupState(6);

        public static readonly BackupState[] All = { Idle, PreparingForBackup, PreparingForRestore, PerformingABackup,
            PerformingARestore, BackupFailure, RestoreFailure, };

    public BackupState(uint value) : base(value) { }

    public BackupState(ByteStream queue) : base(queue) { }
}
}
