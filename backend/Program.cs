// Weston Watson, Section 3

using Microsoft.EntityFrameworkCore;
using BowlingAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add database context
builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingConnection")));

// Enable CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();
