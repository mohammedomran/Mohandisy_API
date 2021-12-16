using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Mohandisy.Models;
using Mohandisy.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mohandisy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApplicationUsersController : ControllerBase
    {
        private IConfiguration Configuration;
        private readonly IApplicationUserService _service;
        private readonly ApplicationDbContext _context;


        public ApplicationUsersController(IApplicationUserService service, IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
            Configuration = configuration;
            _service = service;
        }
        [Authorize]
        [HttpGet("currentuser")]
        public IActionResult GetCurrentUser([FromForm] Object  model)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var applicationUser = _context.ApplicationUsers.FirstOrDefault(q => q.UserName == user);

            return Ok(
            new {
                user = user,
                data = applicationUser,
                email = Email
            });
        }
        // GET: api/<CoursesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public ActionResult<IEnumerable<ApplicationUser>> GetApplicationUsers()
        {
            var users = _service.GetApplicationUsers();

            return Ok(new { users = users, status = true, code = 200, msg = "get users successfully" });
        }

        // GET: api/<CoursesController>
        [HttpGet("type")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<ApplicationUser>> GetApplicationUsersByType(string type)
        {
            if (type == null)
            {
                return Ok(0);
            }
            var users = _service.GetApplicationUsersByType(type);

            return Ok(new { users = users, status = true, code = 200, msg = "get users successfully" });
        }


        // POST api/<CoursesController>
        [HttpPost]
        public ActionResult<ApplicationUser> AddCourse([FromBody] ApplicationUser course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var new_course = _service.AddApplicationUser(course);
            return Ok(new_course);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public ActionResult<ApplicationUser> UpdateCourse([FromBody] ApplicationUser course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated_course = _service.UpdatelicationUser(course);
            return Ok(course);

        }

        // DELETE api/<CoursesController>/5
        [HttpDelete()]
        public ActionResult<ApplicationUser> DeleteApplicationUser(string id)
        {
            if (id == null || id=="" || id==string.Empty)
            {
                return Ok(555);
            }

            var applicationUser = _service.DeleteApplicationUser(id);
            return Ok(new { user = applicationUser, status = true, code = 200, msg = "user deleted successfully" });

        }

        // Post api/<CoursesController>/data
        [HttpGet("search")]
        public ActionResult<ApplicationUser> SearchForUser(string data)
        {
            if (data == null)
            {
                return Ok(0);
            }

            var result = _service.SearchForUsers(data);
            return Ok(new { users = result, status = true, code = 200, msg = "get users successfully" });
        }
    }
}
