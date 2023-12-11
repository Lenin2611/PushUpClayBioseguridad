using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class ContratoDto : BaseDto
{
    public DateOnly? FechaContrato { get; set; }

    public DateOnly? FechaFin { get; set; }

    public int? IdClienteFk { get; set; }

    public int? IdEstadoFk { get; set; }

    public int? IdEmpleadoFk { get; set; }
}
