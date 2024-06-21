using api.Data;
using api.Dtos.Student;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly SchoolDbContext _context;

        public StudentRepo(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> Get(){
            var students = await _context.Students
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .ToListAsync();

            return students;
        }
        public async Task<StudentDto?> GetById(int id){
            Student? student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if(student == null)
                return null;

            return student.ToStudentDto();
        }


        public async Task<StudentDto?> Create(CreateStudentDto createStudentDto){
            Student student = createStudentDto.ToCreateStudentDto();
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student.ToStudentDto();
        }

        public async Task<bool> Delete(int id){
            var founded = await _context.Students.FindAsync(id);
            if(founded == null)
                return false;
            _context.Students.Remove(founded);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StudentDto?> Update(int id, UpdateStudentDto updateStudentDto){
            Student? founded = await _context.Students.FindAsync(id);
            if(founded == null)
                return null;
            if(updateStudentDto.Name != null)
                founded.Name = updateStudentDto.Name;
            if(updateStudentDto.Status != null)
                founded.Status = updateStudentDto.Status;

            var studentProperties = typeof(UpdateStudentDto).GetProperties();
            foreach(var property in studentProperties){
                System.Console.WriteLine(property);
            }

            await _context.SaveChangesAsync();
            return founded.ToStudentDto();
        }
    }
}