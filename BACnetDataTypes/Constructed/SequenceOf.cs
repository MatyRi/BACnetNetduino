using System;
using System.Collections;

namespace BACnetDataTypes.Constructed
{
    public class SequenceOf : BaseType, IList
    {
        private readonly IList values;

        public SequenceOf()
        {
            values = new ArrayList();
        }

        public SequenceOf(IList values)
        {
            this.values = values;
        }


        /*public override void write(ByteStream queue)
        {
            foreach (Encodable value in values)
                value.write(queue);
        }*/

        public SequenceOf(ByteStream queue, Type type)
        {
            values = new ArrayList();
            while (peekTagNumber(queue) != -1)
                values.Add(read(queue, type));
        }

        public SequenceOf(ByteStream queue, int count, Type type)
        {
            values = new ArrayList();
            while (count-- > 0)
                values.Add(read(queue, type));
        }

        public SequenceOf(ByteStream queue, Type type, int contextId)
        {
            values = new ArrayList();
            while (readEnd(queue) != contextId)
            {
                Encodable obj = read(queue, type);
                values.Add(obj);
            }
                
        }

        public Encodable get(int indexBase1)
        {
            return (Encodable) values[indexBase1 - 1];
        }

        public int getCount()
        {
            return values.Count;
        }

        public void set(int indexBase1, Encodable value)
        {
            int index = indexBase1 - 1;
            while (values.Count <= index)
                values.Add(null);
            values[index] = value;
        }

        public void add(Encodable value)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == null)
                {
                    values[i] = value;
                    return;
                }
            }
            values.Add(value);
        }

        public void remove(int indexBase1)
        {
            int index = indexBase1 - 1;
            if (index < values.Count)
                values.RemoveAt(index);
            // values.set(index, null);
            // Trim null values at the end.
            // while (!values.isEmpty() && values.get(values.size() - 1) == null)
            // values.remove(values.size() - 1);
        }

        public void remove(Encodable value)
        {
            if (value == null)
                return;

            for (int i = 0; i < values.Count; i++)
            {
                if (value.Equals(values[i]))
                {
                    remove(i + 1);
                    break;
                }
            }
        }

        public void removeAll(Encodable value)
        {
            /*for (IEnumerator it = values.GetEnumerator(); it.MoveNext();)
            {
            // TODO
                Encodable e = (Encodable) it.Current;
                if (ObjectUtils.equals(e, value))
                    it.remove();
            }*/
        }

        public bool contains(Encodable value)
        {
            foreach (Encodable e in values)
            {
                if (value.Equals(e))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return values.ToString();
        }

        #region IList implementation

        public IEnumerator GetEnumerator()
        {
            return values.GetEnumerator();
        }

        public IList getValues()
        {
            return values;
        }

        public void CopyTo(Array array, int index)
        {
            values.CopyTo(array, index);
        }

        public int Count => values.Count;

        public object SyncRoot => values.SyncRoot;

        public bool IsSynchronized => values.IsSynchronized;

        public int Add(object value)
        {
            return values.Add(value);
        }

        public bool Contains(object value)
        {
            return values.Contains(value);
        }

        public void Clear()
        {
            values.Clear();
        }

        public int IndexOf(object value)
        {
            return values.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            values.Insert(index, value);
        }

        public void Remove(object value)
        {
            values.Remove(value);
        }

        public void RemoveAt(int index)
        {
            values.RemoveAt(index);
        }

        public object this[int index]
        {
            get { return values[index]; }
            set { values[index] = value; }
        }

        public bool IsReadOnly => values.IsReadOnly;

        public bool IsFixedSize => values.IsFixedSize;

        #endregion
    }
}
