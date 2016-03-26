namespace BACnetNetwork.BVLC
{
    enum BVLCType
    {
        BACnetIP_AnnexJ = (byte)0x81
    }

    enum BVLCFunction
    {
        DistributeBroadcastToNetwork = (byte)0x09,
        OriginalUnicastNPDU = (byte)0x0a,
        OriginalBroadcastNPDU = (byte)0x0b,
        ForwardedNPDU = (byte)0x04
    }
}
