using api.Dtos.Student;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentRepo
    {
        public Task<List<Student>?> Get(StudentQueryObject query);
        public Task<Student?> GetById(int id);
        public Task<Student?> Create(CreateStudentDto createStudentDto);
        public Task<bool> Delete(int id);
        public Task<Student?> Update(int id, UpdateStudentDto updateStudentDto);
    }
}