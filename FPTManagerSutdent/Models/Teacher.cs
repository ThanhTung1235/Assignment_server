using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = TeacherStatus.Active;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TeacherStatus Status { get; set; }
    }

    public enum TeacherStatus
    {
        Active = 1,
        Deactive = 0
    }
}
