using Microsoft.AspNetCore.Mvc;

namespace Multired.AplicacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
