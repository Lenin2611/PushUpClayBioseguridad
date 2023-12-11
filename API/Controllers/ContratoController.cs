using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContratoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContratoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContratoDto>>> Get()
        {
            var results = await _unitOfWork.Contratos.GetAllAsync();
            return _mapper.Map<List<ContratoDto>>(results);
        }

        [HttpGet("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContratoDto>> Get(int id)
        {
            var result = await _unitOfWork.Contratos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContratoDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContratoDto>> Post(ContratoDto resultDto)
        {
            var result = _mapper.Map<Contrato>(resultDto);
            if (resultDto.FechaContrato == DateOnly.MinValue) // 2611
            {
                resultDto.FechaContrato = DateOnly.FromDateTime(DateTime.Now);
                result.FechaContrato = DateOnly.FromDateTime(DateTime.Now);
            }
            if (resultDto.FechaFin == DateOnly.MinValue) // 2611
            {
                resultDto.FechaFin = DateOnly.FromDateTime(DateTime.Now);
                result.FechaFin = DateOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Contratos.Add(result);
            await _unitOfWork.SaveAsync();
            if (result == null)
            {
                return BadRequest();
            }
            resultDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContratoDto>> Put(int id, [FromBody] ContratoDto resultDto)
        {
            var exists = await _unitOfWork.Contratos.GetByIdAsync(id);
            if (exists == null)
            {
                return NotFound();
            }
            if (resultDto.Id == 0)
            {
                resultDto.Id = id;
            }
            if (resultDto.Id != id)
            {
                return BadRequest();
            }
            // Update the properties of the existing entity with values from resultDto
            _mapper.Map(resultDto, exists);
            if (resultDto.FechaContrato == DateOnly.MinValue)
            {
                exists.FechaContrato = DateOnly.FromDateTime(DateTime.Now);
            }
            if (resultDto.FechaFin == DateOnly.MinValue)
            {
                exists.FechaFin = DateOnly.FromDateTime(DateTime.Now);
            }
            // The context is already tracking result, so no need to attach it
            await _unitOfWork.SaveAsync();
            // Return the updated entity
            return _mapper.Map<ContratoDto>(exists);
        }

        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Contratos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Contratos.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("contratoactivo")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetContratoActivo()
        {
            var results = await _unitOfWork.Contratos.GetContratoActivo();
            return results;
        }
    }
}