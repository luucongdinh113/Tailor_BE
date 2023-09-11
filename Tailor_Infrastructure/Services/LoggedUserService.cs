using Tailor_Infrastructure.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Tailor_Domain.Entities;

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
                    UserId = user.FindFirst(ClaimTypes.NameIdentifier) != null ? new Guid(user.FindFirst(ClaimTypes.NameIdentifier)!.Value) : new Guid();
                    UserName = user.FindFirst(ClaimTypes.Name) != null ? user.FindFirst(ClaimTypes.Name)!.Value : "";
                }
            }
        }

        public Guid UserId { get; }

        public string UserName { get; } = default!;
    }
    public class UserInfor
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = default!;
    }
}
