using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Multired.AplicacionWeb.Models.ViewModels;
using Multired.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Multired.AplicacionWeb.Controllers
{
    [Authorize]
    public class ReporteController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IVentaService _ventaServicio;

        public ReporteController(IMapper mapper, IVentaService ventaServicio)
        {
            _mapper = mapper;
            _ventaServicio = ventaServicio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ReporteVenta(string fechaInicio, string fechaFin)
        {
            List<VMReporteVenta> vmLista = _mapper.Map<List<VMReporteVenta>>(await _ventaServicio.Reporte(fechaInicio, fechaFin));
            return StatusCode(StatusCodes.Status200OK, new { data = vmLista });
        }

    }
}
