namespace Database_Scaffold.Entities;

public partial class UserMst : BaseEntity
{
    public long Id { get; set; }

    public string? DivCd { get; set; }

    public string LoginId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime LastLoginDate { get; set; }

    public virtual DivisionMst? DivCdNavigation { get; set; }

    public virtual ICollection<UserRoleMap> UserRoleMaps { get; } = new List<UserRoleMap>();
}
