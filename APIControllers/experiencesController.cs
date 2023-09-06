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
    public class experiencesController : ControllerBase
    {
        private readonly projectContext _context;

        public experiencesController(projectContext context)
        {
            _context = context;
        }

    

        // GET: api/experiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<experiences>>> Getexperiences(int id)
        {
            if (_context.Experiences == null)
            {
                return NotFound();
            }
            var experiences = await _context.Experiences.Where(r => r.user_id == id).ToListAsync();

            if (experiences == null)
            {
                return NotFound();
            }

            return experiences;
        }
    }
}

