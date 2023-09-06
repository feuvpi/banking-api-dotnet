using banking_dotnet_api.Models;
using Microsoft.EntityFrameworkCore;

namespace banking_dotnet_api.Models
{
    public class AppDbContext : DbContext
    {

        //protected readonly IConfiguration Configuration;

        //public AppDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        //    //base.OnConfiguring(options);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}



