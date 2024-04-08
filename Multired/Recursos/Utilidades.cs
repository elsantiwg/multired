using System.Security.Cryptography;
using System.Text;

namespace Multired.Recursos
{
    public class Utilidades
    {

        public static string EncriptarClave(String Clave)
        {
            StringBuilder sb =new StringBuilder();

            using (SHA512 hash = SHA512Managed.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(Clave));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}
