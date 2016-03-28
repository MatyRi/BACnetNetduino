using BACnetDataTypes;

namespace BACnetServices.APDU
{
    interface ISegmentable
    {
        byte InvokeId { get; }

        bool IsSegmentedMessage { get; }

        bool IsMoreFollows { get; }

        int SequenceNumber { get; }

        int ProposedWindowSize { get; }

        void AppendServiceData(ByteStream segmentable);

        void ParseServiceData();

        ByteStream ServiceData { get; }

        APDU clone(bool moreFollows, int sequenceNumber, int actualSegWindow, ByteStream data);

    }
}
