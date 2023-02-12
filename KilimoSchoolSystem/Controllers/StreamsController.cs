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
    public class StreamsController : Controller
    {
        private readonly KilimoSchoolSystemContext _context;


        public StreamsController(KilimoSchoolSystemContext context)
        {
            _context = context;
        }
 
        // GET: Streams
        public async Task<IActionResult> Index()
        {
              return _context.Stream != null ? 
                          View(await _context.Stream.ToListAsync()) :
                          Problem("Entity set 'KilimoSchoolSystemContext.Stream'  is null.");
        }

        // GET: Streams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stream == null)
            {
                return NotFound();
            }

            var stream = await _context.Stream
                .FirstOrDefaultAsync(m => m.StreamId == id);
            if (stream == null)
            {
                return NotFound();
            }

            return View(stream);
        }

        // GET: Streams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Streams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreamId,StreamName")] Stream stream)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stream);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stream);
        }

        // GET: Streams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stream == null)
            {
                return NotFound();
            }

            var stream = await _context.Stream.FindAsync(id);
            if (stream == null)
            {
                return NotFound();
            }
            return View(stream);
        }

        // POST: Streams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StreamId,StreamName")] Stream stream)
        {
            if (id != stream.StreamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stream);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreamExists(stream.StreamId))
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
            return View(stream);
        }

        // GET: Streams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stream == null)
            {
                return NotFound();
            }

            var stream = await _context.Stream
                .FirstOrDefaultAsync(m => m.StreamId == id);
            if (stream == null)
            {
                return NotFound();
            }

            return View(stream);
        }

        // POST: Streams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stream == null)
            {
                return Problem("Entity set 'KilimoSchoolSystemContext.Stream'  is null.");
            }
            var stream = await _context.Stream.FindAsync(id);
            if (stream != null)
            {
                _context.Stream.Remove(stream);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreamExists(int id)
        {
          return (_context.Stream?.Any(e => e.StreamId == id)).GetValueOrDefault();
        }
    }
}
