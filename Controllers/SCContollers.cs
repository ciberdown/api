

using api.Dtos.StudentCoures;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/studentCourse")]
    [ApiController]
    public class SCContoller : ControllerBase
    {
        private readonly ISCRepo _sCRepo;

        public SCContoller(ISCRepo sCRepo)
        {
            _sCRepo = sCRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] SCObjectQuery query)
        {
            var sc = await _sCRepo.Get(query);
            if (sc == null)
                return NotFound();
            var res = sc.Select(sc => sc.ToSCDto()).ToList().ToStandardRes();
            return Ok(res);
        }

        [HttpPatch("grade")]
        public async Task<ActionResult> Update([FromBody] UpdateSCDto updateSCDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var updated = await _sCRepo.Update(updateSCDto);
            if (updated == null)
                return NotFound();
            
            return Ok(updated.ToSCDto());
        }

        
    }
}