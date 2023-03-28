using System;
using System.Collections.Generic;

namespace Nomina.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? SueldoMaximo { get; set; }

    public int? NumeroEmpleados { get; set; }

    public virtual ICollection<Empleado> Empleado { get; } = new List<Empleado>();
}
