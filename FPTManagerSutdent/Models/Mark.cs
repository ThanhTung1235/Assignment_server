using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class Mark
    {
        public Mark()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdateAt = DateTime.Now;
            this.Practice = 0;
            this.Theory = 0;
            this.Assignment = 0;
        }
        public int Id { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public int Assignment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
