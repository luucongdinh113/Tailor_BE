using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
            var user = await _context.Users.FirstOrDefaultAsync(c => c.UserName.Equals(userInfo.UserName) && c.PassWord.Equals(userInfo.PassWord))
                ?? throw new Exception($"Can't find User has UserName {userInfo.UserName} and Password {userInfo.PassWord}");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));;
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var role = user.IsAdmin ? "Admin" : "User";

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim("DateOfJoing", user.DateOfJoing.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
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
