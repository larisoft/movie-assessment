using System;
using System.Threading.Tasks;

namespace rest_api.interfaces
{
    public interface IHttpService
    {
        Task<string> GetJsonDataAsync(string url);
    }
}
