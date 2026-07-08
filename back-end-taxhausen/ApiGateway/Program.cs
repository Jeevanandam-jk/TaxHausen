using ApiGateway.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSharedLoggerService(builder.Services);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();

app.Run();