

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
            return Ok(sc.ToStandardRes());
        }
    }
}