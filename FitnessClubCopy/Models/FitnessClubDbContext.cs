using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessClubCopy.Models
{
    public class FitnessClubDbContext : IdentityDbContext<ApplicationUser>
    {
        public FitnessClubDbContext(DbContextOptions<FitnessClubDbContext> options) : base(options)
        {
        }

        public DbSet<FeedbackForm> FeedbackForm { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}