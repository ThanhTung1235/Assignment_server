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
    public class MarksController : Controller
    {
        private readonly Datacontext _context;

        public MarksController(Datacontext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            var datacontext = _context.Mark.Include(m => m.Course).Include(m => m.Student);
            return View(await datacontext.ToListAsync());
        }

        // GET: Marks/Details/5
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

            var mark = await _context.Mark
                .Include(m => m.Course)
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Value,CreatedAt,UpdateAt,CourseId,StudentId,Status")] Mark mark)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            var checkMark = _context.Mark.Where(a => a.StudentId == mark.StudentId).Where(m => m.Type == mark.Type)
                .Where(d => d.CourseId == mark.CourseId).FirstOrDefault();
            if (checkMark != null)
            {
                TempData["Fail"] = "Học sinh đã có điểm này";
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                if (mark.Value > 5)
                {
                    mark.Status = MarkStatus.PASS;
                }
                else
                {
                    mark.Status = MarkStatus.FAIL;
                }
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", mark.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", mark.StudentId);
            return View(mark);
        }

        // GET: Marks/Edit/5
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

            var mark = await _context.Mark.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", mark.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", mark.StudentId);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Value,CreatedAt,UpdateAt,CourseId,StudentId,Status")] Mark mark)
        {
            if (HttpContext.Session.GetString("currentLogin") == null)
            {
                return Redirect("/Authentication/Login");
            }
            if (id != mark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", mark.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", mark.StudentId);
            return View(mark);
        }

        // GET: Marks/Delete/5
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

            var mark = await _context.Mark
                .Include(m => m.Course)
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Mark.FindAsync(id);
            _context.Mark.Remove(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(int id)
        {
            return _context.Mark.Any(e => e.Id == id);
        }
    }
}
