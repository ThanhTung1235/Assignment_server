﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTManagerSutdent.Data;
using FPTManagerSutdent.Models;
using Microsoft.AspNetCore.Http;

namespace FPTManagerSutdent.Controllers
{
    public class ClassRoomsController : Controller
    {
        private readonly Datacontext _context;

        public ClassRoomsController(Datacontext context)
        {
            _context = context;
        }

        // GET: ClassRooms
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("currentLogin") != null)
            {
                return View(await _context.ClassRoom
                    .Include(c => c.ClassRoomCourses)
                    .ThenInclude(cr => cr.Course)
                    .ToListAsync());
            }
            return Redirect("/Authentication/Login");
        }


        // GET: ClassRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
                if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom
                .Include(c => c.StudentClassRooms)
                .ThenInclude(cr => cr.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // GET: ClassRooms/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreatedAt,UpdatedAt,Status")] ClassRoom classRoom)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            if (ModelState.IsValid)
            {
                _context.Add(classRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classRoom);
        }

        // GET: ClassRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }
            return View(classRoom);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatedAt,UpdatedAt,Status")] ClassRoom classRoom)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }

            if (id != classRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRoomExists(classRoom.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classRoom);
        }

        // GET: ClassRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // POST: ClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }

            var classRoom = await _context.ClassRoom.FindAsync(id);
            _context.ClassRoom.Remove(classRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassRoomExists(int id)
        {
            return _context.ClassRoom.Any(e => e.Id == id);
        }
    }
}
