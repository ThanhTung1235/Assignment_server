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
            this.Practice = 0;
            this.Theory = 0;
            this.Assignment = 0;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public int Theory { get; set; }
        [Required]
        public int Practice { get; set; }
        [Required]
        public int Assignment { get; set; }
        [Required]
        public float Calculate { get; set; }
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

        public void CalculateScore()
        {
            this.Calculate = TotalScore(this.Theory, this.Practice, this.Assignment);
        }
        
        public float TotalScore(int Theory, int Practice, int Assignment)
        {
            return ((Theory * 10 + (Practice + Assignment)*4))/ 2;
        }
    }
}
