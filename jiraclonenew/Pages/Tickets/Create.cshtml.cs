using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jiraclonenew.Data;
using jiraclonenew.Models;

namespace jiraclonenew.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = new Ticket();

        public SelectList ProjectOptions { get; set; } = null!;

        public async Task OnGetAsync()
        {
            ProjectOptions = new SelectList(await _context.Projects.ToListAsync(), "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ProjectOptions = new SelectList(await _context.Projects.ToListAsync(), "Id", "Name");
                return Page();
            }

            _context.Tickets.Add(Ticket);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
