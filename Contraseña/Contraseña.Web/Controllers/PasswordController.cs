using Contraseña.Web.data;
using Contraseña.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contraseña.Web.Controllers
{
    public class PasswordController : Controller
    {
        // GET: Password/Generate
        public ActionResult Generate()
        {
            return View();
        }

        // POST: Password/Generate
        [HttpPost]
        public ActionResult Generate(int length)
        {
            var passwordGenerator = new PasswordGenerator { Length = length };
            passwordGenerator.GenerateRandomPassword();
            return PartialView("_GeneratedPasswordPartial", passwordGenerator);
        }
    }
}
