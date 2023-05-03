using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KilimoSchoolSystem.Data;
using KilimoSchoolSystem.Models;
using Stream = KilimoSchoolSystem.Models.Stream;
using KilimoSchoolSystem.ViewModels;

namespace KilimoSchoolSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStreamRepository _streamRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly KilimoSchoolSystemContext _context;


        public StudentsController(IStreamRepository streamRepository, IStudentRepository studentRepository, KilimoSchoolSystemContext context)
        {
            _streamRepository = streamRepository;
            _studentRepository = studentRepository;
            _context = context;
        }

        // List All the streams
        public ViewResult List(string stream)
        {
            IEnumerable<Student> students;
            string currentStream;

            if (string.IsNullOrEmpty(stream))
            {
                students = _studentRepository.AllStudents;
                currentStream = "All Students";
            }
            else
            {
                students = _studentRepository.AllStudents.Where(p => p.Stream.StreamName == stream)
                    .OrderBy(p => p.StudentId);
                currentStream = _streamRepository.AllStreams.FirstOrDefault(c => c.StreamName == stream).StreamName;
            }
            return View(new StudentViewModel
            {
                Students = students,
                CurrentStream = currentStream,
            });
        }
        


        // GET: Students
        public async Task<IActionResult> Index()
        {
            var kilimoSchoolSystemContext = _context.Student.Include(s => s.Stream);
            return View(await kilimoSchoolSystemContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Stream)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["StreamId"] = new SelectList(_context.Set<Stream>(), "StreamId", "StreamId");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,AdmissionNumber,DOB,StreamId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StreamId"] = new SelectList(_context.Set<Stream>(), "StreamId", "StreamId", student.StreamId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["StreamId"] = new SelectList(_context.Set<Stream>(), "StreamId", "StreamId", student.StreamId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,AdmissionNumber,DOB,StreamId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["StreamId"] = new SelectList(_context.Set<Stream>(), "StreamId", "StreamId", student.StreamId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Stream)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'KilimoSchoolSystemContext.Student'  is null.");
            }
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Student?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
