namespace Core.Entities.GenericEnterpise;

public partial class GeVehicle
{
    public int VehicleId { get; set; }

    public string? LicensePlate { get; set; }

    public int? VehicleTypeId { get; set; }

    public string? Name { get; set; }

    public DateTime? LastInspection { get; set; }

    public int? LastInspectorUserId { get; set; }

    public bool? IsBeingInspected { get; set; }

    public virtual ICollection<GeInspection> GeInspections { get; set; } = new List<GeInspection>();

    public virtual GeVehicleType? VehicleType { get; set; }
}
