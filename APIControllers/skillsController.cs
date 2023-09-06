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
    public class skillsController : ControllerBase
    {
        private readonly projectContext _context;

        public skillsController(projectContext context)
        {
            _context = context;
        }

        //// GET: api/skills
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<skills>>> GetSkills()
        //{
        //    if (_context.Skills == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Skills.ToListAsync();
        //}

        // GET: api/skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult <List <skills>>> Getskills(int id)
        {
            if (_context.Skills == null)
            {
                return NotFound();
            }
            var skills = await _context.Skills.Where(r => r.user_id == id).ToListAsync();

            if (skills == null)
            {
                return NotFound();
            }

            return skills;
        }

    }
}