using System;
using System.Collections.Generic;

namespace prueba_tecnica_Atlantic.Models;

public partial class Producto
{
    public int Copro { get; set; }

    public string? Nompro { get; set; }

    public double? Precio { get; set; }

    public int Codcat { get; set; }

    public virtual Categorium CodcatNavigation { get; set; } = null!;
}
