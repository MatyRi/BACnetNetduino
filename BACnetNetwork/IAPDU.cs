using System;
using BACnetDataTypes;
using Microsoft.SPOT;

namespace BACnetNetwork
{
    public interface IAPDU
    {
        void write(ByteStream apduStream);
        bool expectsReply();
    }
}
