using api.Dtos.Student;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
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
        public async Task<IActionResult> Get([FromQuery] StudentQueryObject query){
            var students = await _studentRepo.Get(query);
            if (students == null || students.Count == 0)
                return NotFound();
            var studentDtos = students.Select(student => student.ToStudentDto()).ToList();
            return Ok(studentDtos.ToStandardRes());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            var student = await _studentRepo.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student.ToStudentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto createStudentDto){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(createStudentDto == null)
                return BadRequest();
            var createdStudent = await _studentRepo.Create(createStudentDto);
            if(createdStudent == null)
                return BadRequest();
            return CreatedAtAction(nameof(Create), new {id = createdStudent.Id}, createdStudent);
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
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStudentDto updateStudentDto){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedStudent = await _studentRepo.Update(id, updateStudentDto);
            if(updatedStudent == null)
                return NotFound();
            return Ok(updatedStudent.ToStudentDto());
        }
    }
}