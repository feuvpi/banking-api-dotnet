using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppDbContext = banking_dotnet_api.Data.AppDbContext;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<banking_dotnet_apiContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("banking_dotnet_apiContext") ?? throw new InvalidOperationException("Connection string 'banking_dotnet_apiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Added configuration for PostgreSQL
var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
