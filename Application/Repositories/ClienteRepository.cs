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
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        private readonly SeguridadContext _context;

        public ClienteRepository(SeguridadContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetClientesBucaramanga()
        {
            return await (from cliente in _context.Clientes
                        join descripcion in _context.Descripcionpersonas on cliente.IdDescripcionPersonaFk equals descripcion.Id
                        join direccion in _context.Direcciones on descripcion.IdDireccionFk equals direccion.Id
                        join ciudad in _context.Ciudades on direccion.IdCiudadFk equals ciudad.Id
                        where ciudad.Nombre == "Bucaramanga"
                        select cliente
                                ).ToListAsync();
        }

        public async Task<List<Cliente>> GetClientes5Años()
        {
            var result = await _context.Clientes.FromSqlRaw
            (
                @"SELECT c.*
                FROM Cliente c
                JOIN Descripcionpersona d ON c.IdDescripcionPersonaFk = d.Id
                WHERE TIMESTAMPDIFF(YEAR, d.FechaRegistro, CURDATE()) > 5"
            ).ToListAsync();
            return result;
        }
    }
}