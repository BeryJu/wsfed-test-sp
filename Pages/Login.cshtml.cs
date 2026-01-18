using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.WsFederation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WsfedTestSP.Pages;

public class LoginModel : PageModel
{
    public IActionResult OnGet()
    {
        return Challenge(new AuthenticationProperties
        {
            RedirectUri = "/"
        }, WsFederationDefaults.AuthenticationScheme);
    }

    // Logout
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return SignOut(new AuthenticationProperties
        {
            RedirectUri = "/"
        }, WsFederationDefaults.AuthenticationScheme);
    }
}
