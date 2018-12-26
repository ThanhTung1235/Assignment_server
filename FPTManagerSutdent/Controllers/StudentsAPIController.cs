using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FPTManagerSutdent.Data;
using FPTManagerSutdent.Models;
using System.Net;

namespace FPTManagerSutdent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsAPIController : ControllerBase
    {
        private readonly Datacontext _context;

        public StudentsAPIController(Datacontext context)
        {
            _context = context;
        }

        // GET: api/StudentsAPI
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            return _context.Student;
        }

        // Thông tin sinh viên theo Id
        // GET: api/StudentsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var basicToken = Request.Headers["Authorization"].ToString();
            var token = basicToken.Replace("Basic ", "");
            var existToken = _context.MyCredentials.SingleOrDefault(a => a.AccessToken == token);
            if (existToken != null)
            {
                var student = await _context.Student.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return new JsonResult("Not Found");
            
        }


        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existStudent = _context.Student.SingleOrDefault(a => a.Email == account.Email);
            if (existStudent == null)
            {
                Response.StatusCode = 403;
                return new JsonResult("Forbidden1");
            }

            var isValidPassword = existStudent.CheckLoginPassword(account.Password);
            if (isValidPassword)
            {
                MyCredential credential = new MyCredential(existStudent.Id);
                _context.MyCredentials.Add(credential);
                _context.SaveChanges();
                Response.StatusCode = 200;
                return new JsonResult(credential);
            }
            Response.StatusCode = 403;
            return new JsonResult("Forbidden2");
        }

        //Sửa thông tin sinh viên
        [HttpPost("change-information")]        public async Task<IActionResult> ChangeInformation(Student student)        {            if (!ModelState.IsValid)            {                return new JsonResult("BadRequest");            }            var basicToken = Request.Headers["Authorization"].ToString();            var token = basicToken.Replace("Basic ", "");            var existToken = _context.MyCredentials.SingleOrDefault(a => a.AccessToken == token);            if (existToken != null)            {                var existAccount = _context.Student.SingleOrDefault(i => i.Id == existToken.OwnerId);                if (existAccount != null)                {                        var email = student.Email;
                        existAccount.Address = email;

                        var name = student.Name;
                        existAccount.Name = name;

                        var phone = student.Phone;                        existAccount.Phone = phone;                        var address = student.Address;                        existAccount.Address = address;

                        var dob = student.DoB;
                        existAccount.DoB = dob;

                        var gender = student.Gender;
                        existAccount.Gender = gender;

                        _context.Student.Update(existAccount);                        _context.SaveChanges();                        Response.StatusCode = (int)HttpStatusCode.OK;                        return new JsonResult(existAccount);                }                return new JsonResult(existAccount);            }            Response.StatusCode = (int)HttpStatusCode.Forbidden;            return new JsonResult("Forbidden");        }

        // Lấy danh sách học sinh trong lớp
        [HttpGet("ListStudentInClass")]
        public IEnumerable<ClassRoom> ListStudent(int classroom)
        {
            return _context.ClassRoom.Where(c => c.Id == classroom).Include(s => s.StudentClassRooms).ToList();
        }


        //[HttpPost("ListStudentInClass")]
        //public async Task<IActionResult> ListStudentInClass(Student student)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }classRoomId
        //    var existToken = _context.MyCredentials.SingleOrDefault(a => a.AccessToken == token);
        //    if (existToken != null)
        //    {
        //        var existAccount = _context.Student.SingleOrDefault(i => i.Id == existToken.OwnerId);
        //        if (existAccount != null)
        //        {
        //        }
        //    }
        //    Response.StatusCode = (int)HttpStatusCode.Forbidden;
        //    return new JsonResult("Not Found");
        //}

    }
}