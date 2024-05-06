using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Multired.BLL.Interfaces;
using System.Security.Claims;

namespace Multired.AplicacionWeb.Utilidades.CustomFilter
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {

        private string _controlador;
        private string _accion;
        private IMenuService _menuServicio;

        public ClaimRequirementFilter(string controlador,
            string accion,
            IMenuService menuServicio)
        {
            _controlador = controlador;
            _accion = accion;
            _menuServicio = menuServicio;
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {

            ClaimsPrincipal claimUser = context.HttpContext.User;

            string idUsuario = claimUser.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).SingleOrDefault();

            bool tiene_permiso = await _menuServicio.TienePermisoMenu(
                    int.Parse(idUsuario),
                    _controlador,
                    _accion
                    );

            if (tiene_permiso) {
                context.Result = new RedirectToActionResult("SinPermiso", "Home", null);
            }
        }
    }
}
