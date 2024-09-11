using Microsoft.EntityFrameworkCore;
using WenawoMessenger.Server.UserService.DBService.Models;

namespace WenawoMessenger.Server.UserService.DBService
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<DBUser> Users { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DBUser>();
        }
    }
}
