using Madrasa.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Madrasa.Api.Controllers
{
    [Route("api/Madrasa")]
    [ApiController]
    public class Madrasa : ControllerBase
    {
        public MadrasaDb _context;
        public Madrasa(MadrasaDb context) {
            _context = context;
        }
        

        [HttpGet]
        public IActionResult GetAll()
        {
            var vals = _context.Horaire.ToList().Select(c => c.ToHoraireDto());
            return Ok(vals);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var vals = _context.Horaire.Find(id);
            if (vals == null)
            {
                return NotFound();
            }
            return Ok(vals);
        }
    }
}
