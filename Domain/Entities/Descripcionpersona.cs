using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Descripcionpersona : BaseEntity
{


    public int? IdPersona { get; set; }

    public string Email { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public int? IdDireccionFk { get; set; }

    public int IdContactoFk { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Direccion IdDireccionFkNavigation { get; set; }

    public virtual Contacto Contacto { get; set; }
}
