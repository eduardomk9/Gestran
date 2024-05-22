namespace Core.Entities.GenericEnterpise;

public partial class GeAuthentication
{
    public int IdAuth { get; set; }

    public string NameAuth { get; set; } = null!;

    public string DisplayNameAuth { get; set; } = null!;

    public bool IsActiveAuth { get; set; }

    public bool IsDeletedAuth { get; set; }

    public virtual ICollection<GeUser> GeUsers { get; set; } = new List<GeUser>();
}
