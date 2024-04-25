using Microsoft.AspNetCore.Mvc;

namespace Multired.AplicacionWeb.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
