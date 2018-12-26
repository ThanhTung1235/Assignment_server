using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FPTManagerSutdent.Data;
using FPTManagerSutdent.Models;

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


        // GET: api/StudentsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
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


        // PUT: api/StudentsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentsAPI
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Student.Update(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}