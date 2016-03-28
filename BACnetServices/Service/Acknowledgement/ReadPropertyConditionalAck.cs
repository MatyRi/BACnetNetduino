using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class ReadPropertyConditionalAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 13;

        public ReadPropertyConditionalAck(SequenceOf listOfReadAccessResults)
        {
            ListOfReadAccessResults = listOfReadAccessResults;
        }

        public override byte ChoiceId => TYPE_ID;


        public void write(ByteStream queue)
        {
            write(queue, ListOfReadAccessResults);
        }

        internal ReadPropertyConditionalAck(ByteStream queue)
        {
            ListOfReadAccessResults = readSequenceOf(queue, typeof(ReadAccessResult));
        }

        public SequenceOf ListOfReadAccessResults { get; } //// <ReadAccessResult>
    }
}
