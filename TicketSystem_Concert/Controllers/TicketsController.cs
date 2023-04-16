using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystem_Concert.DAL;
using TicketSystem_Concert.DAL.Entities;

namespace TicketSystem_Concert.Controllers
{
	public class TicketsController : Controller
	{
		private readonly DataBaseContext _context;

		public TicketsController(DataBaseContext context)
		{
			_context = context;
		}

		// GET: Tickets
		public async Task<IActionResult> Index()
		{
			return _context.Tickets != null ?
						View(await _context.Tickets.ToListAsync()) :
						Problem("Entity set 'DataBaseContext.Tickets'  is null.");
		}

		// GET: Tickets/Details/5
		public async Task<IActionResult> Details(string? id)
		{
			if (id == null || _context.Tickets == null) return NotFound();

			var ticket = await _context.Tickets
				.FirstOrDefaultAsync(t => t.Id == id);

			if (ticket == null) return NotFound();

			return View(ticket);
		}

		// GET: Tickets/Edit/5
		public async Task<IActionResult> Edit(string? id)
		{
			if (id == null || _context.Tickets == null) return NotFound();

			var ticket = await _context.Tickets.FindAsync(id);

			if (ticket == null) return NotFound();

			if (id == ticket.Id && ticket.IsUsed == true)
			{
				_ = Details(id);
			}

			return View(ticket);
		}

		// POST: Tickets/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, Ticket ticket)
		{
			if (id != ticket.Id) return NotFound();

			if (ModelState.IsValid)
			{
				try
				{
					ticket.UseData = DateTime.Now;
					//ticket.IsUsed = true;
					_context.Update(ticket);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
						ModelState.AddModelError(string.Empty, "Ya existe la boleta..");
					else
						ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
			return View(ticket);
		}
	}
}
