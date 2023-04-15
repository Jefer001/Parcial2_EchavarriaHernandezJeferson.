using TicketSystem_Concert.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem_Concert.DAL
{
	public class DataBaseContext : DbContext
	{
		#region Builder
		public DataBaseContext(DbContextOptions<DataBaseContext> option) : base(option)
		{
		}
		#endregion

		#region Properties
		public DbSet<Ticket> Tickets { get; set; }
		#endregion

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Ticket>().HasIndex(t => t.Id).IsUnique();
		}
	}
}
