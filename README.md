<?xml version="1.0"?>
<doc>
    <assembly>
        <name>CircularEnumerable</name>
    </assembly>
    <members>
        <member name="T:CircularEnumerable.CircularEnumerable`1">
            <summary>
            <para>This abstract class defines the base functionallity for the circular enumerable classes.</para>
            <para>The circular structures avoid the constant copy-write cycles needed for lists in some type of FIFO/FILO stack structure. Interally, the structure uses a fixed-sized array with two moving "pointers" to keep track of the head and tail positions within the list. Further details are discusses in specific inhereted classes.</para>
            <para>Since the stack is fixed size and circular, if an item is added to the stack that exceeds the capacity of the stack, the oldest item will be dropped.</para>
            </summary>
            <typeparam name="T">The data type for the enumerable list.</typeparam>
            <remarks>The optimizations represented by this data structure are likely unneccesary in most use-cases. This library was origianlly developed to handle passing UDP data between a listening thread and a processing thread in a realtime application.</remarks>
        </member>
        <member name="P:CircularEnumerable.CircularEnumerable`1.Head">
            <summary>The front of the list--marks the most recent item added in the stack.</summary>
        </member>
        <member name="P:CircularEnumerable.CircularEnumerable`1.Tail">
            <summary>The end of the list--marks the oldest item added in the stack.</summary>
        </member>
        <member name="P:CircularEnumerable.CircularEnumerable`1.DataList">
            <summary>The internal array to store the data.</summary>
        </member>
        <member name="P:CircularEnumerable.CircularEnumerable`1.Length">
            <summary>The current number of items within the list. This returns the actual number of items used between the Head and the Tail.</summary>
        </member>
        <member name="P:CircularEnumerable.CircularEnumerable`1.Capacity">
            <summary>The total capacity of the stack.</summary>
        </member>
        <member name="P:CircularEnumerable.CircularEnumerable`1.IsNewItems">
            <summary></summary>
        </member>
        <member name="M:CircularEnumerable.CircularEnumerable`1.#ctor(System.Int32)">
            <summary>
            The base constructor for the class.
            </summary>
            <param name="size">The total, fixed capacity of the list. The maximum size of the stack is <c>Int32.MaxValue - 1 </c>. The actual memory allocation of the stack will be one more than the instanciated maximum size; this is due to the implementation of the ring structure.</param>
            <exception cref="T:System.ArgumentException">Throws an ArgumentException if the size passed to the constructor is not valid</exception>
        </member>
        <member name="M:CircularEnumerable.CircularEnumerable`1.Add(`0)">
            <summary>
            Adds an item to the end of the stack.
            </summary>
            <param name="data">The data of type T to add.</param>
        </member>
        <member name="M:CircularEnumerable.CircularEnumerable`1.Next">
            <summary>
            Returns the next item in the stack following a FIFO structure.
            </summary>
            <returns>Returns the next data point of type T in the stack.</returns>
            <exception cref="T:System.IndexOutOfRangeException">Throws an exception if this method is called and there are no new items.</exception>
            <remarks>Make sure that there are new items in the stack before calling this method using the <c>IsNewItems</c> property.</remarks>
            <example>It is easy to process new items in bulk using:
            <code>
            var exampleList = new CircularEnumerable(size);
            
            while (exampleList.IsNewItems)
            {
                exampleList.Next()
            }
            </code></example>
        </member>
        <member name="M:CircularEnumerable.CircularEnumerable`1.Clear">
            <summary>
            Resets the internal data and the Head/Tail locations. This is a more expensive operation as it clears the internal data structure.
            </summary>
            <remarks>This should only be called if there is a need to clear the underlying data. This is likely only useful if the type is <c>string</c>. Otherwise, use the <c>Reset</c> method.</remarks>
            <see cref="M:CircularEnumerable.CircularEnumerable`1.Reset"/>
        </member>
        <member name="M:CircularEnumerable.CircularEnumerable`1.Reset">
            <summary>
            Resets the location of the Head and Tail without deleting the underlying data. To clear the underlying data, use <c>Clear</c>
            </summary>
            <see cref="M:CircularEnumerable.CircularEnumerable`1.Clear"/>
        </member>
        <member name="T:CircularEnumerable.CircularList`1">
            <summary>
            This class is not fully implemented yet. Do not use.
            </summary>
            <typeparam name="T">The data type for the structure.</typeparam>
            <remarks>I need to rewrite the insertion method. It'll probably be easier to just copy to a new array and reset the pointers. At the moment, I don't need this class to work and I need to move on the to project that the original FILO stack was for.</remarks>
        </member>
        <member name="M:CircularEnumerable.CircularList`1.#ctor(System.Int32)">
            <summary>
            Constructor for the Circular List class.
            </summary>
            <param name="size">The size of the stack.</param>
        </member>
        <member name="M:CircularEnumerable.CircularList`1.Insert(System.Int32,`0)">
            <summary>
            Inserts a data point into the stack. This class does not work as intended yet.
            </summary>
            <param name="index">The point in the stack in which to insert the data.</param>
            <param name="data">The data of type T to insert into the stack.</param>
        </member>
        <member name="M:CircularEnumerable.CircularList`1.PrintDebug">
            <summary>
            A debugging method that prints the array to the console.
            </summary>
        </member>
        <member name="T:CircularEnumerable.CircularQueue`1">
            <summary>
            <para>Impliments a FIFO list using a circular data structure.</para>
            <para>The circular queue avoids the performance issues with collection copying inherent in the standard data types. This implimentation is of fixed size and strictly adheres to a FIFO paradigm. There is no support for mid-collection insertion.</para>
            <para>In the event that the list size is exceeded, the oldest entry in the list is overwritten with the newest.</para>
            </summary>
            <remarks>
            <para>Internally, the class uses a typed array to store the data. The data is written or read based on the incrementing of two "pointers" that mark the insertion point for new data and the read point for old data. The pointers can be accessed independently to allow for asynchonous read/write operations, or jointly in a single call.</para>
            <para>If the read pointer catches up to the write pointer, then the object will report no new entries. If the write pointer catches up to the read pointer, then the read pointer is incremented to stay one index ahead of the write pointer. See the <c>Read</c> and <c>Write</c> methods for more information.</para>
            </remarks>
            <typeparam name="T">Determines the type of data to be stored.</typeparam>
        </member>
        <member name="M:CircularEnumerable.CircularQueue`1.#ctor(System.Int32)">
            <summary>
            The constructor for the CircularList.
            </summary>
            <param name="size">The fixed size of the list.</param>
        </member>
        <member name="M:CircularEnumerable.CircularQueue`1.Tick(`0)">
            <summary>
            Performs a read and write operation in the same call.
            </summary>
            <param name="data">Data of type T to write to the list.</param>
            <returns>Returns data of type T from the list.</returns>
            <remarks>Doubtful that this method is useful, but included for the sake of completion. I might extend this into a delayline-like function later.</remarks>
        </member>
        <member name="T:CircularEnumerable.CircularReverseQueue`1">
            <summary>
            The reverse queue is a strict FILO stack. It is very similar to to the <c>CircularQueue</c> in implimentation, except for the the FILO structure. 
            </summary>
            <typeparam name="T">The data type for the structure.</typeparam>
        </member>
        <member name="M:CircularEnumerable.CircularReverseQueue`1.#ctor(System.Int32)">
            <summary>
            The constructor for the FILO queue.
            </summary>
            <param name="size">The size of the data stack.</param>
        </member>
        <member name="M:CircularEnumerable.CircularReverseQueue`1.Next">
            <summary>
            Returns the most recent data point and removes it from the stack.
            </summary>
            <returns>Returns the most recent data point of type T.</returns>
            <exception cref="T:System.IndexOutOfRangeException">If there are no items in the stack, it throws an exception.</exception>
        </member>
    </members>
</doc>
