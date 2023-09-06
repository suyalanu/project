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
    public class projectsController : ControllerBase
    {
        private readonly projectContext _context;

        public projectsController(projectContext context)
        {
            _context = context;
        }

       

        // GET: api/projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult <List <projects>>> Getprojects(int id)
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.Where(r=>r.user_id == id).ToListAsync();

            if (projects == null)
            {
                return NotFound();
            }

            return projects;
        }
    }
}

