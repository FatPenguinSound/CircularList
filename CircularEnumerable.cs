using System;
using System.Collections.Generic;
using System.Text;

namespace CircularEnumerable
{
    /// <summary>
    /// <para>This abstract class defines the base functionallity for the circular enumerable classes.</para>
    /// <para>The circular structures avoid the constant copy-write cycles needed for lists in some type of FIFO/FILO stack structure. Interally, the structure uses a fixed-sized array with two moving "pointers" to keep track of the head and tail positions within the list. Further details are discusses in specific inhereted classes.</para>
    /// <para>Since the stack is fixed size and circular, if an item is added to the stack that exceeds the capacity of the stack, the oldest item will be dropped.</para>
    /// </summary>
    /// <typeparam name="T">The data type for the enumerable list.</typeparam>
    /// <remarks>The optimizations represented by this data structure are likely unneccesary in most use-cases. This library was origianlly developed to handle passing UDP data between a listening thread and a processing thread in a realtime application.</remarks>
    abstract public class CircularEnumerable<T>
    {
        /// <summary>The front of the list--marks the most recent item added in the stack.</summary>
        protected int Head { get; set; }
        /// <summary>The end of the list--marks the oldest item added in the stack.</summary>
        protected int Tail { get; set; }
        /// <summary>The internal array to store the data.</summary>
        protected T[] DataList { get; set; }
        /// <summary>The current number of items within the list. This returns the actual number of items used between the Head and the Tail.</summary>
        public virtual int Length
        {
            get { return Head >= Tail ? Head - Tail : (Head + DataList.Length) - Tail; }
        }
        /// <summary>The total capacity of the stack.</summary>
        public int Capacity
        {
            get { return DataList.Length - 1; }
        }
        /// <summary></summary>
        public bool IsNewItems
        {
            get { return Head != Tail; }
        }

        /// <summary>
        /// The base constructor for the class.
        /// </summary>
        /// <param name="size">The total, fixed capacity of the list. The maximum size of the stack is <c>Int32.MaxValue - 1 </c>. The actual memory allocation of the stack will be one more than the instanciated maximum size; this is due to the implementation of the ring structure.</param>
        /// <exception cref="ArgumentException">Throws an ArgumentException if the size passed to the constructor is not valid</exception>
        public CircularEnumerable(int size)
        {
            if (size >= Int32.MaxValue - 1 || size < 0 || size.Equals(typeof(int))) { throw new ArgumentException("Stack size is not valid."); }
            DataList = new T[size + 1];
            Head = 0;
            Tail = 0;
        }

        /// <summary>
        /// Adds an item to the end of the stack.
        /// </summary>
        /// <param name="data">The data of type T to add.</param>
        public virtual void Add(T data)
        {
            if (++Head >= DataList.Length) { Head -= DataList.Length; }
            DataList[Head] = data;
            if (Head == Tail) { ++Tail; }
        }

        /// <summary>
        /// Returns the next item in the stack following a FIFO structure.
        /// </summary>
        /// <returns>Returns the next data point of type T in the stack.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws an exception if this method is called and there are no new items.</exception>
        /// <remarks>Make sure that there are new items in the stack before calling this method using the <c>IsNewItems</c> property.</remarks>
        /// <example>It is easy to process new items in bulk using:
        /// <code>
        /// var exampleList = new CircularEnumerable(size);
        /// 
        /// while (exampleList.IsNewItems)
        /// {
        ///     exampleList.Next()
        /// }
        /// </code></example>
        public virtual T Next()
        {
            if (Head == Tail) { throw new IndexOutOfRangeException("There are no new items in the list."); }
            if(++Tail >= DataList.Length) { Tail -= DataList.Length; }
            return DataList[Tail];
        }

        /// <summary>
        /// Resets the internal data and the Head/Tail locations. This is a more expensive operation as it clears the internal data structure.
        /// </summary>
        /// <remarks>This should only be called if there is a need to clear the underlying data. This is likely only useful if the type is <c>string</c>. Otherwise, use the <c>Reset</c> method.</remarks>
        /// <see cref="Reset"/>
        public void Clear()
        {
            Array.Clear(DataList, 0, DataList.Length);
            Head = 0;
            Tail = 0;
        }

        /// <summary>
        /// Resets the location of the Head and Tail without deleting the underlying data. To clear the underlying data, use <c>Clear</c>
        /// </summary>
        /// <see cref="Clear"/>
        public void Reset()
        {
            Head = 0;
            Tail = 0;
        }

    }
}
