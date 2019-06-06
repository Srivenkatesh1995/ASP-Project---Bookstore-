using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ANVBookstore.Models;

namespace ANVBookstore.Controllers
{
    public class CoursesController : Controller
    {
        private readonly Team117DBContext _context;

        public CoursesController(Team117DBContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Course.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName,CourseProf")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                TempData["message"] = $"{course.CourseName} has been added";
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CourseId,CourseName,CourseProf")] Course course)
        {
            if (id != course.CourseId)
            {
                return RedirectToAction(nameof(Index));
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
                    if (!CourseExists(course.CourseId))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["message"] = $"{course.CourseName} has failed";
                        return RedirectToAction(nameof(Index));
                    }

                    
                }
                TempData["message"] = $"{course.CourseName} update Completed";
                return RedirectToAction(nameof(Index));
                
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            TempData["message"] = $"{course.CourseName} Deletion Completed";
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(string id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
