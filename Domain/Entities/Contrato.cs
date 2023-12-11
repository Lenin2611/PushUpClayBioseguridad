using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contrato : BaseEntity
{


    public DateOnly? FechaContrato { get; set; }

    public DateOnly? FechaFin { get; set; }

    public int? IdClienteFk { get; set; }

    public int? IdEstadoFk { get; set; }

    public int? IdEmpleadoFk { get; set; }

    public virtual Cliente IdClienteFkNavigation { get; set; }

    public virtual Empleado IdEmpleadoFkNavigation { get; set; }

    public virtual Estado IdEstadoFkNavigation { get; set; }

    public virtual ICollection<Programacion> Programaciones { get; set; } = new List<Programacion>();
}
