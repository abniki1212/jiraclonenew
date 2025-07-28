using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jiraclonenew.Data;
using jiraclonenew.Models;

namespace jiraclonenew.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int ProjectCount { get; set; }
        public int TicketCount { get; set; }
        public Dictionary<TicketStatus, int> StatusCounts { get; set; } = new();
        public IList<Project> Projects { get; set; } = new List<Project>();

        public async Task OnGetAsync()
        {
            Projects = await _context.Projects
                .Include(p => p.Tickets)
                .AsNoTracking()
                .ToListAsync();

            ProjectCount = Projects.Count;
            TicketCount = Projects.Sum(p => p.Tickets.Count);

            foreach (TicketStatus status in Enum.GetValues(typeof(TicketStatus)))
            {
                StatusCounts[status] = Projects.Sum(p => p.Tickets.Count(t => t.Status == status));
            }
        }

        public IEnumerable<Ticket> TicketsForStatus(Project project, TicketStatus status)
        {
            return project.Tickets.Where(t => t.Status == status).OrderBy(t => t.Priority);
        }
    }
}
