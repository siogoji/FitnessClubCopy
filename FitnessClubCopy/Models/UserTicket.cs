using System.ComponentModel.DataAnnotations;

namespace FitnessClubCopy.Models
{
    public class UserTicket
    {
        [Key]
        public int UserTicketId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
