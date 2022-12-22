namespace Database_Scaffold.Entities;

public partial class DivisionMst : BaseEntity
{
    public string DeptCd { get; set; } = null!;

    public string DivCd { get; set; } = null!;

    public string JinjiDivCd { get; set; } = null!;

    public string DivName { get; set; } = null!;

    public int DivDisplayOrder { get; set; }

    public virtual DepartmentMst DeptCdNavigation { get; set; } = null!;

    public virtual ICollection<UserMst> UserMsts { get; } = new List<UserMst>();
}
