using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Cliente : BaseEntity
{

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int? IdDescripcionPersonaFk { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual Descripcionpersona IdDescripcionPersonaFkNavigation { get; set; }
}
