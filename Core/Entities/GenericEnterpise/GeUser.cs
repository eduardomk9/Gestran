namespace Core.Entities.GenericEnterpise;

public partial class GeUser
{
    public int IdUser { get; set; }

    public int IdAuth { get; set; }

    public string FirstNameUser { get; set; } = null!;

    public string LastNameUser { get; set; } = null!;

    public string? JobTitleUser { get; set; }

    public string LoginUser { get; set; } = null!;

    public string MailUser { get; set; } = null!;

    public string? PasswordUser { get; set; }

    public string? PhoneUser { get; set; }

    public string? PhotoUser { get; set; }

    public bool IsActiveUser { get; set; }

    public bool IsDeletedUser { get; set; }

    public virtual ICollection<GeMemberOf> GeMemberOfs { get; set; } = new List<GeMemberOf>();

    public virtual GeAuthentication IdAuthNavigation { get; set; } = null!;
}
