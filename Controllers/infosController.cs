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
    public class infosController : Controller
    {
        private readonly projectContext _context;

        public infosController(projectContext context)
        {
            _context = context;
        }

        // GET: infos
        public async Task<IActionResult> Index()
        {
              return _context.Infos != null ? 
                          View(await _context.Infos.ToListAsync()) :
                          Problem("Entity set 'projectContext.Infos'  is null.");
        }

        // GET: infos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Infos == null)
            {
                return NotFound();
            }

            var infos = await _context.Infos
                .FirstOrDefaultAsync(m => m.user_id == id);
            if (infos == null)
            {
                return NotFound();
            }

            return View(infos);
        }

        // GET: infos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: infos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("user_id,name,password,summary,address,email,phone_no,linkedin")] infos infos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infos);
        }

        // GET: infos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Infos == null)
            {
                return NotFound();
            }

            var infos = await _context.Infos.FindAsync(id);
            if (infos == null)
            {
                return NotFound();
            }
            return View(infos);
        }

        // POST: infos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("user_id,name,password,summary,address,email,phone_no,linkedin")] infos infos)
        {
            if (id != infos.user_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!infosExists(infos.user_id))
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
            return View(infos);
        }

        // GET: infos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Infos == null)
            {
                return NotFound();
            }

            var infos = await _context.Infos
                .FirstOrDefaultAsync(m => m.user_id == id);
            if (infos == null)
            {
                return NotFound();
            }

            return View(infos);
        }

        // POST: infos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Infos == null)
            {
                return Problem("Entity set 'projectContext.Infos'  is null.");
            }
            var infos = await _context.Infos.FindAsync(id);
            if (infos != null)
            {
                _context.Infos.Remove(infos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool infosExists(int id)
        {
          return (_context.Infos?.Any(e => e.user_id == id)).GetValueOrDefault();
        }
    }
}
