using System.Security.Claims;
using WebApiScaffold.Core.Models.DTO.Security;

namespace WebApiScaffold.Core.Services.Security
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;

        public UserService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public UserDTO Authenticate(AuthenticationDTO dto) 
        {
            var user = new UserDTO 
            {
                UserName = dto.UserName
            };

            // TODO: Update to actually authenticate user 
            if (true) 
            {
                // TODO: Add additional claims as needed and set other UserDTO properties
                var claims = new Claim[] 
                {
                    new Claim(ClaimTypes.Name, dto.UserName)
                };

                user.Token = _tokenService.GenerateToken(claims);
            }

            return user;
        }
    }
}