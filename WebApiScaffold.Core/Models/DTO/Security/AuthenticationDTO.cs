using System.ComponentModel.DataAnnotations;

namespace WebApiScaffold.Core.Models.DTO.Security
{
    public class AuthenticationDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}