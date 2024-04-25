using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Multired.DAL.Interfaces;
using Multired.DAL.Implementacion;
using Multired.BLL.Interfaces;
using Multired.BLL.Implementacion;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {

        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration) {

            services.AddDbContext<DBVENTAContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddScoped<ICorreoService, CorreoService>();
            services.AddScoped<IFireBaseService, FireBaseService>();

            services.AddScoped<IUtilidadesService, UtilidadesService>();
            services.AddScoped<IRolService, RolService>();

            services.AddScoped<IUsuarioService, Usuarioservice>();
            services.AddScoped<INegocioService, NegocioService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProductoService, ProductoService>();

            services.AddScoped<ITipoDocumentoVentaService, TipoDocumentoVentaService>();
            services.AddScoped<IVentaService, VentaService>();

        }
    }
}
