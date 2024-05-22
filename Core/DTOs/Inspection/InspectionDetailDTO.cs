using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Inspection
{
    public class InspectionDetailDTO
    {
        [Required]
        public int? InspectionId { get; set; }
        [Required]
        public int? InspectableId { get; set; }
        [Required]
        public string? Result { get; set; }
        [Required]
        public string? Observation { get; set; }
    }
}
