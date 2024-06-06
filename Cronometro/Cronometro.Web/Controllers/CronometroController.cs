using Microsoft.AspNetCore.Mvc;

namespace Cronometro.Web.Controllers
{
    public class CronometroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
