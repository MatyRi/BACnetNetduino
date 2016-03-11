using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    internal abstract class AckAPDU : APDU
    {
        /**
 * This parameter shall be the 'invokeID' contained in the confirmed service request being acknowledged. The same
 * 'originalinvokeID' shall be used for all segments of a segmented acknowledgment.
 */
        protected byte originalInvokeId;

        public byte getOriginalInvokeId()
        {
            return originalInvokeId;
        }

        public virtual bool isServer()
        {
            return true;
        }
    }
}
