using System;
using System.Collections.Generic;

namespace Nomina.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Sueldo { get; set; }

    public int IdCategoria { get; set; }

    public ulong? Activo { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
}
