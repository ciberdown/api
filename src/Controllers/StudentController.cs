using api.Dtos;
using api.Dtos.Student;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.src.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        
        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<ApiListResDto<StudentDto>> Get([FromQuery] StudentQueryObject query){
            var students = await _studentRepo.Get(query);
            if (students == null || students.Count == 0)
                return new ApiListResDto<StudentDto>("not found!");
            var studentDtos = students.Select(student => student.ToStudentDto()).ToList();
            return new ApiListResDto<StudentDto>(studentDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResDto<StudentDto>> GetById([FromRoute]int id){
            var student = await _studentRepo.GetById(id);
            if (student == null)
                return new ApiResDto<StudentDto>("not found!");

            return new ApiResDto<StudentDto>(student.ToStudentDto());
        }

        [HttpPost]
        public async Task<ApiResDto<StudentDto>> Create([FromBody] CreateStudentDto createStudentDto){
             if(!ModelState.IsValid)
                 return new ApiResDto<StudentDto>("bad request");
            // if(createStudentDto == null)
            //     return BadRequest();
            var createdStudent = await _studentRepo.Create(createStudentDto);
            // if(createdStudent == null)
            //     return BadRequest();
            var result = await GetById(createdStudent.Id);
            return result;
        } 

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool success = await _studentRepo.Delete(id);
            if(success == false)
                return NotFound();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<ApiResDto<StudentDto>> Update([FromRoute] int id, UpdateStudentDto updateStudentDto){
            if(!ModelState.IsValid)
                return new ApiResDto<StudentDto>("bad request");
            var updatedStudent = await _studentRepo.Update(id, updateStudentDto);
            if(updatedStudent == null)
                return new ApiResDto<StudentDto>("not found!");

            return new ApiResDto<StudentDto>(updatedStudent.ToStudentDto());
        }
    }
}