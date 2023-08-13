using Tailor_Infrastructure.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Tailor_Infrastructure.Services
{
    public class LoggedUserService : ILoggedUserService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public LoggedUserService(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
            string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            UserId = userInfor.UserId;
            UserName = userInfor.UserName;
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
