using System.ComponentModel.DataAnnotations;

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
