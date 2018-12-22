using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class Student
    {
        public Student()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = StudentStatus.Active;
            this.Gender = GenderStudent.Male;
        }
        [Key]
        public long Rollnumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public GenderStudent Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public StudentStatus Status { get; set; }
        public List<Mark> Marks { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public List<StudentClassRoom> StudentClassRooms { get; set; }
    }

    public enum StudentStatus
    {
        Active = 1,
        Deactive = 0
    }

    public enum GenderStudent
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}
