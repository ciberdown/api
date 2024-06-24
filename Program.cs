

using api;
using api.Controllers;
using api.Data;
using api.Interfaces;
using api.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection
builder.Services.AddScoped<IStudentRepo,StudentRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<ISCRepo,SCRepo>();

//add controllers
builder.Services.AddControllers();

//prevent json loops
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

if(args != null && args.Count() > 0)
    System.Console.WriteLine("args[0]: "+args[0]);

//Add DbContext
builder.Services.AddDbContext<SchoolDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register controllers as services
builder.Services.AddScoped<StudentController>();
builder.Services.AddScoped<CourseController>();
builder.Services.AddScoped<SCContoller>();
builder.Services.AddScoped<SchoolDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//map controllers routes to the endpoints
app.MapControllers();

// Run the seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Get instances of the controllers
    var studentController = services.GetRequiredService<StudentController>();
    var courseController = services.GetRequiredService<CourseController>();
    var studentCourseController = services.GetRequiredService<SCContoller>();


    // Instantiate and run the Seed class
    var seed = new Seed(studentController, courseController, studentCourseController);
    try
    {
        await seed.SeedData();
    }
    catch (System.Exception)
    {
        
        System.Console.WriteLine("seed data error");
    }
}

app.Run();

