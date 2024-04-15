using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

using Multired.BLL.Interfaces;
using Multired.DAL.Interfaces;
using SistemaVenta.Entity;

namespace Multired.BLL.Implementacion
{
    public class CorreoService : ICorreoService
    {
        private readonly IGerenericRepository<Configuracion> _repositorio;

        //constructor
        public CorreoService(IGerenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;
        }

   
        public async Task<bool> EnviarCorreo(string CorreoDestino, string Asunto, string Mensaje)
        {
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("Servicio_Correo"));

                //para hacer el llamado de la propiedad y el valor de la configuracion en la base de datos
                Dictionary<String, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                var credenciales = new NetworkCredential(Config["correo"], Config["clave"]);

                //correo
                var correo = new MailMessage()
                {
                    From = new MailAddress(Config["correo"], Config["alias"]),
                    Subject = Asunto,
                    Body = Mensaje,
                    IsBodyHtml = true
                };

                correo.To.Add(new MailAddress(CorreoDestino));

                //servidor
                var clienteServidor = new SmtpClient()
                {
                    Host = Config["host"],
                    Port = int.Parse(Config["puerto"]),
                    //formato de envio
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };
                //enviar el correo que se configuro
                clienteServidor.Send(correo);
                return true;
            } catch { 
                return false;
            }
        }
    }
}
