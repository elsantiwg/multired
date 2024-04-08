using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Multired.Models;
using Multired.Servicios.Contrato;

namespace Multired.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbventaContext _dbContext;

        public UsuarioService(DbventaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> GetUsuario(string Correo, string Clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u =>u.Correo == Correo && u.Clave == Clave)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
