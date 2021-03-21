using System;
using System.Collections.Generic;
using System.Text;

namespace CircularEnumerable
{
    /// <summary>
    /// The reverse queue is a strict FILO stack. It is very similar to to the <c>CircularQueue</c> in implimentation, except for the the FILO structure. 
    /// </summary>
    /// <typeparam name="T">The data type for the structure.</typeparam>
    class CircularReverseQueue<T> : CircularEnumerable<T>
    {
        /// <summary>
        /// The constructor for the FILO queue.
        /// </summary>
        /// <param name="size">The size of the data stack.</param>
        public CircularReverseQueue(int size) : base(size)
        {
            if (size >= Int32.MaxValue - 1 || size < 0 || size.Equals(typeof(int))) { throw new ArgumentException("Stack size is not valid."); }
            DataList = new T[size + 1];
            Head = 0;
            Tail = 0;
        }

        /// <summary>
        /// Returns the most recent data point and removes it from the stack.
        /// </summary>
        /// <returns>Returns the most recent data point of type T.</returns>
        /// <exception cref="IndexOutOfRangeException">If there are no items in the stack, it throws an exception.</exception>
        public override T Next()
        {
            if (Head == Tail) { throw new IndexOutOfRangeException("There are no new items in the list."); }
            return DataList[Tail--];
        }
    }
}
