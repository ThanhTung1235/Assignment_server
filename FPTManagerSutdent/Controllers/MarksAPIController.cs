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
    public class MarksAPIController : ControllerBase
    {
        private readonly Datacontext _context;

        public MarksAPIController(Datacontext context)
        {
            _context = context;
        }

        // GET: api/MarksAPI
        [HttpGet]
        public IEnumerable<Mark> GetMark(int studentId, int courseId)
        {
            return _context.Mark.Where(m => m.Id == studentId && m.CourseId == courseId).ToList();
        }

        // GET: api/MarksAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMark([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mark = await _context.Mark.FindAsync(id);

            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }

        // PUT: api/MarksAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMark([FromRoute] int id, [FromBody] Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mark.Id)
            {
                return BadRequest();
            }

            _context.Entry(mark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkExists(id))
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

        // POST: api/MarksAPI
        [HttpPost]
        public async Task<IActionResult> PostMark([FromBody] Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mark.Add(mark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMark", new { id = mark.Id }, mark);
        }

        // DELETE: api/MarksAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMark([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mark = await _context.Mark.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }

            _context.Mark.Remove(mark);
            await _context.SaveChangesAsync();

            return Ok(mark);
        }

        private bool MarkExists(int id)
        {
            return _context.Mark.Any(e => e.Id == id);
        }
    }
}