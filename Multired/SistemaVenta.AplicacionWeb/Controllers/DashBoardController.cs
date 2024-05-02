using Microsoft.AspNetCore.Mvc;

namespace Multired.AplicacionWeb.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
