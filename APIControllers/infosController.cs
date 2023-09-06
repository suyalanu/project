using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using project.Data;
using project.Helpers;
using project.Models;

namespace project.APIControllers
{
    //[APIKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class infosController : ControllerBase
    {
        private readonly projectContext _context;

        public infosController(projectContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("~/api/login")]
        public async Task<ActionResult<infos>> Getinfos()
        {
            HttpContext.Request.Headers.TryGetValue("userEmail", out var UserEmail);
            HttpContext.Request.Headers.TryGetValue("password", out var Password);

            if (string.IsNullOrEmpty(UserEmail) && string.IsNullOrEmpty(Password))
            {
                return BadRequest("Email and password are required");
            }
            if (_context.Infos == null)
            {
                return NotFound("empty");
            }
            var info = await _context.Infos.Where(info => info.email == UserEmail.ToString()).FirstAsync();
            if (info == null)
            {
                return NotFound();
            }
            if (info.password != Password.ToString())
            {
                return NotFound("empty");
            }
            return info;
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<infos>> Getinfos(int id)
        //{
        //    var info = await _context.Infos.Where(info => info.user_id == id).FirstOrDefaultAsync();
        //    if (info == null)
        //    {
        //        return NotFound();
        //    }
        //    return info;
        //}


    }
}
