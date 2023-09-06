using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Helpers;
using project.Models;

namespace project.APIControllers
{
    [APIKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class certificatesController : ControllerBase
    {
        private readonly projectContext _context;

        public certificatesController(projectContext context)
        {
            _context = context;
        }



        // GET: api/certificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult <List <certificates>>> Getcertificates(int id)
        {
            if (_context.Certificates == null)
            {
                return NotFound();
            }
            var certificates = await _context.Certificates.Where(r => r.user_id == id).ToListAsync();

            if (certificates == null)
            {
                return NotFound();
            }

            return certificates;
        }

    }
}