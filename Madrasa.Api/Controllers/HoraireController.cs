using Madrasa.Api.Dtos.Horaire;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Mappers;
using Madrasa.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoraireController : ControllerBase
    {
        private readonly IHoraireRepository _horaireRepo;
        public HoraireController(IHoraireRepository horaireRepo)
        {
            _horaireRepo = horaireRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vals = await _horaireRepo.GetAllAsync();
            return Ok(vals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var val = await _horaireRepo.GetByIdAsync(id);
            if (val == null)
            {
                return NotFound();
            }
            return Ok(val);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHoraireDto horaire)
        {
            var newHoraire = horaire.ToHoraireFromCreateHoraireDto();
            var vals = await _horaireRepo.CreateAsync(newHoraire);
            return Ok(vals);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditHoraireDto horaire)
        {
            var horaireToUpdate = horaire.ToHoraireFromEditHoraireDto();
            var horaireUpdated = await _horaireRepo.UpdateAsync(horaireToUpdate.Id, horaireToUpdate);

            if (horaireUpdated == null)
            {
                return NotFound();
            }

            return Ok(horaireUpdated);
        }
    }
}
