module WorldDiscovery.Web

open System
open System.IO
open Microsoft.AspNetCore.Authentication
open Microsoft.AspNetCore.Authentication.JwtBearer
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Microsoft.IdentityModel.Tokens
open Microsoft.AspNetCore.Cors.Infrastructure
open Giraffe

let webApp =
    choose [
        GET >=>
            choose [
                route "/" >=> text "Hello world Yes"
                route "/dody" >=> text "sdfsdf"
            ]
        setStatusCode 404 >=> text "Not Found" ]

let configureCors (builder : CorsPolicyBuilder) =
    builder.WithOrigins("http://localhost:8080")
           .AllowAnyMethod()
           .AllowAnyHeader()
           |> ignore

let errorHandler (ex : Exception) (logger : ILogger) =
    logger.LogError(ex, "An unhandled exception has occurred while executing the request.")
    clearResponse >=> setStatusCode 500 >=> text ex.Message

let configureApp (app : IApplicationBuilder) =
    let env = app.ApplicationServices.GetService<IHostingEnvironment>()
    (match env.IsDevelopment() with
    | true  -> app.UseDeveloperExceptionPage()
    | false -> app.UseGiraffeErrorHandler errorHandler)
        .UseAuthentication()
        .UseHttpsRedirection()
        .UseCors(configureCors)
        .UseStaticFiles()
        .UseGiraffe(webApp)

let authenticationOptions (o : AuthenticationOptions) =
    o.DefaultAuthenticateScheme <- JwtBearerDefaults.AuthenticationScheme
    o.DefaultChallengeScheme <- JwtBearerDefaults.AuthenticationScheme

let jwtBearerOptions (cfg: JwtBearerOptions) =
    cfg.RequireHttpsMetadata <- false
    cfg.SaveToken <- true
    cfg.IncludeErrorDetails <- true
    cfg.TokenValidationParameters <- TokenValidationParameters()
    cfg.TokenValidationParameters.ValidateIssuerSigningKey <- true
    cfg.TokenValidationParameters.ValidateActor <- false
    cfg.TokenValidationParameters.ValidateIssuer <- false
    cfg.TokenValidationParameters.ValidateAudience <- false
    cfg.TokenValidationParameters.ValidateLifetime <- true

let configureServices (services : IServiceCollection) =
    services.AddCors()
        .AddGiraffe()
        .AddAuthentication(authenticationOptions)
        .AddJwtBearer(Action<JwtBearerOptions> jwtBearerOptions) |> ignore

let configureLogging (builder : ILoggingBuilder) =
    builder.AddFilter(fun l -> l.Equals LogLevel.Error)
           .AddConsole()
           .AddDebug() |> ignore

[<EntryPoint>]
let main _ =
    let contentRoot = Directory.GetCurrentDirectory()
    WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(contentRoot)
        .UseIISIntegration()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .ConfigureLogging(configureLogging)
        .Build()
        .Run()
    0