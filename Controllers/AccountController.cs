using Microsoft.AspNetCore.Mvc;

namespace gaadi_ghoda_server.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
