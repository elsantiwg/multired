
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multired.BLL.Interfaces;
using Isopoh.Cryptography.Argon2;

namespace Multired.BLL.Implementacion
{
    public class UtilidadesService : IUtilidadesService
    {

        public string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);
            return clave;
        }

        public string ConvertirArgon2(string texto)
        {
            // Configura los parámetros de Argon2
            var config = new Argon2Config
            {
                Type = Argon2Type.DataIndependentAddressing,
                Version = Argon2Version.Nineteen,
                TimeCost = 2,
                MemoryCost = 65536,
                Lanes = 4,
                Password = Encoding.UTF8.GetBytes(texto),
                Salt = new byte[8] // Deberías generar una nueva sal para cada contraseña
            };

            // Crea y calcula el hash Argon2
            using (var argon2 = new Argon2(config))
            {
                var hash = argon2.Hash();
                return Convert.ToBase64String(hash.Buffer);
            }
        }
    }
}
