using System;
using System.Collections.Generic;

namespace Multired.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
