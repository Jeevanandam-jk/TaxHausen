using IdentityService.API.Extension;
using IdentityService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.Authorization.Extension;
using Shared.Comon.Constant;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.ConfigureSharedLoggerService(builder.Services);
builder.Services.ConfigureAuthorizationService(builder.Configuration);
builder.Services.ConfigureCryptographyServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString(Constants.DEFAULT_CONNECTION)));

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();