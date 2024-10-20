using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdFarmShop.Pages
{
    public class LoginGoogleModel : PageModel
    {
        public IActionResult OnGet()
        {
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Page("/LoginGoogleCallBack"),
            };
            return Challenge(authenticationProperties, "Google");
        }
    }
}
