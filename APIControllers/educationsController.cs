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
    public class educationsController : ControllerBase
    {
        private readonly projectContext _context;

        public educationsController(projectContext context)
        {
            _context = context;
        }

        
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<educations>>> GetEducations()
        //{
        //  if (_context.Educations == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Educations.ToListAsync();
        //}

        
        [HttpGet("{id}")]
        public async Task<ActionResult <List <educations>>> Geteducations(int id)
        {
          if (_context.Educations == null)
          {
              return NotFound();
          }
            var educations = await _context.Educations.Where(r => r.user_id == id).ToListAsync();

            if (educations == null)
            {
                return NotFound();
            }

            return educations;
        }

        
    }
}
