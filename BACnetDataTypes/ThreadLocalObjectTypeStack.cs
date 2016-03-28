using System.Collections;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Error;

namespace BACnetDataTypes
{
    public class ThreadLocalObjectTypeStack
    {
        // TODO Not sure this will work
        private static ObjectType objType = null; //

        public static void set(ObjectType objectType)
        {
            objType = objectType;
        }

        public static ObjectType get()
        {
            return objType;
        }

        public static void remove()
        {
            objType = null;
        }
    }
}
