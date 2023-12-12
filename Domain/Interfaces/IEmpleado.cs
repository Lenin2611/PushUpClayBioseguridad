using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmpleado : IGenericRepository<Empleado>
    {
        IQueryable<Empleado> GetEmpleados();
        Task<List<Empleado>> GetEmpleadosVigilantes();
        Task<List<object>> GetContactoEmpleadosVigilantes();
        Task<List<Empleado>> GetEmpleadosGironPiedecuesta();
    }
}