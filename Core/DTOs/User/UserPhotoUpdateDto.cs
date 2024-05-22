using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User
{
    public class UserPasswordUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; } = null!;
     
    }
}