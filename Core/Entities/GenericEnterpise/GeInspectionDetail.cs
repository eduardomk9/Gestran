namespace Core.Entities.GenericEnterpise;

public partial class GeInspectionDetail
{
    public int InspectionDetailId { get; set; }

    public int? InspectionId { get; set; }

    public int? InspectableId { get; set; }

    public string? Result { get; set; }

    public string? Observation { get; set; }

    public virtual GeInspectable? Inspectable { get; set; }

    public virtual GeInspection? Inspection { get; set; }
}
