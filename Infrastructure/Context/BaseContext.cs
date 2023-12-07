using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class BaseContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
