using System;
using System.Collections;

namespace BACnetDataTypes.Constructed
{
    public class SequenceOf : BaseType, IList
    {
        public IList Values { get; }

        public SequenceOf()
        {
            Values = new ArrayList();
        }

        public SequenceOf(IList values)
        {
            this.Values = values;
        }


        /*public override void write(ByteStream queue)
        {
            foreach (Encodable value in values)
                value.write(queue);
        }*/

        public SequenceOf(ByteStream queue, Type type)
        {
            Values = new ArrayList();
            while (peekTagNumber(queue) != -1)
                Values.Add(read(queue, type));
        }

        public SequenceOf(ByteStream queue, int count, Type type)
        {
            Values = new ArrayList();
            while (count-- > 0)
                Values.Add(read(queue, type));
        }

        public SequenceOf(ByteStream queue, Type type, int contextId)
        {
            Values = new ArrayList();
            while (readEnd(queue) != contextId)
            {
                Encodable obj = read(queue, type);
                Values.Add(obj);
            }
                
        }

        public Encodable Get(int indexBase1)
        {
            return (Encodable) Values[indexBase1 - 1];
        }

        public int getCount()
        {
            return Values.Count;
        }

        public void set(int indexBase1, Encodable value)
        {
            int index = indexBase1 - 1;
            while (Values.Count <= index)
                Values.Add(null);
            Values[index] = value;
        }

        public void add(Encodable value)
        {
            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i] == null)
                {
                    Values[i] = value;
                    return;
                }
            }
            Values.Add(value);
        }

        public void remove(int indexBase1)
        {
            int index = indexBase1 - 1;
            if (index < Values.Count)
                Values.RemoveAt(index);
            // values.set(index, null);
            // Trim null values at the end.
            // while (!values.isEmpty() && values.get(values.size() - 1) == null)
            // values.remove(values.size() - 1);
        }

        public void remove(Encodable value)
        {
            if (value == null)
                return;

            for (int i = 0; i < Values.Count; i++)
            {
                if (value.Equals(Values[i]))
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
            foreach (Encodable e in Values)
            {
                if (value.Equals(e))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Values.ToString();
        }

        #region IList implementation

        public IEnumerator GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            Values.CopyTo(array, index);
        }

        public int Count => Values.Count;

        public object SyncRoot => Values.SyncRoot;

        public bool IsSynchronized => Values.IsSynchronized;

        public int Add(object value)
        {
            return Values.Add(value);
        }

        public bool Contains(object value)
        {
            return Values.Contains(value);
        }

        public void Clear()
        {
            Values.Clear();
        }

        public int IndexOf(object value)
        {
            return Values.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            Values.Insert(index, value);
        }

        public void Remove(object value)
        {
            Values.Remove(value);
        }

        public void RemoveAt(int index)
        {
            Values.RemoveAt(index);
        }

        public object this[int index]
        {
            get { return Values[index]; }
            set { Values[index] = value; }
        }

        public bool IsReadOnly => Values.IsReadOnly;

        public bool IsFixedSize => Values.IsFixedSize;

        #endregion
    }
}
