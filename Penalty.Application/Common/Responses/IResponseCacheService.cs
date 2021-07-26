using System;
using System.Threading.Tasks;

namespace Penalty.Application.Common.Responses
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeLive);
        Task<string> GetCacheResponseAsync(string cacheKey);
    }
}
