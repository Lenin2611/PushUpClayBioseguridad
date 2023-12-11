using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ICiudad Ciudades { get; } // 2611
        public ICliente Clientes { get; }
        public IContacto Contactos { get; }
        public IContrato Contratos { get; }
        public IDepartamento Departamentos { get; }
        public IDescripcionpersona Descripcionpersonas { get; }
        public IDireccion Direcciones { get; }
        public IEmpleado Empleados { get; }
        public IEstado Estados { get; }
        public IPais Paises { get; }
        public IProgramacion Programaciones { get; }
        public IPuesto Puestos { get; }
        public IRol Rols { get; }
        public ITipoContacto TipoContactos { get; }
        public ITurno Turnos { get; }
        public IUser Users { get; }

        Task<int> SaveAsync(); // 2611
    }
}