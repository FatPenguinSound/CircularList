using System;
using System.Collections.Generic;
using System.Text;

namespace CircularEnumerable
{
    /// <summary>
    /// This class mirrors the <c></c>
    /// </summary>
    /// <typeparam name="T">The data type for the structure.</typeparam>
    class CircularList<T> : CircularEnumerable<T>
    {
        /// <summary>
        /// Constructor for the Circular List class.
        /// </summary>
        /// <param name="size">The size of the stack.</param>
        public CircularList(int size) : base(size)
        {
            if (size >= Int32.MaxValue - 1 || size < 0 || size.Equals(typeof(int))) { throw new ArgumentException("Stack size is not valid."); }
            DataList = new T[size + 1];
            Head = 0;
            Tail = 0;
        }

        public void Insert(int index, T data)
        {
            if (index > Length) { throw new IndexOutOfRangeException(); }
            if (Head > Tail)
            {
                int insertionPoint = Tail + index > DataList.Length ? Tail + index - DataList.Length : Tail + index;
                insertionPoint++;
                int numToMove = Length - index;

                for (var i = numToMove; i > -1; i--)
                {
                    int p = insertionPoint + i;
                    DataList[p + 1 > Capacity ? p + 1 - Capacity : p + 1] = DataList[p];
                }
            }
            else if (Tail < Head)
            {

            }
            else
            {
                
            }
        }
    }
}
