using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_gym.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();          // este borra la sesión
            return RedirectToPage("/Login");      // y este vuelve al inicio de sesión
        }
    }
}