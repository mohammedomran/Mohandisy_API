using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Mohandisy.Models;
using Mohandisy.Services;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace Mohandisy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService emailService;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthController(IAuthService authService, IEmailService emailService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            this.emailService = emailService;
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!_authService.CheckRole(model.RoleId.ToString()))
                return NotFound("Please select valid role");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model, _authService.GetRoleName(model.RoleId.ToString()).ToLower());

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            var applicationUser = new ApplicationUser { Email = model.Email, PhoneNumber = model.PhoneNumber, UserName = model.Username, PasswordHash = model.Password };
            var token = userManager.GenerateEmailConfirmationTokenAsync(applicationUser).Result;

            var newToken = Encoding.UTF8.GetBytes(token);
            string confirmationLink = Url.Action("ConfirmEmail",
              "Account", new
              {
                  userId = result.Id,
                  token = WebEncoders.Base64UrlEncode(newToken)
              });

            await emailService.SendEmailAsync("Email verification", model.Email, model.FirstName+model.LastName, confirmationLink);

            return Ok(new { user = result, status = true, code = 200, msg = "user registered successfully" });
        }
        

        [HttpPost("admin/register")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] JObject data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = data["user"].ToObject<RegisterModel>();
            var type = data["type"].ToString();
            //return Ok(user);
            var result = await _authService.RegisterAdminAsync(user, type);

            /*if (!result.IsAuthenticated)
                return BadRequest(result.Message);*/

            return Ok(new { user = result, status = true, code = 200, msg = "admin registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return Ok(new { status = false, code = 400, msg = ModelState });

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return Ok(new { status = false, code = 400, msg = result.Message });

            return Ok(new { user = result, status = true, code = 200, msg = "user logged in successfully" });
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }
    }
}