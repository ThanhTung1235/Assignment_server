using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Min Length Of 3 And Max Length Of 30")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
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
