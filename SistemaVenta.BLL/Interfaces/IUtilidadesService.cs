using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multired.BLL.Interfaces
{
    public interface IUtilidadesService
    {

        string GenerarClave();

        string ConvertirSha512(string texto);
    }
}
