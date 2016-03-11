using System;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Primitive;
using BACnetNetduino.Exception;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Error
{

    internal class CreateObjectError : BaseError
    {
        private readonly UnsignedInteger firstFailedElementNumber;

        public CreateObjectError(byte choice, BACnetError error, UnsignedInteger firstFailedElementNumber) : base(choice, error)
        {
            this.firstFailedElementNumber = firstFailedElementNumber;
        }

        public CreateObjectError(byte choice, BACnetServiceException e, UnsignedInteger firstFailedElementNumber) : base(choice, new BACnetError(e))
        { 
            this.firstFailedElementNumber = firstFailedElementNumber;
        }

        public override void write(ByteStream queue)
        {
            queue.push(choice);
            write(queue, error, 0);
            firstFailedElementNumber.write(queue, 1);
        }

        CreateObjectError(byte choice, ByteStream queue) : base(choice, queue, 0) // throws BACnetException
        {
            firstFailedElementNumber = read(queue, typeof(UnsignedInteger), 1);
        }
    }
}
