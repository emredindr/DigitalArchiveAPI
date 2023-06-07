using DigitalArchive.Core.Extensions.ResponseAndExceptionMiddleware;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DigitalArchive.Core.Authorization
{
    public class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsIdentity CheckAndGetUserIdentity()
        {
            var user = _httpContextAccessor.HttpContext.User?.Identity as ClaimsIdentity;
            if (user == null || !user.IsAuthenticated)
                throw new ApiException("Login olan aktif kullanıcı bilgisi bulunamadı");
            return user;
        }

        public int GetCurrentUserId()
        {
            var identity = CheckAndGetUserIdentity();
            var idValue = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(idValue))
                return Convert.ToInt32(idValue);
            return 0;
        }
    }
}
