using api.Dtos.Student;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentRepo
    {
        public Task<List<Student>> Get();
        public Task<StudentDto?> GetById(int id);
        public Task<StudentDto?> Create(CreateStudentDto createStudentDto);
        public Task<bool> Delete(int id);
        public Task<StudentDto?> Update(int id, UpdateStudentDto updateStudentDto);
    }
}