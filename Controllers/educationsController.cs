using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{
    public class educationsController : Controller
    {
        private readonly projectContext _context;

        public educationsController(projectContext context)
        {
            _context = context;
        }

        // GET: educations
        public async Task<IActionResult> Index()
        {
              return _context.Educations != null ? 
                          View(await _context.Educations.ToListAsync()) :
                          Problem("Entity set 'projectContext.Educations'  is null.");
        }

        // GET: educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Educations == null)
            {
                return NotFound();
            }

            var educations = await _context.Educations
                .FirstOrDefaultAsync(m => m.edu_id == id);
            if (educations == null)
            {
                return NotFound();
            }

            return View(educations);
        }

        // GET: educations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: educations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("edu_id,college_name,starteded_date,end_date,board,degree,user_id")] educations educations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educations);
        }

        // GET: educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Educations == null)
            {
                return NotFound();
            }

            var educations = await _context.Educations.FindAsync(id);
            if (educations == null)
            {
                return NotFound();
            }
            return View(educations);
        }

        // POST: educations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("edu_id,college_name,starteded_date,end_date,board,degree,user_id")] educations educations)
        {
            if (id != educations.edu_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!educationsExists(educations.edu_id))
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
            return View(educations);
        }

        // GET: educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Educations == null)
            {
                return NotFound();
            }

            var educations = await _context.Educations
                .FirstOrDefaultAsync(m => m.edu_id == id);
            if (educations == null)
            {
                return NotFound();
            }

            return View(educations);
        }

        // POST: educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Educations == null)
            {
                return Problem("Entity set 'projectContext.Educations'  is null.");
            }
            var educations = await _context.Educations.FindAsync(id);
            if (educations != null)
            {
                _context.Educations.Remove(educations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool educationsExists(int id)
        {
          return (_context.Educations?.Any(e => e.edu_id == id)).GetValueOrDefault();
        }
    }
}
