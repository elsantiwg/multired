using Microsoft.AspNetCore.Mvc;

using Multired.AplicacionWeb.Models.ViewModels;
using Multired.AplicacionWeb.Utilidades.Response;
using Multired.BLL.Interfaces;
using Multired.DAL.Interfaces;
using System.Diagnostics.Eventing.Reader;

namespace Multired.AplicacionWeb.Controllers
{
    public class DashBoardController : Controller
    {

        private readonly IDashBoardService _dashBoardServicio;

        public DashBoardController(IDashBoardService dashBoardServicio)
        {
            _dashBoardServicio = dashBoardServicio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerResumen()
        {

            GenericResponse<VMDashBoard> gResponse = new GenericResponse<VMDashBoard>();
            try
            {
                VMDashBoard vmDashBoard = new VMDashBoard();

                vmDashBoard.TotalVentas = await _dashBoardServicio.TotalVentasUltimaSemana();
                vmDashBoard.TotalIngresos = await _dashBoardServicio.TotalIngresosUltimaSemana();
                vmDashBoard.TotalProductos = await _dashBoardServicio.TotalProductos();
                vmDashBoard.TotalCategorias = await _dashBoardServicio.TotalCategorias();

                List<VMVentasSemana> listaVentaSemana = new List<VMVentasSemana>();
                List<VMProductosSemana> listaProductosSemana = new List<VMProductosSemana>();

                foreach(KeyValuePair<string,int> item in await _dashBoardServicio.VentasUltimaSemana())
                {
                    listaVentaSemana.Add(new VMVentasSemana()
                    {
                        Fecha = item.Key,
                        Total = item.Value,
                    });
                }

                foreach (KeyValuePair<string, int> item in await _dashBoardServicio.ProductosTopUltimaSemana())
                {
                    listaProductosSemana.Add(new VMProductosSemana()
                    {
                        Producto = item.Key,
                        Cantidad = item.Value,
                    });
                }

                vmDashBoard.VentasUltimaSemana = listaVentaSemana;
                vmDashBoard.ProductosTopUltimaSemana = listaProductosSemana;

                gResponse.Estado = true;
                gResponse.Objeto = vmDashBoard;
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, gResponse);
        }
    }
}
