using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class Student
    {
        private readonly MD5 _algorithm = MD5.Create();

        public Student()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = StudentStatus.Active;
            this.Gender = GenderStudent.Male;
        }

        public Student(int Id)
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = StudentStatus.Active;
            this.Gender = GenderStudent.Male;
        }

        [Key]
        [Display(Name = "Roll Number")]
        [Required(ErrorMessage = "The Roll Number is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Min Length Of 3 And Max Length Of 30")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public GenderStudent Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
        public StudentStatus Status { get; set; }
        public List<Mark> Marks { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        [Display(Name = "Class Room")]
        public List<StudentClassRoom> StudentClassRooms { get; set; }


        public void GenerateSalt()
        {
            this.Salt = Guid.NewGuid().ToString();
        }

        // mã hóa mật khẩu kèm theo muối. Lưu ý là mật khẩu với muối đều có trong đối tượng hiện tại.
        public void EncryptPassword()
        {
            this.Password += this.Salt;
            this.Password = EncryptString(this.Password);
        }

        // mã hóa chuỗi sử dụng thuật toán đã tạo ở trên.
        public string EncryptString(string stringToEncrypt)
        {
            var hash = _algorithm.ComputeHash(Encoding.UTF8.GetBytes(stringToEncrypt));
            return Convert.ToBase64String(hash);
        }

        // kiểm tra so sánh thông tin mật khẩu khi login, mật khẩu này sẽ được mã hóa
        // kèm muối ở trong database và so sanh với mật khẩu đã mã hóa trước đó.
        public bool CheckLoginPassword(string loginPassword)
        {
            loginPassword += this.Salt;
            loginPassword = EncryptString(loginPassword);
            return loginPassword == this.Password;
        }
    }
    
    public enum StudentStatus
    {
        Active = 1,
        Deactive = 0
    }

    public enum GenderStudent
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}
