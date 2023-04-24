using System;
using System.Collections.Generic;

namespace prueba_tecnica_Atlantic.Models;

public partial class Categorium
{
    public int Codcat { get; set; }

    public string? Nomcat { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
