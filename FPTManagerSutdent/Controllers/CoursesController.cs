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
    public class CoursesController : Controller
    {
        private readonly Datacontext _context;

        public CoursesController(Datacontext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            return View(await _context.Course
                .Include(c => c.ClassRoomCourses)
                .ThenInclude(cr => cr.ClassRoom)
                .ThenInclude(s => s.StudentClassRooms)
                .ToListAsync());
        }

        // GET: Courses/Details/5
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

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            var courses = _context.ClassRoom.ToList();
            ViewData["course"] = courses;
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreatedAt,ExpiredAt,Status")] Course course, int[] courseId)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            if (ModelState.IsValid)
            {
                foreach (var id in courseId)
                {
                    var courseClass = _context.ClassRoom.Find(id);
                    ClassRoomCourse CourseCategory = new ClassRoomCourse()
                    {
                        ClassRoom = courseClass,
                        Course = course
                    };
                    _context.Add(CourseCategory);
                }
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
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

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatedAt,ExpiredAt,Status")] Course course)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            return View(course);
        }

        // GET: Courses/Delete/5
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

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }
    }
}
