using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jiraclonenew.Data;
using jiraclonenew.Models;

namespace jiraclonenew.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Project> Projects { get; set; } = new List<Project>();

        public async Task OnGetAsync()
        {
            Projects = await _context.Projects
                .Include(p => p.Lead)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
