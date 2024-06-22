
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




//Add DbContext
builder.Services.AddDbContext<SchoolDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

app.Run();

