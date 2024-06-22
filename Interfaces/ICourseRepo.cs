using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Course;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ICourseRepo
    {
        public Task<List<Course>?> Get(CourseQueryObject query);
        public Task<Course?> GetById(int id);
        public Task<bool> Delete(int id);
        public Task<Course?> Create(CreateCourseDto createCourseDto);

    }
}