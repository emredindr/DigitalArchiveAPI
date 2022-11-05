using DigitalArchive.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalArchive.Core.Utilities.Security.JWT
{
    public interface IJwtAuthenticationManager
    {
        AccessToken CreateToken(User user, List<Permission> operationClaims);
    }
}
