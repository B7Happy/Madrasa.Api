using Madrasa.Api.Dtos.Eleves;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevesController : ControllerBase
    {
        public MadrasaDb _context;
        private readonly IElevesRepository _elevesRepo;
        public ElevesController(MadrasaDb context, IElevesRepository elvesRepo)
        {
            _elevesRepo = elvesRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vals = await _elevesRepo.GetAllAsync();
            return Ok(vals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vals = await _elevesRepo.GetByIdAsync(id);
            if (vals == null)
            {
                return NotFound();
            }
            return Ok(vals);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEleveRequestDto EleveDto)
        {
            var EleveModel = EleveDto.ToElevesFromCreateDTO();
            await _elevesRepo.CreateAsync(EleveModel);
            return CreatedAtAction(nameof(GetById), new { id = EleveModel.Id }, EleveModel.ToEleveDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEleveRequestDto updateEleve )
        {
           var eleveModel = await _elevesRepo.UpdateAsync(id, updateEleve);

            if (eleveModel == null)
            {
                return NotFound();
            }

            return Ok(eleveModel.ToEleveDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var eleveModel = await  _elevesRepo.DeleteAsync(id);

            if (eleveModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
