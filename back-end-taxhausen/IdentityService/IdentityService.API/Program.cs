using IdentityService.API.Extension;
using Shared.Authorization.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.ConfigureSharedLoggerService(builder.Services);
builder.Services.ConfigureAuthorizationService(builder.Configuration);
builder.Services.ConfigureCryptographyServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();