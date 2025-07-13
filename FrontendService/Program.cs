using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.StackExchangeRedis;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"builder.Environment.ContentRootPath = {builder.Environment.ContentRootPath}");

// Add services to the container.

var redisUri = builder.Configuration["DataProtection:RedisConnection"];
var redisKeyName = builder.Configuration["DataProtection:RedisKeyName"];
var appName = builder.Configuration["DataProtection:AppName"];

if (!string.IsNullOrEmpty(redisUri))
{
    var redisConnection = ConnectionMultiplexer.Connect(redisUri);

    if (string.IsNullOrEmpty(appName))
        appName = "test-app";
    
    builder.Services.AddDataProtection()
        .PersistKeysToStackExchangeRedis(redisConnection, $"{redisKeyName}-{appName}")
        .SetApplicationName(appName);
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register HttpClient for general use
builder.Services.AddHttpClient();

//Declare healthcheck service
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Map HealthCheck 
app.MapHealthChecks("/");

app.UseAuthorization();

app.MapControllers();

app.Run();
