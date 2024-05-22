namespace Core.Entities.GenericEnterpise;

public partial class GeProfile
{
    public int IdProf { get; set; }

    public string NameProf { get; set; } = null!;

    public string DisplayNameProf { get; set; } = null!;

    public bool IsActiveProf { get; set; }

    public bool IsDeletedProf { get; set; }

    public virtual ICollection<GeMemberOf> GeMemberOfs { get; set; } = new List<GeMemberOf>();
}
