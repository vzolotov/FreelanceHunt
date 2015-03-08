using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml.Data;

namespace FreelanceHunt.Incremental
{
    public class BaseIncrementalSource<T, K> : ObservableCollection<K>, ISupportIncrementalLoading
        where T : IPagedSource<K>, new()
    {

        #region Члены ISupportIncrementalLoading

        public bool HasMoreItems
        {
            get { throw new NotImplementedException(); }
        }

        public Windows.Foundation.IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
