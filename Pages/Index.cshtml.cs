using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WsfedTestSP.Pages;

[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {
        var userClaims = new Dictionary<string, string>();
        foreach (var claim in User.Claims)
        {
            userClaims[claim.Type] = claim.Value;
        }
        ViewData["userClaims"] = userClaims;
    }
}
