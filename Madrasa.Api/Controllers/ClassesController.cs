using Madrasa.Api.Dtos.Classes;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesRepository _classesRepo;
        public ClassesController(IClassesRepository classesRepo)
        {
            _classesRepo = classesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vals = await _classesRepo.GetAllAsync();
            return Ok(vals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vals = await _classesRepo.GetByIdAsync(id);
            if (vals == null)
            {
                return NotFound();
            }
            return Ok(vals);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassesRequestDto classeDto)
        {
            var classeModel = classeDto.ToClassesFromCreateDTO();
            await _classesRepo.CreateAsync(classeModel);
            return CreatedAtAction(nameof(GetById), new { id = classeModel.Id }, classeModel.ToClassesDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClassesRequestDto updateClasse)
        {
            var classeModel = await _classesRepo.UpdateAsync(id, updateClasse);

            if (classeModel == null)
            {
                return NotFound();
            }

            return Ok(classeModel.ToClassesDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var classeModel = await _classesRepo.DeleteAsync(id);

            if (classeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
