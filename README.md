# azure-redis-cache
Example of using Azure Redis Cache with a local C# console application

# Database
The application uses an in-memory store, so no extra database setup needed.

# Setup
You need an Azure subscription to run this.

* Create an Azure Redis Cache in your Azure portal, and copy the 'Stackexchange.Redis' connection string to an environment variable on your machine.
* Give it the name "REDIS_CACHE" (see source code).
* Start your application locally from within Visual Studio
* Press enter to navigate through the steps

You get notified if you have cache hit, or he is writing to cache.

# Metrics
Azure can give you nice statistics on cache hits and misses.
See screenshot:


