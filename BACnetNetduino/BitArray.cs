using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace BACnetNetduino
{
    [Serializable]
    [ComVisible(true)]
    public sealed class BitArray : ICollection, IEnumerable, ICloneable
    {
        // Fields
        private const int _ShrinkThreshold = 0x100;

        [NonSerialized]
        private object _syncRoot;

        private int _version;
        private int[] m_array;
        private int m_length;

        // Methods
        private BitArray() { }

        public BitArray(int length)
            : this(length, false)
        { }

        public BitArray(bool[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            m_array = new int[(values.Length + 0x1f) / 0x20];
            m_length = values.Length;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i])
                {
                    m_array[i / 0x20] |= (1) << (i % 0x20);
                }
            }
            _version = 0;
        }

        public BitArray(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            m_array = new int[(bytes.Length + 3) / 4];
            m_length = bytes.Length * 8;
            int index = 0;
            int num2 = 0;
            while ((bytes.Length - num2) >= 4)
            {
                m_array[index++] = (((bytes[num2] & 0xff) | ((bytes[num2 + 1] & 0xff) << 8)) |
                                    ((bytes[num2 + 2] & 0xff) << 0x10)) | ((bytes[num2 + 3] & 0xff) << 0x18);
                num2 += 4;
            }
            switch ((bytes.Length - num2))
            {
                case 1:
                    goto Label_00DB;

                case 2:
                    break;

                case 3:
                    m_array[index] = (bytes[num2 + 2] & 0xff) << 0x10;
                    break;

                default:
                    goto Label_00FC;
            }
            m_array[index] |= (bytes[num2 + 1] & 0xff) << 8;
            Label_00DB:
            m_array[index] |= bytes[num2] & 0xff;
            Label_00FC:
            _version = 0;
        }

        public BitArray(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            m_array = new int[values.Length];
            m_length = values.Length * 0x20;
            Array.Copy(values, m_array, values.Length);
            _version = 0;
        }

        public BitArray(BitArray bits)
        {
            if (bits == null)
            {
                throw new ArgumentNullException("bits");
            }
            m_array = new int[(bits.m_length + 0x1f) / 0x20];
            m_length = bits.m_length;
            Array.Copy(bits.m_array, m_array, ((bits.m_length + 0x1f) / 0x20));
            _version = bits._version;
        }

        public BitArray(int length,
            bool defaultValue)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(@"length ArgumentOutOfRange_NeedNonNegNum");
            }
            m_array = new int[(length + 0x1f) / 0x20];
            m_length = length;
            int num = defaultValue ? -1 : 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                m_array[i] = num;
            }
            _version = 0;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool this[int index]
        {
            get { return Get(index); }
            set { Set(index, value); }
        }

        public int Length
        {
            get { return m_length; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(@"value ArgumentOutOfRange_NeedNonNegNum");
                }
                int num = (value + 0x1f) / 0x20;
                if ((num > m_array.Length) ||
                    ((num + 0x100) < m_array.Length))
                {
                    var destinationArray = new int[num];
                    Array.Copy(m_array, destinationArray, (num > m_array.Length) ? m_array.Length : num);
                    m_array = destinationArray;
                }
                if (value > m_length)
                {
                    int index = ((m_length + 0x1f) / 0x20) - 1;
                    int num3 = m_length % 0x20;
                    if (num3 > 0)
                    {
                        m_array[index] &= ((1) << num3) - 1;
                    }
                    Array.Clear(m_array, index + 1, (num - index) - 1);
                }
                m_length = value;
                _version++;
            }
        }

        #region ICloneable Members
        public object Clone()
        {
            return new BitArray(m_array)
            {
                _version = _version,
                m_length = m_length
            };
        }
        #endregion

        #region ICollection Members
        public void CopyTo(Array array,
            int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(@"index ArgumentOutOfRange_NeedNonNegNum");
            }

            if (array is int[])
            {
                Array.Copy(m_array, 0, array, index, (m_length + 0x1f) / 0x20);
            }
            else if (array is byte[])
            {
                if ((array.Length - index) <
                    ((m_length + 7) / 8))
                {
                    throw new ArgumentException(@"Argument_InvalidOffLen");
                }
                var buffer = (byte[])array;
                for (int i = 0; i < ((m_length + 7) / 8); i++)
                {
                    buffer[index + i] = (byte)((m_array[i / 4] >> ((i % 4) * 8)) & 0xff);
                }
            }
            else
            {
                if (!(array is bool[]))
                {
                    throw new ArgumentException(@"Arg_BitArrayTypeUnsupported");
                }
                if ((array.Length - index) < m_length)
                {
                    throw new ArgumentException(@"Argument_InvalidOffLen");
                }
                var flagArray = (bool[])array;
                for (int j = 0; j < m_length; j++)
                {
                    flagArray[index + j] = ((m_array[j / 0x20] >> (j % 0x20)) & 1) != 0;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new BitArrayEnumeratorSimple(this);
        }

        public int Count
        {
            get { return m_length; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    _syncRoot = new Object();
                }
                return _syncRoot;
            }
        }
        #endregion

        public BitArray And(BitArray value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (m_length != value.m_length)
            {
                throw new ArgumentException(@"Arg_ArrayLengthsDiffer");
            }
            int num = (m_length + 0x1f) / 0x20;
            for (int i = 0; i < num; i++)
            {
                m_array[i] &= value.m_array[i];
            }
            _version++;
            return this;
        }

        public bool Get(int index)
        {
            if ((index < 0) ||
                (index >= m_length))
            {
                throw new ArgumentOutOfRangeException(@"index ArgumentOutOfRange_Index");
            }
            return ((m_array[index / 0x20] & ((1) << (index % 0x20))) != 0);
        }

        public BitArray Not()
        {
            int num = (m_length + 0x1f) / 0x20;
            for (int i = 0; i < num; i++)
            {
                m_array[i] = ~m_array[i];
            }
            _version++;
            return this;
        }

        public BitArray Or(BitArray value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (m_length != value.m_length)
            {
                throw new ArgumentException(@"Arg_ArrayLengthsDiffer");
            }
            int num = (m_length + 0x1f) / 0x20;
            for (int i = 0; i < num; i++)
            {
                m_array[i] |= value.m_array[i];
            }
            _version++;
            return this;
        }

        public void Set(int index,
            bool value)
        {
            if ((index < 0) ||
                (index >= m_length))
            {
                throw new ArgumentOutOfRangeException(@"ArgumentOutOfRange_Index");
            }
            if (value)
            {
                m_array[index / 0x20] |= (1) << (index % 0x20);
            }
            else
            {
                m_array[index / 0x20] &= ~((1) << (index % 0x20));
            }
            _version++;
        }

        public void SetAll(bool value)
        {
            int num = value ? -1 : 0;
            int num2 = (m_length + 0x1f) / 0x20;
            for (int i = 0; i < num2; i++)
            {
                m_array[i] = num;
            }
            _version++;
        }

        public BitArray Xor(BitArray value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (m_length != value.m_length)
            {
                throw new ArgumentException(@"Arg_ArrayLengthsDiffer");
            }
            int num = (m_length + 0x1f) / 0x20;
            for (int i = 0; i < num; i++)
            {
                m_array[i] ^= value.m_array[i];
            }
            _version++;
            return this;
        }

        #region Nested type: BitArrayEnumeratorSimple
        [Serializable]
        private class BitArrayEnumeratorSimple : IEnumerator, ICloneable
        {
            // Fields
            private readonly BitArray bitarray;
            private readonly int version;
            private bool currentElement;
            private int index;

            // Methods
            internal BitArrayEnumeratorSimple(BitArray bitarray)
            {
                this.bitarray = bitarray;
                index = -1;
                version = bitarray._version;
            }

            #region ICloneable Members
            public object Clone()
            {
                return MemberwiseClone();
            }
            #endregion

            #region IEnumerator Members
            public virtual bool MoveNext()
            {
                if (version != bitarray._version)
                {
                    throw new InvalidOperationException(@"InvalidOperation_EnumFailedVersion");
                }
                if (index < (bitarray.Count - 1))
                {
                    index++;
                    currentElement = bitarray.Get(index);
                    return true;
                }
                index = bitarray.Count;
                return false;
            }

            public void Reset()
            {
                if (version != bitarray._version)
                {
                    throw new InvalidOperationException(@"InvalidOperation_EnumFailedVersion");
                }
                index = -1;
            }

            // Properties
            public virtual object Current
            {
                get
                {
                    if (index == -1)
                    {
                        throw new InvalidOperationException(@"InvalidOperation_EnumNotStarted");
                    }
                    if (index >= bitarray.Count)
                    {
                        throw new InvalidOperationException(@"InvalidOperation_EnumEnded");
                    }
                    return currentElement;
                }
            }
            #endregion
        }
        #endregion
    }
}

