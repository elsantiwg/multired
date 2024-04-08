using System;
using System.Collections.Generic;

namespace Multired.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public string? NumeroVenta { get; set; }

    public int? IdTipoDocumentoVenta { get; set; }

    public int? IdUsuario { get; set; }

    public string? DocumentoCliente { get; set; }

    public string? NombreCliente { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? ImpuestoTotal { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual TipoDocumentoVentum? IdTipoDocumentoVentaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
