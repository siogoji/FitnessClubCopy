using System.ComponentModel.DataAnnotations;

namespace FitnessClubCopy.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string Type { get; set; }
        public string Period { get; set; }
        public int Price { get; set; }
        public byte[]? Photo { get; set; }
        public string? Description { get; set; }

        // Зв'язок багато до багатьох
        public ICollection<UserTicket>? UserTickets { get; set; }
    }
}
