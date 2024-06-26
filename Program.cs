

using api;
using api.Controllers;
using api.Data;
using api.Interfaces;
using api.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DotNetEnv;


var builder = WebApplication.CreateBuilder(args);

//load .env file
Env.Load();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();


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

    

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
var connectionType = Environment.GetEnvironmentVariable("ConnectionType");
//Add DbContext
builder.Services.AddDbContext<SchoolDbContext>(options => {
    if(connectionType == "SSMS")
        options.UseSqlServer(connectionString);
    else if(connectionType == "AzureSqlServer")
        options.UseSqlServer(connectionString);
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

// Seed Database if the argument is provided
if (args != null && args.Length > 0 && args[0] == "seed")
{
    await SeedDatabase(app);
    return;
}

// Run the seed data(dotnet run seed)
async Task SeedDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var services = scope.ServiceProvider;

        // Get instances of the controllers
        var studentController = services.GetRequiredService<StudentController>();
        var courseController = services.GetRequiredService<CourseController>();
        var studentCourseController = services.GetRequiredService<SCContoller>();

        // Instantiate and run the Seed class
        var seed = new Seed(studentController, courseController, studentCourseController);
        await seed.SeedData();
        }
        catch (Exception es)
        {

            throw es;
        }
    }
}

app.Run();

