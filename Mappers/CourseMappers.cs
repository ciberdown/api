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
                CourseName = course.CourseName,
                Description = course.Description,
                StudentCourses = course.StudentCourses.Select(s => s.ToScInCourseDto()).ToList().ToStandardRes()
            };
        }

        public static SCinCourseDto ToScInCourseDto(this StudentCourse sc){
            return new SCinCourseDto
            {
                StudentId = sc.StudentId,
                Student = sc.Student.ToStudentInCourseDto(),
                grade = sc.grade
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
    }
}