using Core.Entities.GenericEnterpise;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Inspection
{
    public class InspectionDTO
    {
        [Required]
        public int? VehicleId { get; set; }
        [Required]
        public int? InspectorId { get; set; }
        [Required]
        public int? StatusId { get; set; }
        public string? Comment { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; } = null;

        //public virtual ICollection<GeInspectionDetail> GeInspectionDetails { get; set; } = new List<GeInspectionDetail>();
    }
}
