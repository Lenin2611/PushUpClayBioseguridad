using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SeguridadContext _context;

        private ICiudad _Ciudades; // 2611
        private ICliente _Clientes;
        private IContacto _Contactos;
        private IContrato _Contratos;
        private IDepartamento _Departamentos;
        private IDescripcionpersona _Descripcionpersonas;
        private IDireccion _Direcciones;
        private IEmpleado _Empleados;
        private IEstado _Estados;
        private IPais _Paises;
        private IProgramacion _Programaciones;
        private IPuesto _Puestos;
        private IRol _Rols;
        private ITipoContacto _TipoContactos;
        private ITurno _Turnos;
        private IUser _Users;

        public UnitOfWork(SeguridadContext context) // 2611
        {
            _context = context;
        }

        public ICiudad Ciudades // 2611
        {
            get
            {
                if (_Ciudades == null)
                {
                    _Ciudades = new CiudadRepository(_context);
                }
                return _Ciudades;
            }
        }
        public ICliente Clientes // 2611
        {
            get
            {
                if (_Clientes == null)
                {
                    _Clientes = new ClienteRepository(_context);
                }
                return _Clientes;
            }
        }
        public IContacto Contactos // 2611
        {
            get
            {
                if (_Contactos == null)
                {
                    _Contactos = new ContactoRepository(_context);
                }
                return _Contactos;
            }
        }
        public IContrato Contratos // 2611
        {
            get
            {
                if (_Contratos == null)
                {
                    _Contratos = new ContratoRepository(_context);
                }
                return _Contratos;
            }
        }
        public IDepartamento Departamentos // 2611
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(_context);
                }
                return _Departamentos;
            }
        }
        public IDescripcionpersona Descripcionpersonas // 2611
        {
            get
            {
                if (_Descripcionpersonas == null)
                {
                    _Descripcionpersonas = new DescripcionpersonaRepository(_context);
                }
                return _Descripcionpersonas;
            }
        }
        public IDireccion Direcciones // 2611
        {
            get
            {
                if (_Direcciones == null)
                {
                    _Direcciones = new DireccionRepository(_context);
                }
                return _Direcciones;
            }
        }
        public IEmpleado Empleados // 2611
        {
            get
            {
                if (_Empleados == null)
                {
                    _Empleados = new EmpleadoRepository(_context);
                }
                return _Empleados;
            }
        }
        public IEstado Estados // 2611
        {
            get
            {
                if (_Estados == null)
                {
                    _Estados = new EstadoRepository(_context);
                }
                return _Estados;
            }
        }
        public IPais Paises // 2611
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new PaisRepository(_context);
                }
                return _Paises;
            }
        }
        public IProgramacion Programaciones // 2611
        {
            get
            {
                if (_Programaciones == null)
                {
                    _Programaciones = new ProgramacionRepository(_context);
                }
                return _Programaciones;
            }
        }
        public IPuesto Puestos // 2611
        {
            get
            {
                if (_Puestos == null)
                {
                    _Puestos = new PuestoRepository(_context);
                }
                return _Puestos;
            }
        }
        public IRol Rols // 2611
        {
            get
            {
                if (_Rols == null)
                {
                    _Rols = new RolRepository(_context);
                }
                return _Rols;
            }
        }
        public ITipoContacto TipoContactos // 2611
        {
            get
            {
                if (_TipoContactos == null)
                {
                    _TipoContactos = new TipoContactoRepository(_context);
                }
                return _TipoContactos;
            }
        }
        public ITurno Turnos // 2611
        {
            get
            {
                if (_Turnos == null)
                {
                    _Turnos = new TurnoRepository(_context);
                }
                return _Turnos;
            }
        }
        public IUser Users // 2611
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(_context);
                }
                return _Users;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveAsync() // 2611
        {
            return _context.SaveChangesAsync();
        }
    }
}