using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Extensions;
using DigitalArchive.Core.Utilities.Security.Encryption;
using DigitalArchive.Core.Utilities.Security.JWT.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DigitalArchive.Core.Utilities.Security.JWT
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IJwtConfiguration _jwtConfiguration;

        private DateTime _accessTokenExpiration;
        public JwtAuthenticationManager(IJwtConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration;
        }
        public AccessToken CreateToken(User user, List<Permission> operationClaims)
        {
            _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_jwtConfiguration.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_jwtConfiguration.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_jwtConfiguration, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                ExprationTime = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(IJwtConfiguration jwtConfiguration, User user,
            SigningCredentials signingCredentials, List<Permission> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        //To-Do User ile ilgili başka bir bilgi tutulmak istenirse buraya ekleme yapılır.
        private IEnumerable<Claim> SetClaims(User user, List<Permission> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.Name} {user.Surname}");
            claims.AddPermissions(operationClaims.Select(c => c.Code).ToArray());
            return claims;
        }
    }
}
