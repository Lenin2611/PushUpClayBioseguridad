using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly SeguridadContext _context;

        public EmpleadoRepository(SeguridadContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Empleado> GetEmpleados()
        {
            return _context.Empleados.AsQueryable();
        }

        public async Task<List<Empleado>> GetEmpleadosVigilantes()
        {
            return await (from empleado in _context.Empleados
                                    join puesto in _context.Puestos on empleado.IdPuestoFk equals puesto.Id
                                    where puesto.Nombre == "Vigilante"
                                    select empleado
                                ).ToListAsync();
        }

        public async Task<List<object>> GetContactoEmpleadosVigilantes()
        {
            return await (from empleado in _context.Empleados
                                    join puesto in _context.Puestos on empleado.IdPuestoFk equals puesto.Id
                                    join descripcion in _context.Descripcionpersonas on empleado.IdDescripcionPersonaFk equals descripcion.Id
                                    join contacto in _context.Contactos on descripcion.IdContactoFk equals contacto.Id
                                    join tipocontacto in _context.TipoContactos on contacto.IdTipoContactoFk equals tipocontacto.Id
                                    where puesto.Nombre == "Vigilante" && tipocontacto.Descripcion == "Telefono"
                                    select new
                                    {
                                        Nombre = empleado.Nombre,
                                        Telefono = contacto.Descripcion
                                    }
                                ).ToListAsync<object>();
        }

        public async Task<List<Empleado>> GetEmpleadosGironPiedecuesta()
        {
            return await (from empleado in _context.Empleados
                                    join descripcion in _context.Descripcionpersonas on empleado.IdDescripcionPersonaFk equals descripcion.Id
                                    join direccion in _context.Direcciones on descripcion.IdDireccionFk equals direccion.Id
                                    join ciudad in _context.Ciudades on direccion.IdCiudadFk equals ciudad.Id
                                    where ciudad.Nombre == "Giron" || ciudad.Nombre == "Piedecuesta"
                                    select empleado
                                ).ToListAsync();
        }
    }
}