using Microsoft.Extensions.Caching.Hybrid;  // Import HybridCache library
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HybridCachePOC;  // Namespace to organize code files

public class SomeService
{
    private readonly HybridCache _cache;  // HybridCache instance (used to store/retrieve data)

    // Constructor: Inject HybridCache when SomeService is created
    public SomeService(HybridCache cache)
    {
        _cache = cache;  // Store the injected HybridCache instance
    }

    /// <summary>
    /// Retrieves data from cache if available; otherwise, fetches it from the source.
    /// </summary>
    /// <param name="name">User name or category</param>
    /// <param name="id">Unique identifier for data</param>
    /// <param name="token">Cancellation token (optional)</param>
    /// <returns>Cached or freshly retrieved data</returns>
    public async Task<string> GetSomeInfoAsync(string name, int id, CancellationToken token = default)
    {
        // Attempt to get data from cache, or fetch it if not available
        return await _cache.GetOrCreateAsync(
            $"{name}-{id}",  // Unique key for storing/retrieving data
            async cancel => await GetDataFromTheSourceAsync(name, id, cancel),  // Fallback function to fetch new data if not cached
            cancellationToken: token  // Optional cancellation token
        );
    }

    /// <summary>
    /// Simulates fetching data from a slow source (e.g., a database or an API).
    /// </summary>
    /// <param name="name">User name or category</param>
    /// <param name="id">Unique identifier for data</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>Freshly fetched data string</returns>
    private async Task<string> GetDataFromTheSourceAsync(string name, int id, CancellationToken token)
    {
        // Simulate delay (to mimic slow database/API response)
        Console.WriteLine($"Fetching data from source for {name}-{id}...");
        await Task.Delay(1000, token);  // Introduce 1 second delay

        // Generate and return new data
        return $"Data for {name}-{id} generated at {DateTime.Now}";
    }
}
