using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class TipoContactoRepository : GenericRepository<TipoContacto>, ITipoContacto
    {
        public TipoContactoRepository(SeguridadContext context) : base(context)
        {
        }
    }
}