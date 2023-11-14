using Microsoft.AspNetCore.Identity;

namespace FitnessClubCopy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        // Зв'язок багато до багатьох
        public ICollection<UserTicket> UserTickets { get; set; }
    }
}
