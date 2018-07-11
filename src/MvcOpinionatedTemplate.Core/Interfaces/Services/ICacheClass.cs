using System.Threading.Tasks;

namespace MvcOpinionatedTemplate.Core.Interfaces.Services
{
    public interface ICacheClass
    {
        Task<T> GetAsync<T>(string key) where T : class;

        Task SetAsync<T>(string key, T item) where T : class;
    }
}