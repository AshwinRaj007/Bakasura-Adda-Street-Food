using BakasuraAddaFoodStreet.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<FoodStreetDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"))
);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowCors",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var app = builder.Build();

// Middleware order is important
app.UseHttpsRedirection();

app.UseCors("allowCors");      // ✅ Must come before controllers

app.UseAuthorization();

app.MapControllers();

app.Run();
