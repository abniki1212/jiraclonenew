using jiraclonenew.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace jiraclonenew.Pages.Admin.Users;

public class IndexModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IndexModel(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public class UserRow
    {
        public ApplicationUser User { get; set; } = new();
        public IList<string> Roles { get; set; } = new List<string>();
    }

    public IList<UserRow> Users { get; set; } = new List<UserRow>();

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public int Page { get; set; } = 1;

    public int TotalPages { get; set; }

    private const int PageSize = 10;

    public async Task OnGetAsync()
    {
        var query = _userManager.Users.AsQueryable();
        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(u => (u.UserName != null && u.UserName.Contains(Search)) ||
                                     (u.Email != null && u.Email.Contains(Search)));
        }

        var count = await query.CountAsync();
        TotalPages = (int)Math.Ceiling(count / (double)PageSize);
        var users = await query
            .OrderBy(u => u.UserName)
            .Skip((Page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        foreach (var u in users)
        {
            Users.Add(new UserRow
            {
                User = u,
                Roles = (await _userManager.GetRolesAsync(u)).ToList()
            });
        }
    }
}
