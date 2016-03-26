using System;
using System.Reflection;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes
{
    class AmbiguousValue : Encodable
    {
        private byte[] data;

        public AmbiguousValue(ByteStream queue)
        {
            TagData tagData = new TagData();
            peekTagData(queue, tagData);
            readAmbiguousData(queue, tagData);
        }

        public AmbiguousValue(ByteStream queue, int contextId)
        {
            popStart(queue, contextId);

            TagData tagData = new TagData();
            while (true)
            {
                peekTagData(queue, tagData);
                if (tagData.isEndTag(contextId))
                    break;
                readAmbiguousData(queue, tagData);
            }

            popEnd(queue, contextId);
        }


        /*public override void write(ByteStream queue, int contextId)
        {
            throw new NotImplementedException("Don't write ambigous values, convert to actual types first");
        }


        public override void write(ByteStream queue)
        {
            throw new NotImplementedException("Don't write ambigous values, convert to actual types first");
        }*/

        private void readAmbiguousData(ByteStream queue, TagData tagData)
        {
            ByteStream data = new ByteStream();
            readAmbiguousData(queue, tagData, data);
            this.data = data.ReadToEnd();
        }

        private void readAmbiguousData(ByteStream queue, TagData tagData, ByteStream data)
        {
            if (!tagData.contextSpecific)
            {
                // Application class.
                if (tagData.tagNumber == BBoolean.TYPE_ID)
                    copyData(queue, 1, data);
                else
                    copyData(queue, tagData.getTotalLength(), data);
            }
            else
            {
                // Context specific class.
                if (tagData.isStartTag())
                {
                    // Copy the start tag
                    copyData(queue, 1, data);

                    // Remember the context id
                    int contextId = tagData.tagNumber;

                    // Read ambiguous data until we find the end tag.
                    while (true)
                    {
                        peekTagData(queue, tagData);
                        if (tagData.isEndTag(contextId))
                            break;
                        readAmbiguousData(queue, tagData);
                    }

                    // Copy the end tag
                    copyData(queue, 1, data);
                }
                else
                    copyData(queue, tagData.getTotalLength(), data);
            }
        }


        public override string ToString()
        {
            return "Ambiguous(" + data + ")";
        }

        private void copyData(ByteStream queue, int length, ByteStream data)
        {
            while (length-- > 0)
                data.WriteByte(queue.ReadByte());
        }

        public bool isNull()
        {
            return data.Length == 1 && data[0] == 0;
        }

        public object ConvertTo(Type type)
        {
            if (type.IsSubclassOf(typeof (Encodable)))
            {
                ConstructorInfo constructor = type.GetConstructor(new[] {typeof (ByteStream)});
                object result = constructor.Invoke(new object[] {new ByteStream(data)});
                return result;
            }
            return null;
        }
    }
}
