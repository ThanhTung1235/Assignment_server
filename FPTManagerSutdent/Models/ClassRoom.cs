using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class ClassRoom
    {
        public ClassRoom()
        {
            this.UpdatedAt =DateTime.Now;
            this.CreatedAt = DateTime.Now;
            this.Status = ClassRoomStatus.Active;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ClassRoomStatus Status { get; set; }
        public List<StudentClassRoom> StudentClassRooms { get; set; }
        public List<ClassRoomCourse> ClassRoomCourses { get; set; }
    }

    public enum ClassRoomStatus
    {
        Active = 1,
        Deactive = 0
    }
}
