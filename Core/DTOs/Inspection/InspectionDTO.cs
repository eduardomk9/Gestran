using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Inspection
{
    public class InspectionDTO
    {
        public int? VehicleId { get; set; }
        public int? InspectorId { get; set; }
        public int? StatusId { get; set; }
        public string? Comment { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; } = null;

    }
}
