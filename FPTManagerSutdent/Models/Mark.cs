using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTManagerSutdent.Models
{
    public class Mark
    {
        public static int MAX_THEORY = 10;
        public static int MAX_PRATICE = 15;
        private static int MAX_ASSIGNMENT = 10;
        [Key]
        public int Id { get; set; }
        public MarkType Type { get; set; }
        public int Value { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdateAt { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public MarkStatus Status { get; set; }


        public Mark()
        {
            this.Value = 0;
            this.Type = MarkType.THEORY;
            this.calculateMarkStatus();
            this.CreatedAt = DateTime.Now;
            this.UpdateAt = DateTime.Now;
        }

        public Mark(MarkType type, int value)
        {
            this.Value = value;
            this.Type = type;
            this.calculateMarkStatus();
            this.CreatedAt = DateTime.Now;
            this.UpdateAt = DateTime.Now;
        }

        public void calculateMarkStatus() {
            int maximum = 0;
            if (this.Type == MarkType.THEORY)
            {
                maximum = MAX_THEORY;
            }
            else if (this.Type == MarkType.PRATICE)
            {
                maximum = MAX_PRATICE;
            }
            else if (this.Type == MarkType.ASSIGNMENT)
            {
                maximum = MAX_ASSIGNMENT;
            }
            this.Status = (this.Value / maximum) * 100 >= 40 ? MarkStatus.PASS : MarkStatus.FAIL;
        }

    }

    public enum MarkType
    {
        THEORY = 1,
        PRATICE = 2,
        ASSIGNMENT = 3
    }
    public enum MarkStatus
    {
        PASS = 1,
        FAIL = 0
    }
}
