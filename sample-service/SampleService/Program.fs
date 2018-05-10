namespace SampleService

module Program =
    open System
    open System.Net
    open Microsoft.AspNetCore.Builder
    open Microsoft.AspNetCore.Hosting
    open Giraffe

    let unhandledError _ _ =
        clearResponse
        >=> setStatusCode (int HttpStatusCode.InternalServerError)
        >=> text "An unhandled exception has occurred while executing the request."

    let notFound =
        setStatusCode (int HttpStatusCode.NotFound)
        >=> fun next ctx ->
            let message = sprintf "route %s is not found" (string ctx.Request.Path)
            text message next ctx

    let sayHello =
        Configuration.root.GetSection("helloMessage").Value
        |> text

    let composeApp =
        choose [
            GET >=> route Api.Hello >=> sayHello
            notFound
        ]

    type Startup () =
        member __.Configure (app: IApplicationBuilder) =
            app
                .UseGiraffeErrorHandler(unhandledError)
                .UseGiraffe (composeApp)


    [<EntryPoint>]
    let main _ =
        WebHostBuilder()
            .UseKestrel()
            .UseConfiguration(Configuration.root)
            .UseStartup<Startup>()
            .Build()
            .Run()

        0