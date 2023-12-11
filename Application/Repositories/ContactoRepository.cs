using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class ContactoRepository : GenericRepository<Contacto>, IContacto
    {
        public ContactoRepository(SeguridadContext context) : base(context)
        {
        }
    }
}