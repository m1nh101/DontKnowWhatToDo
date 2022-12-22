namespace Database_Scaffold.Entities;

public partial class YearJpnMst : BaseEntity
{
    public string YearCd { get; set; } = null!;

    public string YearName { get; set; } = null!;

    public virtual ICollection<FiscalYearMst> FiscalYearMsts { get; } = new List<FiscalYearMst>();
}