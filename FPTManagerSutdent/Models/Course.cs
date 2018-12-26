using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class Course
    {
        public Course()
        {
            this.CreatedAt = DateTime.Now;
            this.Status = CourseStatus.Active;
        }
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Maximum length is 100")]
        [StringLength(50)]    
        public string Name { get; set; }
        [Required(ErrorMessage = "Maximum length is 300")]
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiredAt { get; set; }
        public CourseStatus Status { get; set; } 
        public List<Mark> Marks { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public List<ClassRoomCourse> ClassRoomCourses { get; set; }
    }

    public enum CourseStatus
    {
        Active = 1,
        Deactive =0
    }

}
