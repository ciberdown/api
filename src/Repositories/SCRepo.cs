using api.Data;
using api.Dtos.StudentCoures;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.src.Dtos.StudentCoures;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class SCRepo : ISCRepo
    {
        private readonly SchoolDbContext _context;

        public SCRepo(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentCourse>?> Get(SCObjectQuery query)
        {
            var studentCourse = _context.StudentCourses.AsQueryable();

            if(query.CourseId != null)
                studentCourse = studentCourse.Where(sc => sc.CourseId == query.CourseId);
            if(query.StudentId != null)
                studentCourse = studentCourse.Where(sc => sc.StudentId == query.StudentId);
            if(query.Grade != null)
                studentCourse = studentCourse.Where(sc => sc.Grade == query.Grade);
            
            studentCourse = studentCourse
                .Include(sc => sc.Student)
                .Include(sc => sc.Course);

            return await studentCourse.ToListAsync();
        }

        public async Task<StudentCourse?> Update(UpdateSCDto updateSCDto)
        {
            var founded = await _context.StudentCourses
                .Include(s => s.Student)
                .Include(s => s.Course)
                .FirstOrDefaultAsync(sc => sc.StudentId == updateSCDto.StudentId && sc.CourseId == updateSCDto.CourseId);
            if(founded == null)
                return null;
            
            founded.Grade = updateSCDto.Grade;
            await _context.SaveChangesAsync();
            return founded;
        }

        public async Task<StudentCourse?> Create(CreateScDto createDto)
        {
            StudentCourse studentCourse = createDto.ToStudentCourse();
            await _context.StudentCourses
                .AddAsync(studentCourse);

            //if(created != null)
            //    return null;
             var result = await _context.SaveChangesAsync();

             if(result <= 0){
                return null;
             }
            return studentCourse;
        }

        public async Task<bool> Delete(DeleteSCDto deleteSCDto)
        {
            var founded = await  _context.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentId == deleteSCDto.StudentId
                 && sc.CourseId == deleteSCDto.CourseId);
            if(founded == null)
                return false;
            _context.Remove(founded);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}