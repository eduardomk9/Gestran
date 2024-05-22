using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User
{
    public class UserPhotoUpdateDto
    {
        [Required]
        public int Id { get; set; }     
        public string? Photo { get; set; }
     
    }
}