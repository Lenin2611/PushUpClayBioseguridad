# Clay Security

1. Listar todos los empleados de la empresa de seguridad

```c#
public async Task<IEnumerable<Empleado>> GetEmpleados()
{
    return await _context.Empleados
                .ToListAsync();
}

[HttpGet("empleados")] // 2611
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EmpleadoNombreDto>>> GetEmpleados()
{
    var results = await _unitOfWork.Empleados.GetEmpleados();
    return _mapper.Map<List<EmpleadoNombreDto>>(results);
}
```

http://localhost:5026/api/Empleado/empleados

2. Listar todos los empleados que son vigilantes

```c#
public async Task<List<Empleado>> GetEmpleadosVigilantes()
{
    return await (from empleado in _context.Empleados
                            join puesto in _context.Puestos on empleado.IdPuestoFk equals puesto.Id
                            where puesto.Nombre == "Vigilante"
                            select empleado
                        ).ToListAsync();
}

[HttpGet("empleadosvigilantes")] // 2611
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EmpleadoNombreDto>>> GetEmpleadosVigilantes()
{
    var results = await _unitOfWork.Empleados.GetEmpleadosVigilantes();
    return _mapper.Map<List<EmpleadoNombreDto>>(results);
}
```

http://localhost:5026/api/Empleado/empleadosvigilantes

3. Listar los numeros de contacto de los empleados que sean vigilantes

```c#
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

[HttpGet("contactoempleadosvigilantes")] // 2611
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<object>>> GetContactoEmpleadosVigilantes()
{
    var results = await _unitOfWork.Empleados.GetContactoEmpleadosVigilantes();
    return results;
}
```

http://localhost:5026/api/Empleado/contactoempleadosvigilantes

4. Listar todos los clientes que vivan en la ciudad de Bucaramanga

```c#
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

[HttpGet("clientesbucaramanga")] // 2611
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ClienteNombreDto>>> GetClientesBucaramanga()
{
    var results = await _unitOfWork.Clientes.GetClientesBucaramanga();
    return _mapper.Map<List<ClienteNombreDto>>(results);
}
```

http://localhost:5026/api/Cliente/clientesbucaramanga

5. Listar todos los empleados que vivan en Giron y Piedecuesta

```c#
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

[HttpGet("empleadosgironpiedecuesta")] // 2611
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EmpleadoNombreDto>>> GetEmpleadosGironPiedecuesta()
{
    var results = await _unitOfWork.Empleados.GetEmpleadosGironPiedecuesta();
    return _mapper.Map<List<EmpleadoNombreDto>>(results);
}
```

http://localhost:5026/api/Empleado/empleadosgironpiedecuesta

6. Listar todos los clientes que tengan mas de 5 años de antigüedad

```c#
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

[HttpGet("clientes5años")] // 2611
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ClienteNombreDto>>> GetClientes5Años()
{
    var results = await _unitOfWork.Clientes.GetClientes5Años();
    return _mapper.Map<List<ClienteNombreDto>>(results);
}
```

http://localhost:5026/api/Cliente/clientes5anos

7. Listar todos los contratos cuyo estado es Activo. Se debe mostrar el numero de contrato, el nombre del cliente y el empleado que registró el contrato

```c#
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

[HttpGet("contratoactivo")] // 2611
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<object>>> GetContratoActivo()
{
    var results = await _unitOfWork.Contratos.GetContratoActivo();
    return results;
}
        
```

http://localhost:5026/api/Contrato/contratoactivo