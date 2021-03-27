using System;
using System.Collections.Generic;
using System.Text;

namespace CircularEnumerable
{
    /// <summary>
    /// <para>Impliments a FIFO list using a circular data structure.</para>
    /// <para>The circular queue avoids the performance issues with collection copying inherent in the standard data types. This implimentation is of fixed size and strictly adheres to a FIFO paradigm. There is no support for mid-collection insertion.</para>
    /// <para>In the event that the list size is exceeded, the oldest entry in the list is overwritten with the newest.</para>
    /// </summary>
    /// <remarks>
    /// <para>Internally, the class uses a typed array to store the data. The data is written or read based on the incrementing of two "pointers" that mark the insertion point for new data and the read point for old data. The pointers can be accessed independently to allow for asynchonous read/write operations, or jointly in a single call.</para>
    /// <para>If the read pointer catches up to the write pointer, then the object will report no new entries. If the write pointer catches up to the read pointer, then the read pointer is incremented to stay one index ahead of the write pointer. See the <c>Read</c> and <c>Write</c> methods for more information.</para>
    /// </remarks>
    /// <typeparam name="T">Determines the type of data to be stored.</typeparam>
    public class CircularQueue<T> : CircularEnumerable<T>
    {
        /// <summary>
        /// The constructor for the CircularList.
        /// </summary>
        /// <param name="size">The fixed size of the list.</param>
        public CircularQueue(int size) : base(size)
        {
            if (size >= Int32.MaxValue - 1 || size < 0 || size.Equals(typeof(int))) { throw new ArgumentException("Stack size is not valid."); }
            DataList = new T[size + 1];
            Head = 0;
            Tail = 0;
        }

        /// <summary>
        /// Performs a read and write operation in the same call.
        /// </summary>
        /// <param name="data">Data of type T to write to the list.</param>
        /// <returns>Returns data of type T from the list.</returns>
        /// <remarks>Doubtful that this method is useful, but included for the sake of completion. I might extend this into a delayline-like function later.</remarks>
        public T Tick(T data)
        {
            Add(data);
            return Next();
        }
    }
}
