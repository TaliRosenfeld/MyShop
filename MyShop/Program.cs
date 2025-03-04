using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Entities;
using NLog.Web;
using MyShop;


var builder = WebApplication.CreateBuilder(args);
string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

string connectionString;

//if (environment == "Home")
//{
//    connectionString = builder.Configuration.GetConnectionString("HomeConnection");
//}
//else if (environment == "School")
//{
//    connectionString = builder.Configuration.GetConnectionString("SchoolConnection");
//}
//else
//{
//    throw new Exception("Unknown environment");
//}

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

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRatingMiddleware();
app.UseErrorHandlingMiddleware();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();

