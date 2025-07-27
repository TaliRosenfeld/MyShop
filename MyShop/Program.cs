using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Entities;
using NLog.Web;
using MyShop;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Caching.StackExchangeRedis;

var builder = WebApplication.CreateBuilder(args);
string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
string connectionString;

builder.Services.AddDbContext<_326774742WebApiContext>(options =>
    options.UseSqlServer(
        "Server=SRV2\\PUPILS;Database=326774742_web_api;Trusted_Connection=True;TrustServerCertificate=True",
        b => b.MigrationsAssembly("Entities")
    )
);
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
//user
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//product
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//category
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//order
builder.Services.AddScoped<IOrderServise, OrderServise>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//rating
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();

//builder.Services.AddDbContext<_326774742WebApiContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddDbContext<_326774742WebApiContext>(option => option.UseSqlServer("Server=SRV2\\PUPILS;Database=326774742_web_api;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseNLog();
builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});
var app = builder.Build();
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("hello world");
//});

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
// Middleware to add CSP headers
app.Use(async (context, next) =>
{
    string nonceValue = GenerateNonce(); // Implement this method to generate a secure nonce
    context.Response.Headers.Add("Content-Security-Policy", 
        $"default-src 'self'; connect-src 'self' wss://localhost:44383; style-src 'self'; script-src 'self' 'nonce-{nonceValue}';");
    await next();
});
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRatingMiddleware();
app.UseErrorHandlingMiddleware();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();

string GenerateNonce()
{
    return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
}

