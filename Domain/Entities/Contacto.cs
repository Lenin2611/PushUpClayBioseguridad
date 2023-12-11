using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contacto : BaseEntity
    {
        public string Descripcion { get; set; }
        public int IdTipoContactoFk { get; set; }
        public TipoContacto TipoContacto { get; set; }
        public ICollection<Descripcionpersona> Descripcionpersonas { get; set; }
    }
}