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
		public async Task<IActionResult> Details(string id)
		{
			if (id == null || _context.Tickets == null)
			{
				return NotFound();
			}

			var ticket = await _context.Tickets
				.FirstOrDefaultAsync(m => m.Id == id);
			if (ticket == null)
			{
				return NotFound();
			}

			return View(ticket);
		}

		// GET: Tickets/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Tickets/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Ticket ticket)
		{
			if (ModelState.IsValid)
			{
				try
				{
					ticket.UseData = DateTime.Now;
					_context.Add(ticket);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));

				}
				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
						ModelState.AddModelError(string.Empty, "Ya existe la boleta.");
					else
						ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
				}
				catch (Exception exception)
				{
					ModelState.AddModelError(string.Empty, exception.Message);
				}
			}
			return View(ticket);
		}

		// GET: Tickets/Edit/5
		public async Task<IActionResult> Edit(string? id)
		{
			if (id == null || _context.Tickets == null) return NotFound();

			var ticket = await _context.Tickets.FindAsync(id);

			if (ticket == null) return NotFound();

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
				catch (Exception exception)
				{
					ModelState.AddModelError(string.Empty, exception.Message);
				}
			}
			return View(ticket);
		}

		// GET: Tickets/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _context.Tickets == null)
			{
				return NotFound();
			}

			var ticket = await _context.Tickets
				.FirstOrDefaultAsync(m => m.Id == id);
			if (ticket == null)
			{
				return NotFound();
			}

			return View(ticket);
		}

		// POST: Tickets/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_context.Tickets == null) return Problem("Entity set 'DataBaseContext.Tickets'  is null.");

			var ticket = await _context.Tickets.FindAsync(id);
			if (ticket != null)
			{
				_context.Tickets.Remove(ticket);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
