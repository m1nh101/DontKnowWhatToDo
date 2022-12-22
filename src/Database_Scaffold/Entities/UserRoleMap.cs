namespace Database_Scaffold.Entities;

public partial class UserRoleMap : BaseEntity
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? RoleId { get; set; }

    public virtual RoleMst? Role { get; set; }

    public virtual UserMst? User { get; set; }
}
