using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using jiraclonenew.Models;

namespace jiraclonenew.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Sprint> Sprints => Set<Sprint>();
    }
}
