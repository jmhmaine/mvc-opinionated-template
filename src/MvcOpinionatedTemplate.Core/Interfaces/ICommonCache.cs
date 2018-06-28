using System.Collections.Generic;

namespace MvcOpinionatedTemplate.Core.Interfaces
{
    public interface ICommonCache<T>
    {
        string CacheKey { get; set; }

        IReadOnlyList<T> GetAll();

        bool Set(IReadOnlyList<T> dataList, bool overwrite = false);

        bool Remove();
    }
}
