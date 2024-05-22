using Core.Dtos.User;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Auth
{
    public class SignInResponseDto
    {
        [Required]
        public UserDto Profile { get; set; } = null!;
        [Required]
        public TokenDto Token { get; set; } = null!;
    }
}
