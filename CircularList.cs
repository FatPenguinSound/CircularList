using System;
using System.Collections.Generic;
using System.Text;

namespace CircularList
{
    /// <summary>
    /// <para>Impliments a FIFO list using a circular data structure.</para>
    /// <para>The circular list avoids the performance issues with collection copying inherent in the standard data types. This inplimentation is of fixed size and strictly adheres to a FIFO paradigm. There is no support for mid-collection insertion.</para>
    /// <para>In the event that the list size is exceeded, the oldest entry in the list is overwritten with the newest.</para>
    /// </summary>
    /// <remarks>
    /// <para>Internally, the class uses a typed array to store the data. The data is written or read based on the incrementing of two "pointers" that mark the insertion point for new data and the read point for old data. The pointers can be accessed independently to allow for asynchonous read/write operations, or jointly in a single call.</para>
    /// <para>If the read pointer catches up to the write pointer, then the object will report no new entries. If the write pointer catches up to the read pointer, then the read pointer is incremented to stay one index ahead of the write pointer. See the <c>Read</c> and <c>Write</c> methods for more information.</para>
    /// </remarks>
    /// <typeparam name="T">Determines the type of data to be stored.</typeparam>
    class CircularList<T>
    {
        /// <summary>The next index for data entry.</summary>
        private int WritePoint { get; set; }
        /// <summary>The next index to be read.</summary>
        private int ReadPoint { get; set; }
        /// <summary>The data array of type T.</summary>
        private T[] DataList { get; set; }
        /// <summary>The length of <c>DataList</c></summary>
        public int Length
        {
            get { return DataList.Length; }
        }

        /// <summary>
        /// The constructor for the CircularList.
        /// </summary>
        /// <param name="size">The fixed size of the list.</param>
        public CircularList(int size)
        {
            DataList = new T[size];
            WritePoint = 0;
            ReadPoint = 0;
        }

        /// <summary>
        /// Writes the next entry in the list.
        /// </summary>
        /// <param name="data">The data of type T to write.</param>
        public void Write(T data)
        {
            WritePoint = ++WritePoint >= DataList.Length ? WritePoint - DataList.Length : WritePoint;
            if (WritePoint == ReadPoint) { ++ReadPoint; }
            DataList[WritePoint] = data;
        }

        /// <summary>
        /// Checks if there are new items in the list that have not been read out.
        /// </summary>
        /// <returns>Returns a boolean value. True for new items, false if there are no new items.</returns>
        public bool IsNewItems()
        {
            return ReadPoint != WritePoint;
        }

        /// <summary>
        /// Gets the next value from the list.
        /// </summary>
        /// <returns>Returns data of type T from the list.</returns>
        public T GetNext()
        {
            if (ReadPoint == WritePoint)
            {
                IndexOutOfRangeException e = new IndexOutOfRangeException("End of list reached!");
                throw e;
            }
            else {               
                ReadPoint = ++ReadPoint >= DataList.Length ? ReadPoint - DataList.Length : ReadPoint;
                return DataList[ReadPoint];
            }
        }

        /// <summary>
        /// Performs a read and write operation in the same call.
        /// </summary>
        /// <param name="data">Data of type T to write to the list.</param>
        /// <returns>Returns data of type T from the list.</returns>
        /// <remarks>Doubtful that this method is useful, but included for the sake of completion. I might extend this into a delayline-like function later.</remarks>
        public T Tick(T data)
        {
            Write(data);
            return GetNext();
        }

        /// <summary>
        /// Resets the list to its default state.
        /// </summary>
        public void Reset()
        {
            Array.Clear(DataList, 0, DataList.Length); // Probably unneccesary.
            ReadPoint = 0;
            WritePoint = 0;
        }
    }
}
