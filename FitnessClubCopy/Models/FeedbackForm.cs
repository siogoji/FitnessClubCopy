using System.ComponentModel.DataAnnotations;

namespace FitnessClubCopy.Models
{
    public class FeedbackForm
    {
        [Key]
        public int FeedbackId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? SubjectOfMessage { get; set; }
        public string? Message { get; set; }
    }
}
