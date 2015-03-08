using System;
using System.Threading.Tasks;
using FreelanceHunt.Service;

namespace FreelanceHunt.Incremental
{
    public interface IPagedSource<T>
    {
        Task<IPagedResponse<T>> GetPage(int pageIndex, IWebService webService, string query = default(string), int pageSize = 15);
        Func<int, int, Task<IPagedResponse<T>>> GetPageDelegate { get; set; }
    }
}
