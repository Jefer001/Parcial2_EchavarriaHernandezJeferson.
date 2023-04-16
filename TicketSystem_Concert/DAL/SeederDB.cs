using TicketSystem_Concert.DAL.Entities;

namespace TicketSystem_Concert.DAL
{
	public class SeederDB
	{
		#region Builder
		private readonly DataBaseContext _context;

		public SeederDB(DataBaseContext context)
		{
			_context = context;
		}
		#endregion

		#region Public methods
		public async Task SeedAsync()
		{
			await _context.Database.EnsureCreatedAsync();

			await PopulateTicketsAsync();

			await _context.SaveChangesAsync();
		}
		#endregion

		#region Private methods
		private async Task PopulateTicketsAsync()
		{
			if (!_context.Tickets.Any())
			{
				for (int x = 0; x < 50000; x++)
				{
					_context.Tickets.Add(new Ticket { Id = $"ConBicho{x}", UseData = null, IsUsed = false, EntranceGate = null });
				}
			}
		}
		#endregion
	}
}
