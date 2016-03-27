namespace BACnetDataTypes.Primitive
{
    public class BitString : Primitive
    {
        public bool[] Value { get; }

        public static readonly byte TYPE_ID = 8;

        public BitString(bool[] value)
        {
            this.Value = value;
        }

        public BitString(int size, bool defaultValue)
        {
            Value = new bool[size];
            if (defaultValue)
            {
                for (int i = 0; i < size; i++)
                    Value[i] = true;
            }
        }

        public void SetAll(bool value)
        {
            bool[] values = Value;
            for (int i = 0; i < values.Length; i++)
                values[i] = value;
        }

        //
        // Reading and writing
        //
        public BitString(ByteStream queue)
        {
            int Length = (int)readTag(queue) - 1;
            int remainder = queue.popU1B();

            if (Length == 0)
                Value = new bool[0];
            else {
                byte[] data = new byte[Length];
                queue.pop(data);
                Value = BACnetUtils.convertToBooleans(data, Length * 8 - remainder);
            }
        }

        protected override void WriteImpl(ByteStream queue)
        {
            if (Value.Length == 0)
                queue.WriteByte((byte)0);
            else {
                int remainder = Value.Length % 8;
                if (remainder > 0)
                    remainder = 8 - remainder;
                queue.WriteByte((byte)remainder);
                queue.Write(BACnetUtils.convertToBytes(Value));
            }
        }


        protected override long Length
        {
            get
            {
                if (Value.Length == 0)
                    return 1;
                return (Value.Length - 1) / 8 + 2;
            }
        }

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => Value.ToString();
    }
}
