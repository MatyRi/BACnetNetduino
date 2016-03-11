using System;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Error
{
    public class ChangeListError : BaseError
    {
        private readonly UnsignedInteger firstFailedElementNumber;

        public ChangeListError(byte choice, BACnetError error, UnsignedInteger firstFailedElementNumber) : base(choice, error)
        {
            this.firstFailedElementNumber = firstFailedElementNumber;
        }

        public override void write(ByteStream queue)
        {
            queue.push(choice);
            write(queue, error, 0);
            write(queue, firstFailedElementNumber, 1);
        }

        ChangeListError(byte choice, ByteStream queue) : base(choice, queue, 0) // throws BACnetException
        {
            firstFailedElementNumber = read(queue, typeof(UnsignedInteger), 1);
        }
    }
}
