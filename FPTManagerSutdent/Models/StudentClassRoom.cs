using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class StudentClassRoom
    {
        public int StudentId { get; set; }
        public int ClassRoomId { get; set; }
        public Student Student { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime LeftAt { get; set; }
        public StudentClassRoomStatus Status { get; set; }
    }

    public enum StudentClassRoomStatus
    {
        Active = 1,
        Deactive = 0
    }
}
