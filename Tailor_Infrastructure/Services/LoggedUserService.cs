using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure.Services
{
    public class LoggedUserService : ILoggedUserService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public LoggedUserService(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext != null)
            {
                ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;
                if (user != null)
                {
                    UserName = user.FindFirst("UserName") != null ? user.FindFirst("UserName")!.Value : "";
                }
            }
        }
        public string UserName { get; } = default!;
    }
    public class UserInfor
    {
        public string UserName { get; set; } = default!;
    }
}
