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
            foreach (var classe in vals)
            {
                classe.Professeurs.Classes = null;
            }
            foreach (var classe in vals)
            {
                foreach (var eleve in classe.Eleves)
                {
                    eleve.Classes = null;
                }
            }
            return Ok(vals);
        }

        [HttpGet("GetAllClasses")]
        public async Task<IActionResult> GetAllClasse()
        {
            var vals = await _classesRepo.GetAllAsync();
            foreach (var classe in vals)
            {
                classe.Professeurs.Classes = null;
            }
            foreach (var classe in vals)
            {
                foreach (var eleve in classe.Eleves)
                {
                    eleve.Classes = null;
                }
            }

            var classesSelect = vals.Select(x => new ClassesSelect
            {
                name = x.Classe,
                value = x.Id
            }).ToList();
            return Ok(classesSelect);
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
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClassesRequestDto updateClasse)
        {
            var classeModel = await _classesRepo.UpdateAsync(updateClasse.Id, updateClasse);

            if (classeModel == null)
            {
                return NotFound();
            }

            return Ok(classeModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ClassesDto classe)
        {
            var classeModel = await _classesRepo.DeleteAsync(classe.Id);

            if (classeModel == null)
            {
                return NotFound();
            }

            return Ok(classeModel);
        }
    }
}
