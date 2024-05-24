using Madrasa.Api.Dtos.Eleves;
using Madrasa.Api.Dtos.Maison;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Mappers;
using Madrasa.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevesController : ControllerBase
    {
        private readonly IElevesRepository _elevesRepo;
        private readonly IMaisonRepository _maisonRepo;
        private readonly IParentRepository _parentRepo;
        public ElevesController(IElevesRepository elvesRepo, IMaisonRepository maisonRepo, IParentRepository parentRepo)
        {
            _elevesRepo = elvesRepo;
            _maisonRepo = maisonRepo;
            _parentRepo = parentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vals = await _elevesRepo.GetAllAsync();
            return Ok(vals);
        }

        [HttpGet("CurrentEleves")]
        public async Task<IActionResult> GetAllEleveInCLasse()
        {
            var vals = await _elevesRepo.GetAllEleveInClasseAsync();
            foreach (var eleve in vals)
            {
                eleve.Classes.Eleves = null;
            }
            return Ok(vals);
        }

        [HttpGet("CurrentElevesDoc")]
        public async Task<IActionResult> GetAllEleveForDoc()
        {
            var vals = await _elevesRepo.GetAllEleveForDocAsync();
            foreach (var eleve in vals)
            {
                eleve.Classes.Eleves = null;
            }
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
            var eleveByClasse = await _elevesRepo.GetAllEleveByClasseAsync((int)vals.ClassesId);
            vals.Classes.Eleves = eleveByClasse.ToList();
            return Ok(vals);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEleveRequest EleveDto)
        {
            var EleveModel = EleveDto.ToElevesFromCreate();
            EleveModel.DateEntree = DateTime.Now;

            if (EleveDto.Maison.Adresse != "")
            {
                var MaisonModel = EleveDto.Maison.ToMaisonFromCreateDTO();
                var newMaison = await _maisonRepo.CreateAsync(MaisonModel);

                foreach (var parent in EleveDto.Parent)
                {

                    var newParent = parent.ToParentFromCreateDTO();
                    newParent.MaisonId = newMaison.Id;
                    await _parentRepo.CreateAsync(newParent);
                }

                EleveModel.MaisonId = newMaison.Id;
            }

            var newEleve = await _elevesRepo.CreateAsync(EleveModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEleveRequestDto updateEleve)
        {
            var eleveModel = await _elevesRepo.UpdateAsync(updateEleve.Id, updateEleve);

            if (eleveModel == null)
            {
                return NotFound();
            }

            return Ok(eleveModel);
        }

        [HttpPut("Suspendre")]
        public async Task<IActionResult> Suspendre([FromBody] SuspendreEleveDto suspendreEleve)
        {
            var eleveModel = await _elevesRepo.SuspendreEleveAsync(suspendreEleve);

            if (eleveModel == null)
            {
                return NotFound();
            }

            return Ok(eleveModel);
        }

        //[HttpPut]
        //public async Task<IActionResult> Update(Eleves updateEleve)
        //{
        //    var eleveModel = await _elevesRepo.UpdateAllAsync(updateEleve);

        //    if (eleveModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(eleveModel);
        //}

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
