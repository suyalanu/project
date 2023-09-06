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
    public class certificatesController : Controller
    {
        private readonly projectContext _context;

        public certificatesController(projectContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
              return _context.Certificates != null ? 
                          View(await _context.Certificates.ToListAsync()) :
                          Problem("Entity set 'projectContext.Certificates'  is null.");
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Certificates == null)
            {
                return NotFound();
            }

            var certificates = await _context.Certificates
                .FirstOrDefaultAsync(m => m.certif_id == id);
            if (certificates == null)
            {
                return NotFound();
            }

            return View(certificates);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("certif_id,title,issued_name,link,issued_date,user_id")] certificates certificates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificates);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Certificates == null)
            {
                return NotFound();
            }

            var certificates = await _context.Certificates.FindAsync(id);
            if (certificates == null)
            {
                return NotFound();
            }
            return View(certificates);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("certif_id,title,issued_name,link,issued_date,user_id")] certificates certificates)
        {
            if (id != certificates.certif_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!certificatesExists(certificates.certif_id))
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
            return View(certificates);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Certificates == null)
            {
                return NotFound();
            }

            var certificates = await _context.Certificates
                .FirstOrDefaultAsync(m => m.certif_id == id);
            if (certificates == null)
            {
                return NotFound();
            }

            return View(certificates);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Certificates == null)
            {
                return Problem("Entity set 'projectContext.Certificates'  is null.");
            }
            var certificates = await _context.Certificates.FindAsync(id);
            if (certificates != null)
            {
                _context.Certificates.Remove(certificates);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool certificatesExists(int id)
        {
          return (_context.Certificates?.Any(e => e.certif_id == id)).GetValueOrDefault();
        }
    }
}
