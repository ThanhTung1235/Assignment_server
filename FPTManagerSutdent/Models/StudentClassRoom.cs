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
    }
}
