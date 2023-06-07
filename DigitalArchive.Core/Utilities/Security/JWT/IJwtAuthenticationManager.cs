using DigitalArchive.Core.DbModels;

namespace DigitalArchive.Core.Utilities.Security.JWT
{
    public interface IJwtAuthenticationManager
    {
        AccessToken CreateToken(User user, List<Permission> operationClaims);
    }
}
