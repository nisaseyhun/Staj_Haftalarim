using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SpaMerkeziSablon.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
