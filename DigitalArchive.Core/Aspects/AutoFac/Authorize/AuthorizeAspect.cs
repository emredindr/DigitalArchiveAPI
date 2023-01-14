using Castle.DynamicProxy;
using DigitalArchive.Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DigitalArchive.Core.Aspects.AutoFac.Authorize
{
    public class AuthorizeAspect : MethodInterception
    {
        private readonly string[] _permissions;
        public AuthorizeAspect(params string[] permissions)
        {
            _permissions = permissions;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var _httpContext = new HttpContextAccessor().HttpContext;
            var identity = _httpContext.User.Identity as ClaimsIdentity;
            var userPermissions = identity.FindAll(ClaimTypes.Role).Select(x => x.Value.ToString());

            foreach (var permission in _permissions)
                if (userPermissions.Contains(permission))
                    return;

            throw new Exception("Bu işlem için yetkiniz bulunmamaktadır");
        }
    }
}
