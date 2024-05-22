namespace Core.Entities.GenericEnterpise;

public partial class GeInspectable
{
    public int InspectableId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<GeInspectionDetail> GeInspectionDetails { get; set; } = new List<GeInspectionDetail>();
}
