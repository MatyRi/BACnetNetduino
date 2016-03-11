using System;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Error
{
    class VTCloseError : BaseError
    {
        private readonly SequenceOf<UnsignedInteger> listOfVTSessionIdentifiers;

        public VTCloseError(byte choice, BACnetError error, SequenceOf<UnsignedInteger> listOfVTSessionIdentifiers) : base(choice, error)
        {
            this.listOfVTSessionIdentifiers = listOfVTSessionIdentifiers;
        }

        public override void write(ByteStream queue)
        {
            queue.push(choice);
            write(queue, error, 0);
            writeOptional(queue, listOfVTSessionIdentifiers, 1);
        }

        VTCloseError(byte choice, ByteStream queue) : base(choice, queue, 0) // throws BACnetException
        {
            listOfVTSessionIdentifiers = readOptionalSequenceOf(queue, typeof(UnsignedInteger), 1);
        }
    }
}
