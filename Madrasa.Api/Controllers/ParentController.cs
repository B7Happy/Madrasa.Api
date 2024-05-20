using Madrasa.Api.Dtos.Parent;
using Madrasa.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Madrasa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _parentRepo;
        public ParentController(IParentRepository parentRepository ) 
        {
            _parentRepo = parentRepository;        
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] List<UpdateParentRequestDto> updateParent)
        {
            var parentModel = new Model.Parent();
            foreach (var parent in updateParent)
            {
                parentModel = await _parentRepo.UpdateAsync(parent.Id, parent);
            }

            return Ok();
        }
    }
}
