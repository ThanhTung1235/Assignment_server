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
        [Display(Name = "Roll Number")]
        [Required(ErrorMessage = "The Roll Number is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Min Length Of 3 And Max Length Of 30")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public GenderStudent Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
        public StudentStatus Status { get; set; }
        public List<Mark> Marks { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        [Display(Name = "Class Room")]
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
