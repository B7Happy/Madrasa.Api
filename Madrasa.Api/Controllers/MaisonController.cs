using Madrasa.Api.Dtos.Maison;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaisonController : ControllerBase
    {
        private readonly IMaisonRepository _maisonRepo;
        public MaisonController(MadrasaDb context, IMaisonRepository maisonRepo)
        {
            _maisonRepo = maisonRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vals = await _maisonRepo.GetAllAsync();
            return Ok(vals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vals = await _maisonRepo.GetByIdAsync(id);
            if (vals == null)
            {
                return NotFound();
            }
            return Ok(vals);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMaisonRequestDto MaisonDto)
        {
            var MaisonModel = MaisonDto.ToMaisonFromCreateDTO();
            await _maisonRepo.CreateAsync(MaisonModel);
            return CreatedAtAction(nameof(GetById), new { id = MaisonModel.Id }, MaisonModel.ToMaisonDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMaisonRequestDto updateMaison )
        {
           var maisonModel = await _maisonRepo.UpdateAsync(id, updateMaison);

            if (maisonModel == null)
            {
                return NotFound();
            }

            return Ok(maisonModel.ToMaisonDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var maisonModel = await _maisonRepo.DeleteAsync(id);
            if (maisonModel == null)
            {
                return NotFound();
            }
            return Ok(maisonModel.ToMaisonDto());
        }
    }
}
