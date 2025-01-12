using Microsoft.EntityFrameworkCore;
using Proj_5.Models;

namespace Proj_5.Database
{
    public class DataService : DbContext
    {
        public DataService(DbContextOptions<DataService> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}
