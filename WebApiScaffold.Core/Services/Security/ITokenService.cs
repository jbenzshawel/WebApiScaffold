using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace WebApiScaffold.Core.Services.Security
{
    public interface ITokenService
    {
         string GenerateToken(IEnumerable<Claim> claims);
    }
}