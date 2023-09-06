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
    public class skillsController : Controller
    {
        private readonly projectContext _context;

        public skillsController(projectContext context)
        {
            _context = context;
        }

        // GET: skills
        public async Task<IActionResult> Index()
        {
              return _context.Skills != null ? 
                          View(await _context.Skills.ToListAsync()) :
                          Problem("Entity set 'projectContext.Skills'  is null.");
        }

        // GET: skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills
                .FirstOrDefaultAsync(m => m.ski_id == id);
            if (skills == null)
            {
                return NotFound();
            }

            return View(skills);
        }

        // GET: skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ski_id,skill_name,user_id")] skills skills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skills);
        }

        // GET: skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills.FindAsync(id);
            if (skills == null)
            {
                return NotFound();
            }
            return View(skills);
        }

        // POST: skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ski_id,skill_name,user_id")] skills skills)
        {
            if (id != skills.ski_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!skillsExists(skills.ski_id))
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
            return View(skills);
        }

        // GET: skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills
                .FirstOrDefaultAsync(m => m.ski_id == id);
            if (skills == null)
            {
                return NotFound();
            }

            return View(skills);
        }

        // POST: skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Skills == null)
            {
                return Problem("Entity set 'projectContext.Skills'  is null.");
            }
            var skills = await _context.Skills.FindAsync(id);
            if (skills != null)
            {
                _context.Skills.Remove(skills);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool skillsExists(int id)
        {
          return (_context.Skills?.Any(e => e.ski_id == id)).GetValueOrDefault();
        }
    }
}
