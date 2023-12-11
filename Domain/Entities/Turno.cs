using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Turno : BaseEntity
{


    public string Nombre { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFinal { get; set; }

    public virtual ICollection<Programacion> Programaciones { get; set; } = new List<Programacion>();
}
