using Microsoft.AspNetCore.Mvc;

namespace Multired.AplicacionWeb.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult NuevaVenta()
        {
            return View();
        }
        public IActionResult Historialenta()
        {
            return View();
        }
    }
}
