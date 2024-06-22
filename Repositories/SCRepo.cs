using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
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
            if(query.grade != null)
                studentCourse = studentCourse.Where(sc => sc.grade == query.grade);
            
            studentCourse = studentCourse
                .Include(sc => sc.Student)
                .Include(sc => sc.Course);

            return await studentCourse.ToListAsync();
        }
    }
}