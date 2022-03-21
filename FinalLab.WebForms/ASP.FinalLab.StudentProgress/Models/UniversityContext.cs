using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ASP.FinalLab.StudentProgress.Models
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("University")
        { }
        public DbSet<Student> StudentsSet { get; set; }
        public DbSet<Course> CourseSet { get; set; }
        public DbSet<Grades> GradesSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grades>().HasKey(gr => new { gr.StudentID, gr.CourseID});
        }
    }
}