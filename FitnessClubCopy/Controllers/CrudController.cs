using FitnessClubCopy.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClubCopy.Controllers
{
    public class CrudController : Controller
    {
        private readonly FitnessClubDbContext _context;

        public CrudController(FitnessClubDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tickets()
        {
            var tickets = _context.Tickets.ToList();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TicketId,Type,Period,Price")] Ticket Ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Ticket);
                _context.SaveChanges();
                return RedirectToAction(nameof(Tickets));
            }
            return View(Ticket);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = _context.Tickets.Find(id);
            if (Ticket == null)
            {
                return NotFound();
            }

            return View(Ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TicketId,Type,Period,Price")] Ticket Ticket)
        {
            if (id != Ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(Ticket);
                _context.SaveChanges();
                return RedirectToAction(nameof(Tickets));
            }
            return View(Ticket);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = _context.Tickets.Find(id);
            if (Ticket == null)
            {
                return NotFound();
            }

            return View(Ticket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Ticket = _context.Tickets.Find(id);
            if (Ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(Ticket);
            _context.SaveChanges();

            return RedirectToAction(nameof(Tickets));
        }
    }
}
