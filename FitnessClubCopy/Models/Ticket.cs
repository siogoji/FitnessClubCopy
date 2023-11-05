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
    }
}
