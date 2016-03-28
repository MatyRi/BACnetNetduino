namespace BACnetServices.APDU
{
    public abstract class AckAPDU : APDU
    {
        /**
 * This parameter shall be the 'invokeID' contained in the confirmed service request being acknowledged. The same
 * 'originalinvokeID' shall be used for all segments of a segmented acknowledgment.
 */

        public byte OriginalInvokeId { get; protected set; }

        public virtual bool IsServer { get; } = true;
    }
}
