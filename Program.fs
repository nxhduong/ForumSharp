namespace ForumSharp

open System
open System.IO
open System.Data.SQLite
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open ForumSharp.Views

module App =

    // ---------------------------------
    // Models
    // ---------------------------------

    type Message =
        {
            Text : string
        }

    // ---------------------------------
    // Routing
    // ---------------------------------

    let webApp =
        choose [
            GET >=>
                choose [
                    route "/" >=> Home.handler ""
                    routef "/a/%s" Account.handler
                    routef "/f/%s" Forum.handler
                    routef "/t/%s" Thread.handler
                ]
            POST >=>
                choose [
                    //
                ]
            setStatusCode 404 >=> text "Not Found" 
        ]

    // ---------------------------------
    // Error handling
    // ---------------------------------

    let errorHandler (ex : Exception) (logger : ILogger) =
        logger.LogError(ex, "An unhandled exception has occurred while executing the request.")
        clearResponse >=> setStatusCode 500 >=> text ex.Message

    // ---------------------------------
    // Config and Main
    // ---------------------------------

    let configureCors (builder : CorsPolicyBuilder) =
        builder
            .WithOrigins(
                "http://localhost:5000",
                "https://localhost:5001"
                )
            .AllowAnyMethod()
            .AllowAnyHeader()
            |> ignore

    let configureApp (app : IApplicationBuilder) =
        let env = app.ApplicationServices.GetService<IWebHostEnvironment>()
        (match env.IsDevelopment() with
        | true  -> app.UseDeveloperExceptionPage()
        | false -> 
            app
                .UseGiraffeErrorHandler(errorHandler)
                .UseHttpsRedirection()
        )
            .UseCors(configureCors)
            .UseStaticFiles()
            .UseGiraffe(webApp)

    let configureServices (services : IServiceCollection) =
        services.AddCors()    |> ignore
        services.AddGiraffe() |> ignore

    let configureLogging (builder : ILoggingBuilder) =
        builder
            .AddConsole()
            .AddDebug() |> ignore

    [<EntryPoint>]
    let main args =
        let contentRoot = Directory.GetCurrentDirectory()
        let webRoot     = Path.Combine(contentRoot, "WebRoot")

        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                fun webHostBuilder ->
                    webHostBuilder
                        .UseContentRoot(contentRoot)
                        .UseWebRoot(webRoot)
                        .Configure(Action<IApplicationBuilder> configureApp)
                        .ConfigureServices(configureServices)
                        .ConfigureLogging(configureLogging)
                        |> ignore)
            .Build()
            .Run()
        0