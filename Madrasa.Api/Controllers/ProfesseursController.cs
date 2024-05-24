using Madrasa.Api.Dtos.Classes;
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
            return Ok(createdProfesseurs);
        }

        [HttpPut]
        public async Task<ActionResult<Professeurs>> UpdateAsync([FromBody] UpdateProfesseursRequestDto professeurs)
        {
            var updatedProfesseurs = await _professeursRepository.UpdateAsync(professeurs.Id, professeurs);
            if (updatedProfesseurs == null)
            {
                return NotFound();
            }
            return Ok(updatedProfesseurs);
        }

        [HttpDelete]
        public async Task<ActionResult<Professeurs>> DeleteAsync(CreateProfesseursRequestDto professeurs)
        {
            var deletedProfesseurs = await _professeursRepository.DeleteAsync(professeurs.Id);
            if (deletedProfesseurs == null)
            {
                return NotFound();
            }
            return Ok(deletedProfesseurs);
        }



        [HttpGet("GetAllProfesseurs")]
        public async Task<IActionResult> GetAllProfesseurs()
        {
            var vals = await _professeursRepository.GetAllAsync();

            var classesSelect = vals.Select(x => new ProfesseursSelect
            {
                name = x.Nom,
                value = x.Id
            }).ToList();
            return Ok(classesSelect);
        }
    }
}
