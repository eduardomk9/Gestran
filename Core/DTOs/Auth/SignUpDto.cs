using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Auth
{
    public class SignUpDto
    {
        [Required]
        public int IdAuth { get; set; }
        [Required]
        public int IdProf { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string? JobTitle { get; set; }
        [Required]
        public string Login { get; set; } = null!;  
        [Required]
        public string Mail { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        public string? Password { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}