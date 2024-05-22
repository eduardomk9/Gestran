namespace Core.Entities.GenericEnterpise;

public partial class GeInspectableType
{
    public int? VehicleTypeId { get; set; }

    public int? InspectableId { get; set; }

    public virtual GeInspectable? Inspectable { get; set; }

    public virtual GeVehicleType? VehicleType { get; set; }
}
