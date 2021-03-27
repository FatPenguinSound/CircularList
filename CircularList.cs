using System;
using System.Collections.Generic;
using System.Text;

namespace CircularEnumerable
{
    /// <summary>
    /// This class is not fully implemented yet. Do not use.
    /// </summary>
    /// <typeparam name="T">The data type for the structure.</typeparam>
    /// <remarks>I need to rewrite the insertion method. It'll probably be easier to just copy to a new array and reset the pointers. At the moment, I don't need this class to work and I need to move on the to project that the original FILO stack was for.</remarks>
    public class CircularList<T> : CircularEnumerable<T>
    {
        /// <summary>
        /// Constructor for the Circular List class.
        /// </summary>
        /// <param name="size">The size of the stack.</param>
        public CircularList(int size) : base(size)
        {
            throw new NotImplementedException("This class is not yet implimented");
        }

        /// <summary>
        /// Inserts a data point into the stack. This class does not work as intended yet.
        /// </summary>
        /// <param name="index">The point in the stack in which to insert the data.</param>
        /// <param name="data">The data of type T to insert into the stack.</param>
        public void Insert(int index, T data)
        {
            if (index > Length) { throw new IndexOutOfRangeException(); }
            if (Head > Tail)
            {
                int insertionPoint = Tail + index > DataList.Length ? Tail + index - DataList.Length : Tail + index;
                insertionPoint++;
                if (insertionPoint >= DataList.Length) { insertionPoint -= DataList.Length; }
                int numToMove = Length - index;

                for (int i = Length - numToMove; i > -1; i--)
                {
                    int p = insertionPoint + i;
                    DataList[p + 1 > Capacity ? p + 1 - Capacity : p + 1] = DataList[p];
                }

                DataList[insertionPoint] = data;
                Head++;
                if (Head >= DataList.Length) { Head -= DataList.Length; }
                if (Head == Tail) { if (++Tail >= DataList.Length) { Tail -= DataList.Length; } }
            }
            else if (Head < Tail)
            {
                int insertionPoint = Tail + index > DataList.Length ? Tail + index - DataList.Length : Tail + index;
                insertionPoint++;
                int numToMove = Length - index;

                for (int i = Length - numToMove; i > -1; i--)
                {
                    int p = insertionPoint + i;
                    if (p >= DataList.Length) { p -= DataList.Length; }
                    DataList[p + 1 > Capacity ? p + 1 - Capacity : p + 1] = DataList[p];
                    PrintDebug();
                }

                DataList[insertionPoint] = data;
                Head++;
                if (Head >= DataList.Length) { Head -= DataList.Length; }
                if (Head == Tail) { if (++Tail >= DataList.Length) { Tail -= DataList.Length; } }
            }
            else
            {
                Console.WriteLine("What?");
            }
        }

        /// <summary>
        /// A debugging method that prints the array to the console.
        /// </summary>
        private void PrintDebug()
        {
            var str = "";
            for (int i = 0; i < DataList.Length; i++)
            {
                T item = DataList[Tail + i >= DataList.Length ? Tail + i - DataList.Length : Tail + i];
                str += item.ToString() + ", ";
            }

            Console.WriteLine(str);
        }
    }
}
