using WebApiScaffold.Core.Models.DTO.Security;

namespace WebApiScaffold.Core.Services.Security
{
    public interface IUserService
    {
        UserDTO Authenticate(AuthenticationDTO dto);
    }
}