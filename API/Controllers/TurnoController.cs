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
    public class TurnoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TurnoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TurnoDto>>> Get()
        {
            var results = await _unitOfWork.Turnos.GetAllAsync();
            return _mapper.Map<List<TurnoDto>>(results);
        }

        [HttpGet("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TurnoDto>> Get(int id)
        {
            var result = await _unitOfWork.Turnos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<TurnoDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Post(TurnoDto resultDto)
        {
            var result = _mapper.Map<Turno>(resultDto);
            if (resultDto.HoraInicio == TimeOnly.MinValue) // 2611
            {
                resultDto.HoraInicio = TimeOnly.FromDateTime(DateTime.Now);
                result.HoraInicio = TimeOnly.FromDateTime(DateTime.Now);
            }
            if (resultDto.HoraFinal == TimeOnly.MinValue) // 2611
            {
                resultDto.HoraFinal = TimeOnly.FromDateTime(DateTime.Now);
                result.HoraFinal = TimeOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Turnos.Add(result);
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
        public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody] TurnoDto resultDto)
        {
            var exists = await _unitOfWork.Turnos.GetByIdAsync(id);
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
            if (resultDto.HoraInicio == TimeOnly.MinValue)
            {
                exists.HoraInicio = TimeOnly.FromDateTime(DateTime.Now);
            }
            if (resultDto.HoraFinal == TimeOnly.MinValue)
            {
                exists.HoraFinal = TimeOnly.FromDateTime(DateTime.Now);
            }
            // The context is already tracking result, so no need to attach it
            await _unitOfWork.SaveAsync();
            // Return the updated entity
            return _mapper.Map<TurnoDto>(exists);
        }

        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Turnos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Turnos.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}