using api.Dtos.Student;
using api.Interfaces;
using api.Mappers;
using api.Models;
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
        public async Task<IActionResult> Get(){
            var students = await _studentRepo.Get();
            if (students == null || students.Count == 0)
                return NotFound();
            var studentDtos = students.Select(student => student.ToStudentDto()).ToList();
            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            var student = await _studentRepo.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto createStudentDto){
            if(createStudentDto == null)
                return BadRequest();
            var createdStudent = await _studentRepo.Create(createStudentDto);
            if(createdStudent == null)
                return BadRequest();
            return CreatedAtAction(nameof(Create), new {id = createdStudent.Id}, createdStudent);
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool success = await _studentRepo.Delete(id);
            if(success == false)
                return NotFound();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStudentDto updateStudentDto){
            var updatedStudent = await _studentRepo.Update(id, updateStudentDto);
            if(updatedStudent == null)
                return NotFound();
            return Ok(updatedStudent);
        }
    }
}