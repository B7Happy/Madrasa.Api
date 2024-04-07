using Madrasa.Api.Dtos.Eleves;
using Madrasa.Api.Dtos.Professeurs;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Mappers;
using Madrasa.Api.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseursController : ControllerBase
    {
        private readonly IProfesseursRepository _professeursRepository;

        public ProfesseursController(IProfesseursRepository professeursRepository)
        {
            _professeursRepository = professeursRepository;
        }

        [HttpGet]
        [EnableCors("Policy")]
        public async Task<ActionResult<IEnumerable<Professeurs>>> GetAllAsync()
        {
            var professeurs = await _professeursRepository.GetAllAsync();
            return Ok(professeurs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professeurs>> GetByIdAsync(int id)
        {
            var professeurs = await _professeursRepository.GetByIdAsync(id);
            if (professeurs == null)
            {
                return NotFound();
            }
            return Ok(professeurs);
        }

        [HttpPost]
        public async Task<ActionResult<Professeurs>> CreateAsync([FromBody] CreateProfesseursRequestDto professeurs)
        {
            var professeursModel = professeurs.ToProfesseursFromCreateDTO();
            var createdProfesseurs = await _professeursRepository.CreateAsync(professeursModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdProfesseurs.Id }, createdProfesseurs);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Professeurs>> UpdateAsync(int id, UpdateProfesseursRequestDto professeurs)
        {
            var updatedProfesseurs = await _professeursRepository.UpdateAsync(id, professeurs);
            if (updatedProfesseurs == null)
            {
                return NotFound();
            }
            return Ok(updatedProfesseurs);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Professeurs>> DeleteAsync(int id)
        {
            var deletedProfesseurs = await _professeursRepository.DeleteAsync(id);
            if (deletedProfesseurs == null)
            {
                return NotFound();
            }
            return Ok(deletedProfesseurs);
        }
    }
}
