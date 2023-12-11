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
    public class DescripcionpersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DescripcionpersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DescripcionpersonaDto>>> Get()
        {
            var results = await _unitOfWork.Descripcionpersonas.GetAllAsync();
            return _mapper.Map<List<DescripcionpersonaDto>>(results);
        }

        [HttpGet("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DescripcionpersonaDto>> Get(int id)
        {
            var result = await _unitOfWork.Descripcionpersonas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<DescripcionpersonaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DescripcionpersonaDto>> Post(DescripcionpersonaDto resultDto)
        {
            var result = _mapper.Map<Descripcionpersona>(resultDto);
            if (resultDto.FechaRegistro == DateOnly.MinValue) // 2611
            {
                resultDto.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
                result.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Descripcionpersonas.Add(result);
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
        public async Task<ActionResult<DescripcionpersonaDto>> Put(int id, [FromBody] DescripcionpersonaDto resultDto)
        {
            var exists = await _unitOfWork.Descripcionpersonas.GetByIdAsync(id);
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
            if (resultDto.FechaRegistro == DateOnly.MinValue)
            {
                exists.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            }
            // The context is already tracking result, so no need to attach it
            await _unitOfWork.SaveAsync();
            // Return the updated entity
            return _mapper.Map<DescripcionpersonaDto>(exists);
        }

        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Descripcionpersonas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Descripcionpersonas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}