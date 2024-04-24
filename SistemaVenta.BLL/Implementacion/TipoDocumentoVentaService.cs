using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Multired.BLL.Interfaces;
using Multired.DAL.Interfaces;
using SistemaVenta.Entity;

namespace Multired.BLL.Implementacion
{
    public class TipoDocumentoVentaService : ITipoDocumentoVentaService
    {
        private readonly IGerenericRepository<TipoDocumentoVenta> _repositorio;

        public TipoDocumentoVentaService(IGerenericRepository<TipoDocumentoVenta> repositorio)
        {
         _repositorio = repositorio;
        }
        public async Task<List<TipoDocumentoVenta>> Lista()
        {
            IQueryable<TipoDocumentoVenta> query = await _repositorio.Consultar();
            return query.ToList();
        }
    }
}
