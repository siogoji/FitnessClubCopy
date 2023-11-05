using FitnessClubCopy.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClubCopy.Controllers
{
    public class ContactController : Controller
    {

        private readonly FitnessClubDbContext _context;

        public ContactController(FitnessClubDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProcessFormIndex(FeedbackForm model)
        {
            if (ModelState.IsValid)
            {
                _context.FeedbackForm.Add(model);
                await _context.SaveChangesAsync();               
            }

            return RedirectToAction("Index", "Home");   
        }

        public async Task<IActionResult> ProcessFormContacts(FeedbackForm model)
        {
            if (ModelState.IsValid)
            {
                _context.FeedbackForm.Add(model);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Contacts", "Home");
        }
    }
}
