using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace CachingTechniques.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        private readonly IDataRepository _repository;

        public CacheController(IMemoryCache memoryCache, IDataRepository repository, IDistributedCache distributedCache)
        {
            _memoryCache = memoryCache;
            _repository = repository;
            _distributedCache = distributedCache;
        }
        
        [HttpGet("GetInMemoryCacheData")]
        public List<Data> GetInMemoryCacheData()
        {
            List<Data> data;

            if (_memoryCache.TryGetValue("data", out data)) return data;

            data = _repository.GetData().ToList();

            _memoryCache.Set("data", data, new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(3))  // Sliding expiration of 10 minutes
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10))); // Absolute expiration of 1 hour
            
            return data;
        }

        [HttpGet("GetDistributedCacheData")]
        public async Task<List<Data>> GetDistributedCacheData()
        {
            var value = await _distributedCache.GetStringAsync("data");

            if (!string.IsNullOrEmpty(value))
                return System.Text.Json.JsonSerializer.Deserialize<List<Data>>(value);

            var data = _repository.GetData().ToList();
            await _distributedCache.SetStringAsync("data", System.Text.Json.JsonSerializer.Serialize(data), new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(3))  // Sliding expiration of 10 minutes
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10))); // Absolute expiration of 1 hour
            return data;
        }
    }
}
