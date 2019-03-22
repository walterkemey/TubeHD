using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PrimeTube.ViewModel
{
    static public class ListExtension
    {
        public static void AddTo<T>(this ObservableCollection<T> itemsSource, ObservableCollection<T> itemsDest)
        {

            foreach (var item in itemsSource)
            {
                itemsDest.Add(item);
            }
        }
    }


    public class IncrementalLoadingCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        //delegate which populate the next items        
        Func<CancellationToken, uint, Task<ObservableCollection<T>>> _func;

        //Use by HasMoreItems
        uint _maxItems;

        //No limit for the data, but becareful with the memory consumption
        Boolean _isInfinite;

        //use to stop the virtualization and the incremental loading
        CancellationToken _cts;

        public IncrementalLoadingCollection(Func<CancellationToken, uint, Task<ObservableCollection<T>>> func)
            : this(func, 0)
        {
        }

        public IncrementalLoadingCollection(Func<CancellationToken, uint, Task<ObservableCollection<T>>> func, uint maxItems)
        {
            _func = func;
            if (maxItems == 0) //Infinite
            {
                _isInfinite = true;
            }
            else
            {
                _maxItems = maxItems;
                _isInfinite = false;
            }
        }

        public CancellationToken GetCancellationToken()
        {
            return _cts;
        }

        public bool HasMoreItems
        {
            get
            {
                if (_cts.IsCancellationRequested)
                    return false;

                if (_isInfinite)
                {
                    return true;
                }
                return this.Count < _maxItems;
            }
        }

        public Windows.Foundation.IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return AsyncInfo.Run((cts) => InternalLoadMoreItemsAsync(cts, count));
        }

        async Task<LoadMoreItemsResult> InternalLoadMoreItemsAsync(CancellationToken cts, uint count)
        {

            ObservableCollection<T> intermediate = null;
            _cts = cts;
            var baseIndex = this.Count;
            uint numberOfitemsTogenerate = 0;

            if (!_isInfinite)
            {
                if (baseIndex + count < _maxItems)
                {
                    numberOfitemsTogenerate = count;

                }
                else
                {
                    //take the last items
                    numberOfitemsTogenerate = _maxItems - (uint)(baseIndex);
                }

            }
            else
            {
                numberOfitemsTogenerate = count;
            }
            intermediate = await _func(cts, numberOfitemsTogenerate);
            if (intermediate.Count == 0) //no more items stop the incremental loading 
            {
                _maxItems = (uint)this.Count;
                _isInfinite = false;
            }
            else
            {
                intermediate.AddTo<T>(this);
            }
            return new LoadMoreItemsResult { Count = (uint)intermediate.Count };
        }
    }

    public class IncrementalLoadingCollection2<T> : ISupportIncrementalLoading, IList, INotifyCollectionChanged
    {

        //delegate which populate the next items
        //can be passed as a lambda
        Func<CancellationToken, uint, Task<List<T>>> _func;

        //Use by HasMoreItems
        uint _maxItems;

        Boolean _isInfinite;
        List<T> _internalStorage;
        public IncrementalLoadingCollection2(Func<CancellationToken, uint, Task<List<T>>> func)
            : this(func, 0)
        {

        }
        public IncrementalLoadingCollection2(Func<CancellationToken, uint, Task<List<T>>> func, uint maxItems)
        {

            _func = func;
            _internalStorage = new List<T>();

            if (maxItems == 0) //Infinite
            {
                _isInfinite = true;
            }
            else
            {
                _maxItems = maxItems;
                _isInfinite = false;
            }

        }

        #region IncrementalLoading
        CancellationToken _cts;
        public bool HasMoreItems
        {
            get
            {
                if (_cts.IsCancellationRequested)
                    return false;

                if (_isInfinite)
                {
                    return true;
                }
                return this.Count < _maxItems;
            }
        }

        public Windows.Foundation.IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {

            return AsyncInfo.Run((c) => InternalLoadMoreItemsAsync(c, count));
        }

        async Task<LoadMoreItemsResult> InternalLoadMoreItemsAsync(CancellationToken c, uint count)
        {
            List<T> intermediate = null;

            _cts = c;

            var baseIndex = _internalStorage.Count;
            uint numberOfitemsTogenerate = 0;

            if (!_isInfinite)
            {
                if (baseIndex + count < _maxItems)
                {
                    numberOfitemsTogenerate = count;

                }
                else
                {
                    //take the last next items
                    numberOfitemsTogenerate = _maxItems - (uint)(baseIndex);
                }

            }
            else
            {
                numberOfitemsTogenerate = count;
            }
            intermediate = await _func(c, numberOfitemsTogenerate);
            if (intermediate.Count == 0) //no more items
            {
                _maxItems = (uint)this.Count;
                //Stop the incremental loading
                _isInfinite = false;
            }
            else
            {
                _internalStorage.AddRange(intermediate);

            }

            NotifyOfInsertedItems(baseIndex, intermediate.Count);
            return new LoadMoreItemsResult { Count = (uint)intermediate.Count };


        }

        #endregion

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        void NotifyOfInsertedItems(int baseIndex, int count)
        {
            if (CollectionChanged == null)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _internalStorage[i + baseIndex], i + baseIndex);
                CollectionChanged(this, args);
            }
        }

        //#region IList

        public int Add(object value)
        {
            _internalStorage.Add((T)value);
            //return the position
            return _internalStorage.Count - 1;
        }

        public void Clear()
        {
            _internalStorage.Clear();
        }

        public bool Contains(object value)
        {
            return _internalStorage.Contains((T)value);
        }

        public int IndexOf(object value)
        {
            return _internalStorage.IndexOf((T)value);
        }

        public void Insert(int index, object value)
        {
            _internalStorage.Insert(index, (T)value);
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public void Remove(object value)
        {
            _internalStorage.Remove((T)value);
        }

        public void RemoveAt(int index)
        {
            _internalStorage.RemoveAt(index);
        }

        public object this[int index]
        {
            get
            {
                return _internalStorage[index];
            }
            set
            {
                _internalStorage[index] = (T)value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            ((IList)_internalStorage).CopyTo(array, index);
        }

        public int Count
        {
            get { return _internalStorage.Count; }
        }

        public bool IsSynchronized
        {
            get { return true; }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            return _internalStorage.GetEnumerator();
        }
    }
}