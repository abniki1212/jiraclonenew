using jiraclonenew.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jiraclonenew.Pages.Admin.Users;

public class EditModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public EditModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public class InputModel
    {
        public string Id { get; set; } = string.Empty;
        public string? Email { get; set; }
        public Dictionary<string, bool> Roles { get; set; } = new();
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        Input.Id = user.Id;
        Input.Email = user.Email;
        foreach (var role in _roleManager.Roles)
        {
            bool inRole = await _userManager.IsInRoleAsync(user, role.Name!);
            Input.Roles[role.Name!] = inRole;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.FindByIdAsync(Input.Id);
        if (user == null) return NotFound();

        var currentRoles = await _userManager.GetRolesAsync(user);
        foreach (var kvp in Input.Roles)
        {
            var roleName = kvp.Key;
            var shouldHaveRole = kvp.Value;
            bool hasRole = currentRoles.Contains(roleName);
            if (shouldHaveRole && !hasRole)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
            else if (!shouldHaveRole && hasRole)
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
        }

        return RedirectToPage("Index");
    }
}
