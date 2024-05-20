using Madrasa.Api.Dtos.Groupe;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Mappers;
using Madrasa.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeController : ControllerBase
    {
        private readonly IGroupeRepository _groupeRepo;
        public GroupeController(IGroupeRepository groupeRepo)
        {
            _groupeRepo = groupeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vals = await _groupeRepo.GetAllAsync();
            return Ok(vals);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGroupeDto groupe)
        {
            var newGroupe = groupe.ToGroupeFromCreateGroupeDto();
            var vals = await _groupeRepo.CreateAsync(newGroupe);
            return Ok(vals);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGroupe groupe)
        {
            var groupeToUpdate = await _groupeRepo.UpdateAsync(groupe.Id, groupe);

            if (groupeToUpdate == null)
            {
                return NotFound();
            }

            return Ok(groupeToUpdate);
        }
    }
}
