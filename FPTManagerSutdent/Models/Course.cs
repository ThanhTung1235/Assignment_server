using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
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
