using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure.Services
{
    public class JWTSerivce : IJWTService
    {
        private readonly IConfiguration _config;
        private readonly TaiLorContext _context;
        public JWTSerivce(IConfiguration configuration, TaiLorContext context)
        {
            _config = configuration;
           _context = context;
        }
        public async Task<string> GenerateJSONWebToken(UserModel userInfo)
        {
            var user=await _context.Users.FirstOrDefaultAsync(c => c.UserName.Equals(userInfo.UserName))
               ?? throw new Exception($"UserName: {userInfo.UserName} is InValid");
            if(!PasswordHasher.VerifyPassword(user.PassWord, userInfo.PassWord)) throw new Exception($"Password: {userInfo.PassWord} is InValid");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));;
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var role = user.IsAdmin ? "Admin" : "User";

            var claims = new[] {
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("DateOfJoing", user.DateOfJoing.ToString("yyyy-MM-dd")),
                new Claim(ClaimTypes.Role,role),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}")
            };

            var token = new JwtSecurityToken(
                issuer:_config["Jwt:Issuer"],
                audience:_config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    public class UserModel
    {
        public string UserName { get; set; } = default!;
        public string PassWord { get; set; } = default!;
    } 
}
