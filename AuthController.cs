using Authorization___Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace Authorization___Authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new();

        [HttpPost("register")]
        public IActionResult Register(AuthRequest request)
        {
            if (users.Any(x => x.Username == request.Username))
                return BadRequest("User already exists");

            users.Add(new User
            {
                Username = request.Username,
                PasswordHash = HashPassword(request.Password),
                Role = request.Role
            });

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(AuthRequest request)
        {
            var password = HashPassword(request.Password);
            var user = users.FirstOrDefault(u =>
                u.Username == request.Username &&
                u.PasswordHash == password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                Token = token
            });
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok("Authenticated User");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult Admin()
        {
            return Ok("Welcome Admin");
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey123456789012345"));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "MyAuthServer",
                audience: "MyAuthClient",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }

        private string HashPassword(string password)
        {
            using SHA256 sha = SHA256.Create();

            byte[] bytes =
                sha.ComputeHash(
                    Encoding.UTF8.GetBytes(password));

            return Convert.ToHexString(bytes);
        }
    }
}
