using FitnessClubCopy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            // Link the ticket to the current user
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _context.Users.Find(userId);

            if (user != null)
            {
                // Створення об'єкта UserTicket та додавання його до контексту
                var userTicket = new UserTicket { UserId = userId, TicketId = ticket.TicketId };
                _context.UserTickets.Add(userTicket);

                // Save changes to the database
                _context.SaveChanges();
            }

            return RedirectToAction("BuyConfirmation", new { id = ticket.TicketId });
        }

        [HttpGet]
        public IActionResult BuyConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        public IActionResult UserTickets()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Використовуйте LINQ для отримання квитків, пов'язаних з поточним користувачем
            var userTickets = _context.UserTickets
                .Where(ut => ut.UserId == userId)
                .Select(ut => ut.Ticket)
                .ToList();

            return View(userTickets);
        }


    }
}
