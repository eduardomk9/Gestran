using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Vehicle
{
    public class VehicleTypeDTO
    {
   
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public int? Year { get; set; }

        public string? Feature1 { get; set; } = string.Empty;

        public string? Feature2 { get; set; } = string.Empty;

        public string? Feature3 { get; set; } = string.Empty;
    }  
}
