namespace BACnetDataTypes.Error
{
    class VTCloseError : BaseError
    {
        //private readonly SequenceOf<UnsignedInteger> listOfVTSessionIdentifiers;

        /*public VTCloseError(byte choice, BACnetError error, SequenceOf<UnsignedInteger> listOfVTSessionIdentifiers) : base(choice, error)
        {
            this.listOfVTSessionIdentifiers = listOfVTSessionIdentifiers;
        }*/

        /*public override void write(ByteStream queue)
        {
            queue.push(choice);
            write(queue, error, 0);
            writeOptional(queue, listOfVTSessionIdentifiers, 1);
        }*/

        internal VTCloseError(byte choice, ByteStream queue) : base(choice, queue, 0) // throws BACnetException
        {
            // TODO listOfVTSessionIdentifiers = readOptionalSequenceOf(queue, typeof(UnsignedInteger), 1);
        }
    }
}
