using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Caching.Hybrid;
using System;
using System.Diagnostics;  // For measuring execution time
using System.Threading;
using System.Threading.Tasks;
using HybridCachePOC;

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHybridCache();  // Register HybridCache
                services.AddSingleton<SomeService>();  // Register our custom data service
            })
            .Build();

        var someService = host.Services.GetRequiredService<SomeService>();

        // Measure the time for the first request (fetching from slow source)
        Stopwatch stopwatch = Stopwatch.StartNew();
        Console.WriteLine("Fetching data...");
        string data = await someService.GetSomeInfoAsync("User", 123);
        stopwatch.Stop();
        Console.WriteLine($"Data from cache: {data}");
        Console.WriteLine($"Time taken for first request: {stopwatch.ElapsedMilliseconds / 1000.0} seconds\n");

        // Measure the time for the second request (retrieving from cache)
        stopwatch.Restart();
        Console.WriteLine("Fetching data again...");
        string cachedData = await someService.GetSomeInfoAsync("User", 123);
        stopwatch.Stop();
        Console.WriteLine($"Cached data: {cachedData}");
        Console.WriteLine($"Time taken for second request: {stopwatch.ElapsedMilliseconds / 1000.0} seconds\n");

        await host.StopAsync();
    }
}