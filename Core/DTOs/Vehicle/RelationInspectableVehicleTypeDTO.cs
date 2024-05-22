using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Vehicle
{
    public class RelationInspectableVehicleTypeDTO
    {
        [Required]
        public int? VehicleTypeId { get; set; }
        [Required]
        public int? InspectableId { get; set; }
    }
}
