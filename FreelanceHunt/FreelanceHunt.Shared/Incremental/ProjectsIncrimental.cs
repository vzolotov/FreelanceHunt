using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FreelanceHunt.Models;
using FreelanceHunt.Service;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace FreelanceHunt.Incremental
{
    public class ProjectsIncrimental<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        private ushort _currentPage;
        private Func<ushort,Task<List<T>>> _myDelegate;
        public ProjectsIncrimental(Func<ushort, Task<List<T>>> myDelegate)
        {
            _currentPage = 1;
            _myDelegate = myDelegate;
        }
        #region Члены ISupportIncrementalLoading

        private bool _hasMoreItems = true;
        public bool HasMoreItems
        {
            get
            {
                return _hasMoreItems;
            }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            CoreDispatcher dispatcher = Window.Current.Dispatcher;
            return Task.Run<LoadMoreItemsResult>(
                async () =>
                {
                    var result = await _myDelegate.Invoke(this._currentPage);
                    if ((result == null) || (result.Count == 0))
                    {
                        _hasMoreItems = false;
                        return default(LoadMoreItemsResult);
                    }
                    else
                    {
                        _currentPage++;
                        await dispatcher.RunAsync(
                        CoreDispatcherPriority.Normal,
                        () =>
                        {
                            foreach (T item in result)
                                this.Add(item);
                        });
                        return new LoadMoreItemsResult() { Count = (uint)result.Count() };
                    }
                }).AsAsyncOperation<LoadMoreItemsResult>();
        }
        #endregion
    }
}
