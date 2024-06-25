using api.Dtos;
using api.Dtos.Course;
using api.Dtos.Student;
using api.Models;

namespace api.Mappers
{
    public static class CourseMappers
    {


        public static CourseDto ToCourseDto(this Course course){
            return new CourseDto
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Description = course.Description,
                Students = course.StudentCourses.Select(s => s.ToScInCourseDto()).ToList().ToCountedResDto(),
                CreationDate = course.CreationDate,
                StartDate = course.StartDate,
            };
        }

        public static SCinCourseDto ToScInCourseDto(this StudentCourse sc){
            return new SCinCourseDto
            {
                Id = sc.StudentId,
                Name = sc.Student.Name,
                Status = sc.Student.Status,
                Grade = sc.Grade
            };
        }
        public static StudentInCourseDto ToStudentInCourseDto(this Student student)
        {
            return new StudentInCourseDto
            {
                Id = student.Id,
                Name = student.Name, 
                Status = student.Status,
            };
        }

        public static Course ToCourse(this CreateCourseDto createCourseDto)
        {
            return new Course
            {        
                CourseName = createCourseDto.CourseName,
                Description = createCourseDto.Description,
                CreationDate = DateTime.Now,
                StartDate = createCourseDto.StartDate,
            };
        }
    }
}