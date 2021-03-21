<a name='assembly'></a>
# CircularEnumerable

## Contents

- [CircularEnumerable\`1](#T-CircularEnumerable-CircularEnumerable`1 'CircularEnumerable.CircularEnumerable`1')
  - [#ctor(size)](#M-CircularEnumerable-CircularEnumerable`1-#ctor-System-Int32- 'CircularEnumerable.CircularEnumerable`1.#ctor(System.Int32)')
  - [Capacity](#P-CircularEnumerable-CircularEnumerable`1-Capacity 'CircularEnumerable.CircularEnumerable`1.Capacity')
  - [DataList](#P-CircularEnumerable-CircularEnumerable`1-DataList 'CircularEnumerable.CircularEnumerable`1.DataList')
  - [Head](#P-CircularEnumerable-CircularEnumerable`1-Head 'CircularEnumerable.CircularEnumerable`1.Head')
  - [IsNewItems](#P-CircularEnumerable-CircularEnumerable`1-IsNewItems 'CircularEnumerable.CircularEnumerable`1.IsNewItems')
  - [Length](#P-CircularEnumerable-CircularEnumerable`1-Length 'CircularEnumerable.CircularEnumerable`1.Length')
  - [Tail](#P-CircularEnumerable-CircularEnumerable`1-Tail 'CircularEnumerable.CircularEnumerable`1.Tail')
  - [Add(data)](#M-CircularEnumerable-CircularEnumerable`1-Add-`0- 'CircularEnumerable.CircularEnumerable`1.Add(`0)')
  - [Clear()](#M-CircularEnumerable-CircularEnumerable`1-Clear 'CircularEnumerable.CircularEnumerable`1.Clear')
  - [Next()](#M-CircularEnumerable-CircularEnumerable`1-Next 'CircularEnumerable.CircularEnumerable`1.Next')
  - [Reset()](#M-CircularEnumerable-CircularEnumerable`1-Reset 'CircularEnumerable.CircularEnumerable`1.Reset')
- [CircularList\`1](#T-CircularEnumerable-CircularList`1 'CircularEnumerable.CircularList`1')
  - [#ctor(size)](#M-CircularEnumerable-CircularList`1-#ctor-System-Int32- 'CircularEnumerable.CircularList`1.#ctor(System.Int32)')
- [CircularQueue\`1](#T-CircularEnumerable-CircularQueue`1 'CircularEnumerable.CircularQueue`1')
  - [#ctor(size)](#M-CircularEnumerable-CircularQueue`1-#ctor-System-Int32- 'CircularEnumerable.CircularQueue`1.#ctor(System.Int32)')
  - [Tick(data)](#M-CircularEnumerable-CircularQueue`1-Tick-`0- 'CircularEnumerable.CircularQueue`1.Tick(`0)')
- [CircularReverseQueue\`1](#T-CircularEnumerable-CircularReverseQueue`1 'CircularEnumerable.CircularReverseQueue`1')
  - [#ctor(size)](#M-CircularEnumerable-CircularReverseQueue`1-#ctor-System-Int32- 'CircularEnumerable.CircularReverseQueue`1.#ctor(System.Int32)')
  - [Next()](#M-CircularEnumerable-CircularReverseQueue`1-Next 'CircularEnumerable.CircularReverseQueue`1.Next')

<a name='T-CircularEnumerable-CircularEnumerable`1'></a>
## CircularEnumerable\`1 `type`

##### Namespace

CircularEnumerable

##### Summary

This abstract class defines the base functionallity for the circular enumerable classes.

The circular structures avoid the constant copy-write cycles needed for lists in some type of FIFO/FILO stack structure. Interally, the structure uses a fixed-sized array with two moving "pointers" to keep track of the head and tail positions within the list. Further details are discusses in specific inhereted classes.

Since the stack is fixed size and circular, if an item is added to the stack that exceeds the capacity of the stack, the oldest item will be dropped.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The data type for the enumerable list. |

##### Remarks

The optimizations represented by this data structure are likely unneccesary in most use-cases. This library was origianlly developed to handle passing UDP data between a listening thread and a processing thread in a realtime application.

<a name='M-CircularEnumerable-CircularEnumerable`1-#ctor-System-Int32-'></a>
### #ctor(size) `constructor`

##### Summary

The base constructor for the class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| size | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The total, fixed capacity of the list. The maximum size of the stack is `Int32.MaxValue - 1 `. The actual memory allocation of the stack will be one more than the instanciated maximum size; this is due to the implementation of the ring structure. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throws an ArgumentException if the size passed to the constructor is not valid |

<a name='P-CircularEnumerable-CircularEnumerable`1-Capacity'></a>
### Capacity `property`

##### Summary

The total capacity of the stack.

<a name='P-CircularEnumerable-CircularEnumerable`1-DataList'></a>
### DataList `property`

##### Summary

The internal array to store the data.

<a name='P-CircularEnumerable-CircularEnumerable`1-Head'></a>
### Head `property`

##### Summary

The front of the list--marks the most recent item added in the stack.

<a name='P-CircularEnumerable-CircularEnumerable`1-IsNewItems'></a>
### IsNewItems `property`

##### Summary



<a name='P-CircularEnumerable-CircularEnumerable`1-Length'></a>
### Length `property`

##### Summary

The current number of items within the list. This returns the actual number of items used between the Head and the Tail.

<a name='P-CircularEnumerable-CircularEnumerable`1-Tail'></a>
### Tail `property`

##### Summary

The end of the list--marks the oldest item added in the stack.

<a name='M-CircularEnumerable-CircularEnumerable`1-Add-`0-'></a>
### Add(data) `method`

##### Summary

Adds an item to the end of the stack.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [\`0](#T-`0 '`0') | The data of type T to add. |

<a name='M-CircularEnumerable-CircularEnumerable`1-Clear'></a>
### Clear() `method`

##### Summary

Resets the internal data and the Head/Tail locations. This is a more expensive operation as it clears the internal data structure.

##### Parameters

This method has no parameters.

##### Remarks

This should only be called if there is a need to clear the underlying data. This is likely only useful if the type is `string`. Otherwise, use the `Reset` method.

<a name='M-CircularEnumerable-CircularEnumerable`1-Next'></a>
### Next() `method`

##### Summary

Returns the next item in the stack following a FIFO structure.

##### Returns

Returns the next data point of type T in the stack.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | Throws an exception if this method is called and there are no new items. |

##### Example

It is easy to process new items in bulk using:

```
var exampleList = new CircularEnumerable(size);
while (exampleList.IsNewItems)
{
    exampleList.Next()
}
```

##### Remarks

Make sure that there are new items in the stack before calling this method using the `IsNewItems` property.

<a name='M-CircularEnumerable-CircularEnumerable`1-Reset'></a>
### Reset() `method`

##### Summary

Resets the location of the Head and Tail without deleting the underlying data. To clear the underlying data, use `Clear`

##### Parameters

This method has no parameters.

<a name='T-CircularEnumerable-CircularList`1'></a>
## CircularList\`1 `type`

##### Namespace

CircularEnumerable

##### Summary

This class mirrors the ``

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The data type for the structure. |

<a name='M-CircularEnumerable-CircularList`1-#ctor-System-Int32-'></a>
### #ctor(size) `constructor`

##### Summary

Constructor for the Circular List class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| size | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The size of the stack. |

<a name='T-CircularEnumerable-CircularQueue`1'></a>
## CircularQueue\`1 `type`

##### Namespace

CircularEnumerable

##### Summary

Impliments a FIFO list using a circular data structure.

The circular queue avoids the performance issues with collection copying inherent in the standard data types. This implimentation is of fixed size and strictly adheres to a FIFO paradigm. There is no support for mid-collection insertion.

In the event that the list size is exceeded, the oldest entry in the list is overwritten with the newest.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Determines the type of data to be stored. |

##### Remarks

Internally, the class uses a typed array to store the data. The data is written or read based on the incrementing of two "pointers" that mark the insertion point for new data and the read point for old data. The pointers can be accessed independently to allow for asynchonous read/write operations, or jointly in a single call.

If the read pointer catches up to the write pointer, then the object will report no new entries. If the write pointer catches up to the read pointer, then the read pointer is incremented to stay one index ahead of the write pointer. See the `Read` and `Write` methods for more information.

<a name='M-CircularEnumerable-CircularQueue`1-#ctor-System-Int32-'></a>
### #ctor(size) `constructor`

##### Summary

The constructor for the CircularList.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| size | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The fixed size of the list. |

<a name='M-CircularEnumerable-CircularQueue`1-Tick-`0-'></a>
### Tick(data) `method`

##### Summary

Performs a read and write operation in the same call.

##### Returns

Returns data of type T from the list.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [\`0](#T-`0 '`0') | Data of type T to write to the list. |

##### Remarks

Doubtful that this method is useful, but included for the sake of completion. I might extend this into a delayline-like function later.

<a name='T-CircularEnumerable-CircularReverseQueue`1'></a>
## CircularReverseQueue\`1 `type`

##### Namespace

CircularEnumerable

##### Summary

The reverse queue is a strict FILO stack. It is very similar to to the `CircularQueue` in implimentation, except for the the FILO structure.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The data type for the structure. |

<a name='M-CircularEnumerable-CircularReverseQueue`1-#ctor-System-Int32-'></a>
### #ctor(size) `constructor`

##### Summary

The constructor for the FILO queue.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| size | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The size of the data stack. |

<a name='M-CircularEnumerable-CircularReverseQueue`1-Next'></a>
### Next() `method`

##### Summary

Returns the most recent data point and removes it from the stack.

##### Returns

Returns the most recent data point of type T.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | If there are no items in the stack, it throws an exception. |
