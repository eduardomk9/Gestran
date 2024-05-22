using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Inspection
{
    public class ApproveOrRejectDTO
    {
        [Required]
        public int IdUser { get; set; }
        [Required]
        public int IdInspection { get; set; }
        [Required]
        public int StatusInspection { get; set; }
        [Required]
        public string? Comment { get; set; }
    }
}
