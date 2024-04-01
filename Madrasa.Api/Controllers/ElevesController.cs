using Madrasa.Api.Dtos.Eleves;
using Madrasa.Api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevesController : ControllerBase
    {
        public MadrasaDb _context;
        public ElevesController(MadrasaDb context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var vals = _context.Eleves.ToList();
            return Ok(vals);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var vals = _context.Eleves.Find(id);
            if (vals == null)
            {
                return NotFound();
            }
            return Ok(vals);
        }

        [HttpPost]
        public IActionResult CreateEleve([FromBody] CreateEleveRequestDto EleveDto)
        {
            var EleveModel = EleveDto.ToElevesFromCreateDTO();
            _context.Eleves.Add(EleveModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = EleveModel.Id }, EleveModel.ToEleveDto());
        }
    }
}
