using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class ReadPropertyMultipleAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 14;

        public ReadPropertyMultipleAck(SequenceOf listOfReadAccessResults)
        {
            ListOfReadAccessResults = listOfReadAccessResults;
        }

        public override byte ChoiceId => TYPE_ID;

        public override void write(ByteStream queue)
        {
            write(queue, ListOfReadAccessResults);
        }

        internal ReadPropertyMultipleAck(ByteStream queue)
        {
            ListOfReadAccessResults = readSequenceOf(queue, typeof (ReadAccessResult));
        }


        public override string ToString() => "ReadPropertyMultipleAck(" + ListOfReadAccessResults + ")";

        public SequenceOf ListOfReadAccessResults { get; }
        //<ReadAccessResult>
    }
}
