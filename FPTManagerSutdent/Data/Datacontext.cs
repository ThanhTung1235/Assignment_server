using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPTManagerSutdent.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTManagerSutdent.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options)
            : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<ClassRoomCourse> ClassRoomCourse { get; set; }
        public DbSet<StudentClassRoom> StudentClassRoom { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.CourseId, sc.StudentId });
            modelBuilder.Entity<ClassRoomCourse>()
                .HasKey(sc => new { sc.CourseId, sc.ClassRoomId });
            modelBuilder.Entity<StudentClassRoom>()
                .HasKey(sc => new { sc.ClassRoomId, sc.StudentId });

        }
    }
    
}
