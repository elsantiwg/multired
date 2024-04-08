using Microsoft.EntityFrameworkCore;
using Multired.Models;

namespace Multired.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string Correo, string Clave);

        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
