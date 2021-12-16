using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mohandisy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        public RolesController(ApplicationDbContext applicationDbContext, RoleManager<IdentityRole> roleManager)
        {
            ApplicationDbContext = applicationDbContext;
            RoleManager = roleManager;
        }

        public ApplicationDbContext ApplicationDbContext { get; }
        public RoleManager<IdentityRole> RoleManager { get; }

        [HttpGet]
        public ActionResult<IEnumerable<ApplicationRole>> GetRoles()
        {
            return Ok(ApplicationDbContext.ApplicationRoles.Include("AccountTypes"));
        }

        [HttpPost]
        public ActionResult<IdentityRole> AddRole(string roleName, string arabicName)
        {
            var NewRole = new ApplicationRole { Name = roleName, NormalizedName = roleName.ToUpper(), ArabicName = arabicName };
            var result = ApplicationDbContext.ApplicationRoles.Add(NewRole);
            
            return ApplicationDbContext.SaveChanges()>0 ? Ok(NewRole) : StatusCode(400, "An error happened while saving the role");
        }
    }
}
