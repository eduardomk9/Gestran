using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Vehicle
{
    public class InspectableDTO
    {
        [Required]
        public string? Name { get; set; } 
        [Required]
        public string? Description { get; set; }
    }
}
