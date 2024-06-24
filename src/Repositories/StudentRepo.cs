using api.Data;
using api.Dtos.Student;
using api.Helpers;
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

        public async Task<List<Student>?> Get(StudentQueryObject query){
            var students = _context.Students.Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course).AsQueryable();
                
            if(!string.IsNullOrWhiteSpace(query.Name))
                students = students.Where(s => s.Name.Contains(query.Name));

            if(!string.IsNullOrWhiteSpace(query.Status))
                students = students.Where(s => s.Status.Contains(query.Status));

            return await students.ToListAsync();
        }
        public async Task<Student?> GetById(int id){
            var student =await _context.Students
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course).FirstOrDefaultAsync(s => s.Id == id);

            if(student == null)
                return null;

            return student;
        }


        public async Task<Student?> Create(CreateStudentDto createStudentDto){
            Student student = createStudentDto.ToStudent();
            var created = await _context.Students.AddAsync(student);
            if(created == null)
                return null;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> Delete(int id){
            var founded = await _context.Students.FindAsync(id);
            if(founded == null)
                return false;
            _context.Students.Remove(founded);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Student?> Update(int id, UpdateStudentDto updateStudentDto){
            Student? founded = await _context.Students
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.Id == id);

            if(founded == null)
                return null;

            if(updateStudentDto.Name != null)
                founded.Name = updateStudentDto.Name;
            if(updateStudentDto.Status != null)
                founded.Status = updateStudentDto.Status;

            await _context.SaveChangesAsync();
            return founded;
        }
    }
}