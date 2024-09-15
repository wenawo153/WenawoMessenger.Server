using Microsoft.EntityFrameworkCore;
using WenawoMessenger.Server.ChatService.DBService.Models;

namespace WenawoMessenger.Server.ChatService.DBService
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<DBChat> Chats { get; set; }
		public DbSet<DBMessege> Messeges { get; set; }

		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<DBMessege>(option =>
			{
				option.Property(_ => _.SendedDateTime).HasColumnType("timestamp(6)");
			});
			modelBuilder.Entity<DBChat>(option =>
			{
				option.Property(_ => _.ChatCreatedDateTime).HasColumnType("timestamp(6)");
			});
		}
	}
}
