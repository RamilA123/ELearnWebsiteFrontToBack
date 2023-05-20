﻿using ELearn.Data;
using ELearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELearn.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await _context.Courses.Include(m=>m.Author).Include(m=>m.CourseImages).Take(3).ToListAsync();
            int count = await _context.Courses.CountAsync();
            ViewBag.courseCount = count;
            return View(courses);
        }
        [HttpGet]
        public async Task<IActionResult> ShowMoreOrLess(int skip)
        {
            IEnumerable<Course> courses = await _context.Courses.Include(m => m.CourseImages).Include(m=>m.Author).Skip(skip).Take(3).ToListAsync();

            return PartialView("_CoursePartial", courses);
        }
    }
}
