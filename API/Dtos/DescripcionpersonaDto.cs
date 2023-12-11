using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class DescripcionpersonaDto : BaseDto
{
    public int? IdPersona { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public int? IdDireccionFk { get; set; }
}
