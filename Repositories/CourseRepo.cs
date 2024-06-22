using api.Data;
using api.Dtos.Course;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CourseRepo : ICourseRepo
    {
        private readonly SchoolDbContext _context;

        public CourseRepo(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>?> Get(CourseQueryObject query)
        {
            var courses = _context.Courses.AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.CourseName))
                courses = courses.Where(c => c.CourseName.Contains(query.CourseName));
            if(!string.IsNullOrWhiteSpace(query.Description))
                courses = courses.Where(c => c.CourseName.Contains(query.Description));
            
            courses = courses.Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student);

            return await courses.ToListAsync();
        }

        public async Task<Course?> GetById(int id)
        {
            var course = await _context.Courses
                .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
                .FirstOrDefaultAsync(c => c.Id == id);
            if(course == null)
                return null;
            return course;
        }

        public async Task<bool> Delete(int id)
        {
            var founded = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if(founded == null)
                return false;
            _context.Courses.Remove(founded);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Course?> Create(CreateCourseDto createCourseDto)
        {
            Course course = createCourseDto.ToCourse();
            var created = await _context.Courses.AddAsync(course);
            if(created == null)
                return null;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}