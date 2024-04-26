﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Multired.AplicacionWeb.Utilidades.ViewComponents
{
    public class MenuUsuarioViewComponent: ViewComponent
    {

        public async Task<IViewComponentResult> invokeAsync() { 
        
            ClaimsPrincipal claimUser = HttpContext.User;

            string nombreUsuario = "";
            string urlFotoUsuario = "";

            if (claimUser.Identity.IsAuthenticated) {
                nombreUsuario = claimUser.Claims
                    .Where(c => c.Type == ClaimTypes.Name),
                    .Select(c => c.Value).SingleOrDefault();

                urlFotoUsuario = ((ClaimsIdentity)claimUser.Identity).FindFirst("UrlFoto").Value;
            }

            ViewData["nombreUsuario"] = nombreUsuario;
            ViewData["urlFotoUsuario"] = urlFotoUsuario;

            return View();
        }
    }
}
