using BACnetDataTypes.Constructed;

namespace BACnetServices.Service
{
    public abstract class Service : BaseType
    {
        public abstract byte ChoiceId { get; }
    }
}