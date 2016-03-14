using System;
using BACnetNetduino.DataTypes;
using BACnetNetduino.DataTypes.Constructed;
using Microsoft.SPOT;

namespace BACnetNetduino.Service
{
    internal abstract class Service : BaseType
    {





        //protected static T Read<T>(ByteStream queue, T type) where T : Address
        //{
        /*if (type == Primitive.class)
            return (T) Primitive.createPrimitive(queue);

        try {
            var instance = System.Activator.CreateInstance(typeof(T), new object[] { null, null });
            return type.getConstructor(new Class[] { ByteStream.class }).newInstance(new Object[] { queue });
        }
        catch (NoSuchMethodException e) {
            // Check if this is an EventParameter
            if (type == EventParameter.class)
                return (T) EventParameter.createEventParameter(queue);
            throw new BACnetException(e);
        }
        catch (InvocationTargetException e) {
            // Check if there is a wrapped BACnet exception
            if (e.getCause() instanceof BACnetException)
                throw (BACnetException) e.getCause();
            throw new ReflectionException(e);
        }
        catch (Exception e) {
            throw new BACnetException(e);
        }*/

        //return null;
        //}

        public abstract byte getChoiceId();

    }
}
