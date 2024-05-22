namespace Core.Entities.GenericEnterpise;

public partial class GeInspectionStatus
{
    public int StatusId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<GeInspection> GeInspections { get; set; } = new List<GeInspection>();
}
