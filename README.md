# Caching Techniques

This project demonstrates the use of in-memory caching (`IMemoryCache`) and distributed caching (`IDistributedCache`) with Redis in an ASP.NET Core application. There are two HTTP GET methods:
- One retrieves data from **IMemoryCache**.
- The other retrieves data from **IDistributedCache** using Redis as the cache store.

## Prerequisites

### 1. **.NET Core SDK**
   - Install the latest version of the .NET Core SDK from the official website.

### 2. **Redis for Distributed Cache (using Docker)**
   - This project uses Redis for `IDistributedCache`. You can run Redis locally using Docker.
   
   To pull and run Redis using Docker, execute the following steps:
   1. Pull Redis image from Docker Hub.
   2. Run Redis in a detached mode, mapping it to the default port `6379`.

### 3. **Required NuGet Packages**

   - For `IMemoryCache` (built into ASP.NET Core):
     - No additional packages are required as `IMemoryCache` is part of the `Microsoft.Extensions.Caching.Memory` package, which is included with ASP.NET Core.
   
   - For `IDistributedCache` with Redis:
     - Install the `Microsoft.Extensions.Caching.StackExchangeRedis` package to use Redis with `IDistributedCache`.

## Getting Started

### 1. **Clone the Repository**
   Clone the repository to your local machine using your preferred git client.

### 2. **Run Redis using Docker**
   If you haven't already set up Redis, run it locally using Docker. Make sure Redis is running on port `6379`.

### 3. **Configure Redis in `appsettings.json`**
   Ensure that your Redis configuration matches your setup. By default, Redis is expected to run on `localhost:6379`.

### 4. **Build and Run the Application**
   Use your development environment or the command line to build and run the application.

### 5. **Test the Application**
   There are two HTTP GET endpoints available:

   - **Retrieve data from `IMemoryCache`:**
     - Endpoint: `/api/Cache/GetInMemoryCacheData`
     - This endpoint returns data cached in memory (server-side).

   - **Retrieve data from `IDistributedCache` (Redis):**
     - Endpoint: `/api/Cache/GetDistributedCacheData`
     - This endpoint returns data from the Redis-based distributed cache.

## Example `appsettings.json` Configuration for Redis

Make sure your `appsettings.json` file has Redis configured correctly:

## How Caching Works

### `IMemoryCache`
- This is an in-memory caching implementation. Data is cached in the memory of the running application and is available as long as the application is running.

### `IDistributedCache` (using Redis)
- `IDistributedCache` is a distributed caching solution where cache data can be shared across multiple servers. In this project, Redis is used as the caching store. Redis ensures that the cache data is persisted outside of the application’s memory, making it suitable for distributed applications.

## Additional Configuration
- **Sliding Expiration** and **Absolute Expiration** can be configured for both `IMemoryCache` and `IDistributedCache` as demonstrated in the code.
- You can configure expiration policies and customize cache behavior according to your needs.

## Dependencies
- **Microsoft.Extensions.Caching.Memory**: For `IMemoryCache`, included in ASP.NET Core.
- **Microsoft.Extensions.Caching.StackExchangeRedis**: For `IDistributedCache` with Redis.
