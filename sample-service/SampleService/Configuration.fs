namespace SampleService

[<RequireQualifiedAccess>]
module Configuration =
    open System.IO
    open Microsoft.Extensions.Configuration

    let root =
        ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory ())
            .AddJsonFile("appsettings.json", optional=false, reloadOnChange=false)
            .AddJsonFile("appsettings.overrides.json", optional=true, reloadOnChange=false)
            .AddEnvironmentVariables()
            .Build ()
