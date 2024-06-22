//create project===================================
// dotnet new webapi -o projectName

// dotnet watch
// dotnet ef migrations add init
// dotnet ef database update

map:
.Select(x => x.id == Id)

join:
.Include(s => s.StudentCourses)
    .ThenInclude(sc => sc.Course)

filter:
.Where(x => x.Name = "Bob")

limit:
.Limit(2)

//validation
if(!ModelState.IsValid)
    return BadRequest(ModelState);

//attributes===================================
//[Column(Typename = "decimal(18,2)")]
[key] -> primary key
[ForeignKey("Standard")] -> foreign key
[DefaultValue("Not Set")]
[index]
[Required]
[MaxLength(50)]
[StringLength(50)]
[Column(TypeName = "decimal(10, 2)")]
[Timestamp]
[MinLength(5, ErrorMessage = "min len is 5")]
[Range(1, 5000)]

//Nuget packages===================================
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Tools
//Microsoft.EntityFrameworkCore.Design

//models===================================
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Exam> Exams { get; set; } = new List<Exam>();
}
public class Exam {
    public int Id { get; set; }
    public int Grade { get; set; }
    public string ExamName { get; set; }
    
    public int StudentId { get; set; }
    public Student Student { get; set; }
}

//connect dbContext===================================
builder.Services.AddDbContext<SchoolDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//controller===================================
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
    
        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var students = await _studentRepo.Get();
            if (students == null || students.Count == 0)
                return NotFound();
            var studentDtos = students.Select(student => student.ToStudentDto()).ToList();
            return Ok(studentDtos);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            var student = await _studentRepo.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student.ToStudentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto createStudentDto){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(createStudentDto == null)
                return BadRequest();
            var createdStudent = await _studentRepo.Create(createStudentDto);
            if(createdStudent == null)
                return BadRequest();
            return CreatedAtAction(nameof(Create), new {id = createdStudent.Id}, createdStudent);
        } 

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool success = await _studentRepo.Delete(id);
            if(success == false)
                return NotFound();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStudentDto updateStudentDto){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedStudent = await _studentRepo.Update(id, updateStudentDto);
            if(updatedStudent == null)
                return NotFound();
            return Ok(updatedStudent.ToStudentDto());
        }
    }

//inject Repository===================================
builder.Services.AddScoped<IStudentRepo,StudentRepo>();


//add controllers===================================
builder.Services.AddControllers();

//map controllers routes to the endpoints===================================
app.MapControllers();

// Repository===================================
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
    }


// Dtos===============================================
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } = "Ok";
        
        public List<StudentCoursesDto>? StudentCourses { get; set;}
    }

//mappers===============================================
public static StudentDto ToStudentDto(this Student student)
{
    return new StudentDto{
        Id = student.Id,
        Name = student.Name, 
        Status = student.Status,
        StudentCourses = student.StudentCourses?.Select(sc => sc.ToStudentCourseDto()).ToList()
    };
}



//query==============================================
public async Task<List<Student>?> Get(StudentQueryObject query){
    var students = _context.Students.Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course).AsQueryable();
        
    if(!string.IsNullOrWhiteSpace(query.Name))
        students = students.Where(s => s.Name.Contains(query.Name));

    if(!string.IsNullOrWhiteSpace(query.Status))
        students = students.Where(s => s.Status.Contains(query.Status));

    return await students.ToListAsync();
}


//handle reference loop (Newtonsoft.Json)
services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });