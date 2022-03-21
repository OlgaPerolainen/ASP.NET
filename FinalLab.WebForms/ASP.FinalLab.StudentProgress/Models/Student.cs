using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.FinalLab.StudentProgress.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public List<Grades> StudentGrades { get; set; }

        public Student() { }
        public Student(int studentID)
        { 
            StudentId = studentID;
        }
        public Student(string firstName, string lastName, string address, string phone, string email, DateTime enrollmentDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
            EnrollmentDate = enrollmentDate;
        }
    }
}