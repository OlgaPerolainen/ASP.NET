using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.FinalLab.StudentProgress.Models
{
    [Table("StudentGrades")]
    public class Grades
    {
        [Key]
        [Column("StudentID", Order=0)]
        public int StudentID { get; set; }
        //[ForeignKey("Student")]
        public Student student { get; set; }
        [Key]
        [Column("CourseID", Order=1)]
        public int CourseID { get; set; }
        //[ForeignKey("Course")]
        public Course course { get; set; }
        public decimal? Grade { get; set; }
    }
}