using Microsoft.AspNetCore.Mvc;

namespace Multired.AplicacionWeb.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
