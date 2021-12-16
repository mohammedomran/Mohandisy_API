using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Mohandisy.Models;
using Mohandisy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohandisy.Controllers
{
    [Route("[controller]/ConfirmEmail")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public IApplicationUserService ApplicationUserService { get; }

        public AccountController(UserManager<ApplicationUser> userManager, IApplicationUserService applicationUserService)
        {
            UserManager = userManager;
            ApplicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<ActionResult<bool>> ConfirmEmail(string userId, string token)
        {
            var newToken = WebEncoders.Base64UrlDecode(token);
            /*var normalToken = Encoding.UTF8.GetString(token);*/

            var applicationUser = ApplicationUserService.GetApplicationUser(userId);

            var result = await UserManager.ConfirmEmailAsync(applicationUser, newToken.ToString());
            return Ok(result);
        }
    }
}
