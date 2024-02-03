using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.Utils;
using BaseContext = Infrastructure.Context.BaseContext;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DockerManager as a singleton
builder.Services.AddSingleton<DockerManager>();


// -- Add configuration for PostgreSQL
var configuration = builder.Configuration;
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

// -- use jwt bearer authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/350481044738";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/350481044738",
            ValidateAudience = true,
            ValidAudience = "https://securetoken.google.com/350481044738",
            ValidateLifetime = true
        };
    });

// -- fonte: https://balta.io/blog/aspnetcore-3-1-autenticando-sua-api-com-google-via-firebase



var app = builder.Build();
var hostApplicationLifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
hostApplicationLifetime.ApplicationStopping.Register(() =>
{
    // This code will be executed when the application is stopping
    Console.WriteLine("Application is stopping. Perform cleanup here.");

    // Stop your Docker container or perform any necessary cleanup tasks
    StopDatabaseContainerAsync(app);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await StartDatabaseContainerAsync(app); // -- start database for development
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// -- Method to start Docker container
async Task StartDatabaseContainerAsync(WebApplication app)
{
    try
    {
        // Resolve DockerManager from the service provider
        var dockerManager = app.Services.GetRequiredService<DockerManager>();

        // Check if the container is already running
        if (!await dockerManager.IsDatabaseContainerRunning())
        {
            // If not running, start the container
            await dockerManager.StartDatabase();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error starting Docker container: {ex.Message}");
    }
}

// -- Method to stop Docker container
void StopDatabaseContainerAsync(WebApplication app)
{
    try
    {
        Console.WriteLine("Stopping Docker container...");
        // Resolve DockerManager from the service provider
        var dockerManager = app.Services.GetRequiredService<DockerManager>();
        dockerManager.StopDatabase();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error stopping Docker container: {ex.Message}");
    }
}
