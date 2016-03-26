namespace BACnetDataTypes.Enumerated
{
    public class BackupState : Primitive.Enumerated
    {
        public static readonly BackupState idle = new BackupState(0);
        public static readonly BackupState preparingForBackup = new BackupState(1);
        public static readonly BackupState preparingForRestore = new BackupState(2);
        public static readonly BackupState performingABackup = new BackupState(3);
        public static readonly BackupState performingARestore = new BackupState(4);
        public static readonly BackupState backupFailure = new BackupState(5);
        public static readonly BackupState restoreFailure = new BackupState(6);

        public static readonly BackupState[] ALL = { idle, preparingForBackup, preparingForRestore, performingABackup,
            performingARestore, backupFailure, restoreFailure, };

    public BackupState(uint value) : base(value) { }

    public BackupState(ByteStream queue) : base(queue) { }
}
}
