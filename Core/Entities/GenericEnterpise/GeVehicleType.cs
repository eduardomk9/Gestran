namespace Core.Entities.GenericEnterpise;

public partial class GeVehicleType
{
    public int VehicleTypeId { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public string? Feature1 { get; set; }

    public string? Feature2 { get; set; }

    public string? Feature3 { get; set; }

    public virtual ICollection<GeVehicle> GeVehicles { get; set; } = new List<GeVehicle>();
}
