<a name='assembly'></a>
# CircularList

This is a simple class that creates a FIFO queue using a circular data structure. A circular structure avoids the overhead associated with the standard implimentations of deleteing items in an array or list which result in the program needing to copy data points to keep the order of the list sane.

## Contents

- [CircularList\`1](#T-CircularList-CircularList`1 'CircularList.CircularList`1')
  - [#ctor(size)](#M-CircularList-CircularList`1-#ctor-System-Int32- 'CircularList.CircularList`1.#ctor(System.Int32)')
  - [DataList](#P-CircularList-CircularList`1-DataList 'CircularList.CircularList`1.DataList')
  - [Length](#P-CircularList-CircularList`1-Length 'CircularList.CircularList`1.Length')
  - [ReadPoint](#P-CircularList-CircularList`1-ReadPoint 'CircularList.CircularList`1.ReadPoint')
  - [WritePoint](#P-CircularList-CircularList`1-WritePoint 'CircularList.CircularList`1.WritePoint')
  - [GetNext()](#M-CircularList-CircularList`1-GetNext 'CircularList.CircularList`1.GetNext')
  - [IsNewItems()](#M-CircularList-CircularList`1-IsNewItems 'CircularList.CircularList`1.IsNewItems')
  - [Reset()](#M-CircularList-CircularList`1-Reset 'CircularList.CircularList`1.Reset')
  - [Tick(data)](#M-CircularList-CircularList`1-Tick-`0- 'CircularList.CircularList`1.Tick(`0)')
  - [Write(data)](#M-CircularList-CircularList`1-Write-`0- 'CircularList.CircularList`1.Write(`0)')

<a name='T-CircularList-CircularList`1'></a>
## CircularList\`1 `type`

##### Namespace

CircularList

##### Summary

Impliments a FIFO list using a circular data structure.

The circular list avoids the performance issues with collection copying inherent in the standard data types. This inplimentation is of fixed size and strictly adheres to a FIFO paradigm. There is no support for mid-collection insertion.

In the event that the list size is exceeded, the oldest entry in the list is overwritten with the newest.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Determines the type of data to be stored. |

##### Remarks

Internally, the class uses a typed array to store the data. The data is written or read based on the incrementing of two "pointers" that mark the insertion point for new data and the read point for old data. The pointers can be accessed independently to allow for asynchonous read/write operations, or jointly in a single call.

If the read pointer catches up to the write pointer, then the object will report no new entries. If the write pointer catches up to the read pointer, then the read pointer is incremented to stay one index ahead of the write pointer. See the `Read` and `Write` methods for more information.

<a name='M-CircularList-CircularList`1-#ctor-System-Int32-'></a>
### #ctor(size) `constructor`

##### Summary

The constructor for the CircularList.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| size | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The fixed size of the list. |

<a name='P-CircularList-CircularList`1-DataList'></a>
### DataList `property`

##### Summary

The data array of type T.

<a name='P-CircularList-CircularList`1-Length'></a>
### Length `property`

##### Summary

The length of `DataList`

<a name='P-CircularList-CircularList`1-ReadPoint'></a>
### ReadPoint `property`

##### Summary

The next index to be read.

<a name='P-CircularList-CircularList`1-WritePoint'></a>
### WritePoint `property`

##### Summary

The next index for data entry.

<a name='M-CircularList-CircularList`1-GetNext'></a>
### GetNext() `method`

##### Summary

Gets the next value from the list.

##### Returns

Returns data of type T from the list.

##### Parameters

This method has no parameters.

<a name='M-CircularList-CircularList`1-IsNewItems'></a>
### IsNewItems() `method`

##### Summary

Checks if there are new items in the list that have not been read out.

##### Returns

Returns a boolean value. True for new items, false if there are no new items.

##### Parameters

This method has no parameters.

<a name='M-CircularList-CircularList`1-Reset'></a>
### Reset() `method`

##### Summary

Resets the list to its default state.

##### Parameters

This method has no parameters.

<a name='M-CircularList-CircularList`1-Tick-`0-'></a>
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

<a name='M-CircularList-CircularList`1-Write-`0-'></a>
### Write(data) `method`

##### Summary

Writes the next entry in the list.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [\`0](#T-`0 '`0') | The data of type T to write. |
