using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jiraclonenew.Data;
using jiraclonenew.Models;

namespace jiraclonenew.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Project Project { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Project = await _context.Projects
                .Include(p => p.Lead)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (Project == null) return NotFound();
            return Page();
        }
    }
}
