MVC Opinionated Template
===

This is opinionated ASP.NET MVC Core Template. It is currently targeting ASP.NET Core 2.1.

Notes:
* Uses .NET Core default Dependency Injection
* Uses a Base Controller to provide Logger and Configuration properties
* Uses Serilog for application logging ( https://serilog.net/ )
* Uses Serilog Middleware Example for Smart Request Logging ( based on: https://github.com/datalust/serilog-middleware-example )
* Caching is supported at Service layer using MemoryCache (MVC adds a default memory cache implementation when configuring the Razor view engine)
* Don't need to call services.AddDistributedMemoryCache() in MVC, adds by memory cache default
* Installed Microsoft.Extensions.Caching.Memory version 2.1.0 instead of 2.1.1 because of compatibility issue with ASP.NET Core project

Todo:
* Update Address Service to use Disp
* Create example of TempData usage