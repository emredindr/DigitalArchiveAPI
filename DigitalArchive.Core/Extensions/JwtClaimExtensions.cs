using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DigitalArchive.Core.Extensions
{
    public static class JwtClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddPermissions(this ICollection<Claim> claims, string[] permissions)
        {
            permissions.ToList().ForEach(permission => claims.Add(new Claim(ClaimTypes.Role, permission)));
        }
    }
}
