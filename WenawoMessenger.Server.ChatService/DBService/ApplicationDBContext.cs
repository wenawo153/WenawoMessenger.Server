using Microsoft.EntityFrameworkCore;
using WenawoMessenger.Server.ChatService.ApplicationDBContext.Models;
using WenawoMessenger.Server.ChatService.DBService.Models;

namespace WenawoMessenger.Server.ChatService.DBService
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<DBChat> Chats { get; set; }
		public DbSet<DBMessege> Messeges { get; set; }

		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
			Database.EnsureCreatedAsync();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<DBMessege>();
			modelBuilder.Entity<DBChat>();
		}
	}
}
