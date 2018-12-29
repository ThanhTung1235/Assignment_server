using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public MarkType Type { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdateAt { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public MarkStatus Status { get; set; }

        //public void CalculateScore()
        //{
        //    this.Calculate = TotalScore(this.Theory, this.Practice, this.Assignment);
        //}

        //public float TotalScore(int Theory, int Practice, int Assignment)
        //{
        //    return ((Theory * 10 + (Practice + Assignment)*4))/ 2;
        //}
    }

    public enum MarkType
    {
        
    }
    public enum MarkStatus
    {

    }
}
