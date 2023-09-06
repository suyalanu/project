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
    public class experiencesController : Controller
    {
        private readonly projectContext _context;

        public experiencesController(projectContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
              return _context.Experiences != null ? 
                          View(await _context.Experiences.ToListAsync()) :
                          Problem("Entity set 'projectContext.Experiences'  is null.");
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Experiences == null)
            {
                return NotFound();
            }

            var experiences = await _context.Experiences
                .FirstOrDefaultAsync(m => m.exp_id == id);
            if (experiences == null)
            {
                return NotFound();
            }

            return View(experiences);
        }

        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("exp_id,institution_name,starteded_date,end_date,position,tech_used,user_id")] experiences experiences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiences);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Experiences == null)
            {
                return NotFound();
            }

            var experiences = await _context.Experiences.FindAsync(id);
            if (experiences == null)
            {
                return NotFound();
            }
            return View(experiences);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("exp_id,institution_name,starteded_date,end_date,position,tech_used,user_id")] experiences experiences)
        {
            if (id != experiences.exp_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!experiencesExists(experiences.exp_id))
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
            return View(experiences);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Experiences == null)
            {
                return NotFound();
            }

            var experiences = await _context.Experiences
                .FirstOrDefaultAsync(m => m.exp_id == id);
            if (experiences == null)
            {
                return NotFound();
            }

            return View(experiences);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Experiences == null)
            {
                return Problem("Entity set 'projectContext.Experiences'  is null.");
            }
            var experiences = await _context.Experiences.FindAsync(id);
            if (experiences != null)
            {
                _context.Experiences.Remove(experiences);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool experiencesExists(int id)
        {
          return (_context.Experiences?.Any(e => e.exp_id == id)).GetValueOrDefault();
        }
    }
}
