// Entity Framework (code first)

//DataAnnotaions
[key] -> primary key
[ForeignKey("Standard")] -> foreign key
[DefaultValue("Not Set")]
[index]
[Required]
[MaxLength(50)]
[StringLength(50)]
[Column(TypeName = "decimal(10, 2)")]
[Timestamp]

//model/Student.cs
public class Student
{
    public int Id { get; set; } //primary key
    public string Name { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public int GradeId { get; set; } //foreign key
    public Grade Grade { get; set; }

}

//model/Grade.cs
public class Grade
{
    public int Id { get; set; }
    public int ExamGrade { get; set; }
    public ICollection<Student> students { get; set; }
}

//Data/SchoolContext.cs
public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    public SchoolContext(DbContextOptions options) : base(options)
    {
        //required
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //define student foreign key
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Grade)
            .WithMany(g => g.students)
            .HasForeignKey(student => student.GradeId)
            .WillCascadeOnDelete(true);

        //define grade primary key
        modelBuilder.Entity<Grade>()
            .HasKey(g => g.Id);

        //define student primary key
        modelBuilder.Entity<Student>()
            .HasKey(s => s.Id);
    }
}

//Program.cs
builder.Services.AddDbContext<SchoolContext>(options =>
    {
        options.UseSqlServer("server={server-name};Database={NewDataBaseName};Trusted_Connection=True;TrustServerCertificate=True;");
    }
);


//Package Manager Console in Visual Studio
add-migration IntialCreate
update-database

//terminal in vs code
dotnet ef migrations add init
dotnet ef database update