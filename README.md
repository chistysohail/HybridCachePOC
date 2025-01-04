# HybridCache in .NET 9 - Caching Made Smarter!

## 🚀 Project Overview
This project demonstrates how to use **HybridCache** in **.NET 9**, a powerful caching system that combines **fast local memory caching** with **scalable distributed caching**. This approach makes applications run faster, reduces database load, and improves efficiency.

## 📌 What is HybridCache?
HybridCache is a **new caching system introduced in .NET 9** that blends two caching techniques:
1. **In-Memory Caching** – Fastest way to retrieve data (like keeping sticky notes on your desk).
2. **Distributed Caching** – Shares cached data across multiple servers (like using Google Drive for shared documents).

With **HybridCache**, you get the best of both worlds:
✅ **Fast retrieval** when data is available in memory.  
✅ **Scalability** when multiple servers need access to the same data.  
✅ **Reduced database load**, making your app more efficient.

## 🎯 Why Use HybridCache?
Imagine an **e-commerce website** where users frequently check product prices and availability. Instead of querying the database every time, HybridCache:
- 🏎 **Stores the data in fast memory** for quick access.
- 🌍 **Syncs data across multiple servers** so users always get the latest updates.
- 💰 **Reduces database queries**, improving speed and cutting costs.

## 🏗️ How This Project Works
This project is a **.NET 9 console application** that:
1. **Registers HybridCache** as a service.
2. **Fetches data** (simulating slow database/API calls).
3. **Caches the result**, so future requests are instant.
4. **Demonstrates performance improvements** by measuring response times.

## 🔧 How to Run This Project
### **1️⃣ Clone the Repository**
```sh
git clone https://github.com/your-repo/HybridCachePOC.git
cd HybridCachePOC
```

### **2️⃣ Build & Run Using Docker**
```sh
docker build -t hybridcachepoc .
docker run --rm hybridcachepoc
```

### **3️⃣ Run Without Docker (Using .NET CLI)**
```sh
dotnet build -c Release
dotnet run
```

## 📊 Expected Output (Performance Test)
```
Fetching data...
Fetching data from source for User-123...
Data from cache: Data for User-123 generated at 2024-01-03 10:00:00
Time taken for first request: 1.002 seconds

Fetching data again...
Cached data: Data for User-123 generated at 2024-01-03 10:00:00
Time taken for second request: 0.0001 seconds
```
🔹 **First Request:** Slow (~1 second) because it fetches from the source.  
🔹 **Second Request:** Instant (<1ms) because it's retrieved from **HybridCache**.

## 🛠️ Technologies Used
- **.NET 9** (for modern caching support)
- **HybridCache** (fast and efficient caching)
- **Docker** (for containerization)
- **Dependency Injection** (to manage services efficiently)

## 🚀 Conclusion
🔹 **HybridCache makes caching smarter** by combining memory & distributed caching.  
🔹 **Improves app performance** by reducing database load.  
🔹 **Ideal for high-traffic applications** like e-commerce, dashboards, and APIs.  

📢 **Try it out and see the speed improvements yourself!** 🚀

