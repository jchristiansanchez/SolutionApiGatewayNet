using Company.ApiGateway.WebApi.ModulesExtension.Authentication;
using Company.ApiGateway.WebApi.ModulesExtension.Authorization;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Cargar Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


builder.Services.AddAuthenticationModule(builder.Configuration);
builder.Services.AddAuthorizationModule(builder.Configuration);

// Ocelot services
builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Usar Ocelot
await app.UseOcelot();

app.Run();
