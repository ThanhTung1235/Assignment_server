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
    public class ClassRoomsAPIController : ControllerBase
    {
        private readonly Datacontext _context;

        public ClassRoomsAPIController(Datacontext context)
        {
            _context = context;
        }

        // GET: api/ClassRoomsAPI
        [HttpGet]
        public IEnumerable<ClassRoom> GetClassRoom()
        {
            return _context.ClassRoom;
        }

        // GET: api/ClassRoomsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classRoom = await _context.ClassRoom.FindAsync(id);

            if (classRoom == null)
            {
                return NotFound();
            }

            return Ok(classRoom);
        }

        // PUT: api/ClassRoomsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassRoom([FromRoute] int id, [FromBody] ClassRoom classRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(classRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassRoomExists(id))
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

        // POST: api/ClassRoomsAPI
        [HttpPost]
        public async Task<IActionResult> PostClassRoom([FromBody] ClassRoom classRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ClassRoom.Add(classRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassRoom", new { id = classRoom.Id }, classRoom);
        }

        // DELETE: api/ClassRoomsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classRoom = await _context.ClassRoom.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }

            _context.ClassRoom.Remove(classRoom);
            await _context.SaveChangesAsync();

            return Ok(classRoom);
        }

        private bool ClassRoomExists(int id)
        {
            return _context.ClassRoom.Any(e => e.Id == id);
        }
    }
}