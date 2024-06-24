

using api.Dtos;
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
        public async Task<ApiResDto<CountedResDto<StudentCourseDto>>> Get([FromQuery] SCObjectQuery query)
        {
            var sc = await _sCRepo.Get(query);
            if (sc == null)
                return new ApiResDto<CountedResDto<StudentCourseDto>>("bad request");
            var res = sc.Select(sc => sc.ToSCDto()).ToList().ToCountedResDto();
            return new ApiResDto<CountedResDto<StudentCourseDto>>(res);
        }

        [HttpPost]
        public async Task<ApiResDto<StudentCourseDto>> Post([FromBody] CreateScDto createDto){
            if(!ModelState.IsValid)
                return new ApiResDto<StudentCourseDto>("bad request");

            var sc = await _sCRepo.Create(createDto);

            if (sc == null)
                return new ApiResDto<StudentCourseDto>("bad request");

            var query = new SCObjectQuery{StudentId = sc.StudentId, CourseId = sc.CourseId};

            var scDto = await Get(query);
            if(scDto?.Body?.Items[0] == null)
                return new ApiResDto<StudentCourseDto>("bad request");

            return new ApiResDto<StudentCourseDto>(scDto?.Body?.Items[0]);
        }

        [HttpPatch("grade")]
        public async Task<ApiResDto<StudentCourseDto>> Update([FromBody] UpdateSCDto updateSCDto)
        {
            if(!ModelState.IsValid)
                return new ApiResDto<StudentCourseDto>("bad request");

            var updated = await _sCRepo.Update(updateSCDto);
            if (updated == null)
                return new ApiResDto<StudentCourseDto>("bad request");

            
            return new ApiResDto<StudentCourseDto>(updated.ToSCDto());
        }
    }
}