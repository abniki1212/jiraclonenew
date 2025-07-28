using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jiraclonenew.Data;
using jiraclonenew.Models;

namespace jiraclonenew.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; } = new Project();

        public SelectList UserOptions { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Project = await _context.Projects.FindAsync(id);
            if (Project == null) return NotFound();

            UserOptions = new SelectList(await _context.Users.ToListAsync(), "Id", "Email");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                UserOptions = new SelectList(await _context.Users.ToListAsync(), "Id", "Email");
                return Page();
            }

            var projectInDb = await _context.Projects.FindAsync(Project.Id);
            if (projectInDb == null) return NotFound();

            projectInDb.Name = Project.Name;
            projectInDb.Key = Project.Key;
            projectInDb.Description = Project.Description;
            projectInDb.LeadId = Project.LeadId;
            projectInDb.Status = Project.Status;

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
