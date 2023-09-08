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


        // -- Manually configure the relationship of navigation properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Sender)        // -- A Transaction has one Sender (User)
                .WithMany(u => u.SentTransactions) // -- A User has many SentTransactions
                .HasForeignKey(t => t.SenderId);  // -- Foreign key in Transaction

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Receiver)      // -- A Transaction has one Receiver (User)
                .WithMany(u => u.ReceivedTransactions) // -- A User has many ReceivedTransactions
                .HasForeignKey(t => t.ReceiverId);    // -- Foreign key in Transaction
        }

    }
}



