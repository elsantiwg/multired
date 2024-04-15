using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace Multired.DAL.Interfaces
{
    public interface IGerenericRepository<TEntity> where TEntity : class
    {
        //metodos 
        Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filtro);

        Task<TEntity> Crear(TEntity entidad);
        Task<bool> Editar(TEntity entidad);
        Task<bool> eliminar(TEntity entidad);
        Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro = null);
    }
}
