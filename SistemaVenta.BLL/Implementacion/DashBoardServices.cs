using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Multired.BLL.Interfaces;
using Multired.DAL.Interfaces;
using SistemaVenta.Entity;
using System.Globalization;

namespace Multired.BLL.Implementacion
{
    public class DashBoardServices : IDashBoardService
    {
        private readonly IVentaRepository _repositorioVenta;
        private readonly IGerenericRepository<DetalleVenta> _repositorioDetalleVenta;
        private readonly IGerenericRepository<Categoria> _repositorioCategoria;
        private readonly IGerenericRepository<Producto> _repositorioProducto;
        private DateTime FechaInicio = DateTime.Now;

        public DashBoardServices(IVentaRepository repositorioVenta, IGerenericRepository<DetalleVenta> repositorioDetalleVenta, IGerenericRepository<Categoria> repositorioCategoria, IGerenericRepository<Producto> repositorioProducto)
        {
            _repositorioVenta = repositorioVenta;
            _repositorioDetalleVenta = repositorioDetalleVenta;
            _repositorioCategoria = repositorioCategoria;
            _repositorioProducto = repositorioProducto;

            FechaInicio = FechaInicio.AddDays(-7);
        }

        public async Task<int> TotalVentasUltimaSemana()
        {
            try
            {
                IQueryable<Venta> query = await _repositorioVenta.Consultar(v => v.FechaRegistro.Value.Date >= FechaInicio.Date);
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> TotalIngresosUltimaSemana()
        {
            try
            {
                IQueryable<Venta> query = await _repositorioVenta.Consultar(v => v.FechaRegistro.Value.Date >= FechaInicio.Date);
                decimal resultado = query
                    .Select(v => v.Total)
                    .Sum(v => v.Value);

                return Convert.ToString(resultado, new CultureInfo("es-CO"));
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> TotalProductos()
        {
            try
            {
                IQueryable<Producto> query = await _repositorioProducto.Consultar();
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> TotalCategorias()
        {
            try
            {
                IQueryable<Categoria> query = await _repositorioCategoria.Consultar();
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<string, int>> VentasUltimaSemana()
        {
            try
            {
                IQueryable<Venta> query = await _repositorioVenta
                    .Consultar(v => v.FechaRegistro.Value.Date >= FechaInicio.Date);

                Dictionary<string,int> resultado = query
                    .GroupBy(v=>v.FechaRegistro.Value.Date).OrderByDescending(g=>g.Key)
                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);

                return resultado;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Dictionary<string, int>> ProductosTopUltimaSemana()
        {
            try
            {
                IQueryable<DetalleVenta> query = await _repositorioDetalleVenta.Consultar();

                Dictionary<string, int> resultado = query
                    .Include(v => v.IdVentaNavigation)
                    .Where(dv => dv.IdVentaNavigation.FechaRegistro.Value.Date >= FechaInicio.Date)
                    .GroupBy(dv => dv.DescripcionProducto).OrderByDescending(g => g.Count())
                    .Select(dv => new { Producto = dv.Key , total = dv.Count() }).Take(4)
                    .ToDictionary(keySelector: r => r.Producto, elementSelector: r => r.total);

                return resultado;
            }
            catch
            {
                throw;
            }
        }

    }
}
