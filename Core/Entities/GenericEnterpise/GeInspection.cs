namespace Core.Entities.GenericEnterpise;

public partial class GeInspection
{
    public int InspectionId { get; set; }

    public int? VehicleId { get; set; }

    public int? InspectorId { get; set; }

    public int? StatusId { get; set; }

    public string? Comment { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<GeInspectionDetail> GeInspectionDetails { get; set; } = new List<GeInspectionDetail>();

    public virtual GeInspectionStatus? Status { get; set; }

    public virtual GeVehicle? Vehicle { get; set; }
}
