using api.Controllers;
using api.Data;
using api.Dtos.Course;
using api.Dtos.Student;
using api.Dtos.StudentCoures;

namespace api
{
    public class Seed
    {
        private readonly StudentController _studentController;
        private readonly CourseController _courseController;
        private readonly SCContoller _studentCourseController;
        private CreateStudentDto[] newStudents = {
            new CreateStudentDto{Name = "Bob"},
            new CreateStudentDto{Name = "Sam"},
            new CreateStudentDto{Name = "Richard"},
            new CreateStudentDto{Name = "David"},
            new CreateStudentDto{Name = "Robbert"}
        };
        private CreateCourseDto[] newCourses = {
            new CreateCourseDto{CourseName="Math", Description = "learn advance math with M.Mirzaxani"},
            new CreateCourseDto{CourseName="History", Description = "History is a Mistory(with Mal)!"},
            new CreateCourseDto{CourseName="Programming", Description = "programming basics with David J.Malen"},
            new CreateCourseDto{CourseName="Chemistry", Description = "learn chesmistry with W.White!"},
            new CreateCourseDto{CourseName="Management", Description = "learn about industry with I.Mask"},
        };
        private CreateScDto[] newStudentCourses = {
            new CreateScDto{CourseId = 1, StudentId = 1},
            new CreateScDto{CourseId = 2, StudentId = 1, Grade=20},
            new CreateScDto{CourseId = 2, StudentId = 3},
            new CreateScDto{CourseId = 3, StudentId = 2},
            new CreateScDto{CourseId = 3, StudentId = 3},
            new CreateScDto{CourseId = 3, StudentId = 4},
            new CreateScDto{CourseId = 4, StudentId = 2},
            new CreateScDto{CourseId = 4, StudentId = 3},
        };

        public Seed(StudentController studentController, CourseController courseController, SCContoller sCContoller)
        {
            _studentController = studentController;
            _courseController = courseController;
            _studentCourseController = sCContoller;

            // SeedData();
        }

        public async Task SeedData(){
            // var students = await _studentController.Get(new Helpers.StudentQueryObject());
            // if(students?.Body?.Items == null || students?.Body.Items.Count == 0){
            //     return;
            // }
            foreach (var item in newStudents)
            {
                await  _studentController.Create(item);
            }

            foreach (var item in newCourses)
            {
                await _courseController.Create(item);
            }

            foreach (var item in newStudentCourses)
            {
                await _studentCourseController.Create(item);
            }
        }
    }
}