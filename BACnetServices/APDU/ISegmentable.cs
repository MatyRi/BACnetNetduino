using BACnetDataTypes;

namespace BACnetServices.APDU
{
    interface ISegmentable
    {
        byte getInvokeId();

        bool isSegmentedMessage();

        bool isMoreFollows();

        int getSequenceNumber();

        int getProposedWindowSize();

        void appendServiceData(ByteStream segmentable);

        void parseServiceData(); // throws BACnetException;

        ByteStream getServiceData();

        APDU clone(bool moreFollows, int sequenceNumber, int actualSegWindow, ByteStream data);

    }
}
