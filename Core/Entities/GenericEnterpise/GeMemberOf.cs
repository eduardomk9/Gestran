namespace Core.Entities.GenericEnterpise;

public partial class GeMemberOf
{
    public int IdMeof { get; set; }

    public int IdUser { get; set; }

    public int IdProf { get; set; }

    public virtual GeProfile IdProfNavigation { get; set; } = null!;

    public virtual GeUser IdUserNavigation { get; set; } = null!;
}
