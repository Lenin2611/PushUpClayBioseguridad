using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class ContratoRepository : GenericRepository<Contrato>, IContrato
    {
        private readonly SeguridadContext _context;

        public ContratoRepository(SeguridadContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<object>> GetContratoActivo()
        {
            return await (from contrato in _context.Contratos
                                    join empleado in _context.Empleados on contrato.IdEmpleadoFk equals empleado.Id
                                    join cliente in _context.Clientes on contrato.IdClienteFk equals cliente.Id
                                    join estado in _context.Estados on contrato.IdEstadoFk equals estado.Id
                                    where estado.Descripcion == "Activo"
                                    select new
                                    {
                                        IdContrato = contrato.Id,
                                        NombreCliente = cliente.Nombre,
                                        NombreEmpleado = empleado.Nombre
                                    }
                                ).ToListAsync<object>();
        }
    }
}