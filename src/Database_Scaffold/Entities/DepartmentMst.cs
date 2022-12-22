namespace Database_Scaffold.Entities;

public partial class DepartmentMst : BaseEntity
{
    public string DeptCd { get; set; } = null!;

    public string? JinjiDeptCd { get; set; }

    public string DeptName { get; set; } = null!;

    public int? DeptDisplayOrder { get; set; }

    public virtual ICollection<DivisionMst> DivisionMsts { get; } = new List<DivisionMst>();
}
