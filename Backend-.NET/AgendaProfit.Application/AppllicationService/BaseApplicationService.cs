using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace AgendaProfit.Application.AppllicationService;

public abstract class BaseApplicationService
{
    protected readonly IMemoryCache _memoryCache;

    private static readonly ConcurrentDictionary<Type, ConcurrentBag<string>> _cacheKeysByService
        = new();

    protected BaseApplicationService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    protected void SetCache<T>(string key, T value, TimeSpan? expiration = null)
    {
        var options = new MemoryCacheEntryOptions();
        if (expiration.HasValue)
            options.SetAbsoluteExpiration(expiration.Value);

        _memoryCache.Set(key, value, options);

        var keys = _cacheKeysByService.GetOrAdd(GetType(), _ => new ConcurrentBag<string>());
        if (!keys.Contains(key))
        {
            keys.Add(key);
        }
    }

    protected bool TryGetCache<T>(string key, out T value) =>
        _memoryCache.TryGetValue(key, out value);

    protected void ClearCache()
    {
        if (_cacheKeysByService.TryGetValue(GetType(), out var keys))
        {
            foreach (var key in keys)
            {
                _memoryCache.Remove(key);
            }
        }
    }

    protected async Task<T> GetOrSetCacheAsync<T>(string key, Func<Task<T>> fetchFunc, TimeSpan? expiration = null)
    {
        if (TryGetCache<T>(key, out var value))
            return value;

        value = await fetchFunc();

        if (value != null)
            SetCache(key, value, expiration);

        return value;
    }
}