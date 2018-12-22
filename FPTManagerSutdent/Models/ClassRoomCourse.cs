using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class ClassRoomCourse
    {
        public int CourseId { get; set; }
        public int ClassRoomId { get; set; }
        public Course Course { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
