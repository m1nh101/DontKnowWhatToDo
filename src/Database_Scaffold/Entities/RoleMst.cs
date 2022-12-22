namespace Database_Scaffold.Entities;

public partial class RoleMst : BaseEntity
{
    public long Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string? RoleNameShort { get; set; }

    public virtual ICollection<UserRoleMap> UserRoleMaps { get; } = new List<UserRoleMap>();
}
