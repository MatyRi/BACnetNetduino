using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class Abort : AckAPDU
    {
        public static readonly byte TYPE_ID = 7;

        /**
         * This parameter shall be TRUE when the Abort PDU is sent by a server. This parameter shall be FALSE when the Abort
         * PDU is sent by a client.
         */
        private readonly bool server;

        /**
         * This parameter, of type BACnetAbortReason, contains the reason the transaction with the indicated invoke ID is
         * being aborted.
         */
        private readonly int abortReason;

        public Abort(bool server, byte originalInvokeId, int abortReason)
        {
            this.server = server;
            this.originalInvokeId = originalInvokeId;
            this.abortReason = abortReason;
        }

        
        public override byte getPduType()
        {
            return TYPE_ID;
        }

        
        public override bool isServer()
        {
            return server;
        }

        public int getAbortReason()
        {
            return abortReason;
        }

        
    /*public override void write(ByteStream queue)
        {
            int data = getShiftedTypeId(TYPE_ID) | (server ? 1 : 0);
            queue.push(data);
            queue.push(originalInvokeId);
            queue.push(abortReason);
        }*/

        Abort(ByteStream queue)
        {
            server = (queue.popU1B() & 1) == 1;
            originalInvokeId = queue.ReadByte();
            abortReason = queue.popU1B();
        }


        
    public override string ToString()
    {
        return "Abort(server=" + server + ", originalInvokeId=" + originalInvokeId + ", abortReason=;"; // TODO  + new AbortReason(abortReason) + ")";
        }

        
    public override bool expectsReply()
        {
            return false;
        }
    }
}
