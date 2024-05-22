using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Vehicle
{
    public class VehicleDTO
    {
        [Required]
        public string? LicensePlate { get; set; }
        [Required]
        public int? VehicleTypeId { get; set; }
        [Required]
        public string? Name { get; set; }

        public DateTime? LastInspection { get; set; } = DateTime.MinValue;

        public int? LastInspectorUserId { get; set; } = 0;

        public bool? IsBeingInspected { get; set; } = false;
    }
}
