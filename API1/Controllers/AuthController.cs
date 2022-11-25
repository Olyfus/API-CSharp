using API1.Dto.User;
using API1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Roles> _roleManager;

        public AuthController(UserManager<User> userManager, RoleManager<Roles> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDto userSignUpDto)
        {
            var user = new User
            {
                Email = userSignUpDto.Email,
                LastName = userSignUpDto.LastName,
                FirstName = userSignUpDto.FirstName,
            };

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpDto.Password);

            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }
            return Problem(userCreateResult.Errors.First().Description, null, 400);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == userLoginDto.Email);
            if (user == null)
            {
                return NotFound("L'utilisateur n'existe pas.");
            }
            var userLogininResult = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);
            if (userLogininResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(new
                {
                    token = GenerateJwt(user, roles)
                });
            }
            return BadRequest("Mot de passe incorrect.");
        }

        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Le nom du Role est vide");
            }
            var newRole = new Roles
            {
                Name = roleName
            };

            var roleResult = await _roleManager.CreateAsync(newRole);
            if (roleResult.Succeeded)
            {
                return Ok();
            }
            return Problem(roleResult.Errors.First().Description, null, 500);
        }

        [HttpPost("user/{userMail}/role")]

        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok();
            }
            return Problem(result.Errors.First().Description, null, 500);
        }
    }
}
