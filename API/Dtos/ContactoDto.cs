using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ContactoDto : BaseDto
    {
        public string Descripcion { get; set; }
        public int IdTipoContactoFk { get; set; }
    }
}