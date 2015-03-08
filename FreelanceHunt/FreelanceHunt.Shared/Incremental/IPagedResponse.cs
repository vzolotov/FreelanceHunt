using System;
using System.Collections.Generic;
using System.Text;

namespace FreelanceHunt.Incremental
{
    public interface IPagedResponse<T>
    {
        IEnumerable<T> Items { get; }
        int VirtualCount { get; }
    }
}
