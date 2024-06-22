using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public SchoolDbContext(DbContextOptions options): base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //PK for sc
            builder.Entity<StudentCourse>()
                .HasKey(sc => new{sc.StudentId, sc.CourseId});

            //FK for student in sc
            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            //FK for course in sc
            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            //coursename is unique
            builder.Entity<Course>()
                .HasIndex(c => c.CourseName)
                .IsUnique();
                
        }

    }
}