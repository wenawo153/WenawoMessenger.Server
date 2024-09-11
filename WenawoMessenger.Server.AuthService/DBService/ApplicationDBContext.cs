using Microsoft.EntityFrameworkCore;
using WenawoMessenger.Server.AuthenticationService.DBService.Models;
using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.AuthenticationService.DBService
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<UserTokenDB> UserKeys { get; set; }

		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
			Database.EnsureCreatedAsync();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserTokenDB>();
		}
	}
}
