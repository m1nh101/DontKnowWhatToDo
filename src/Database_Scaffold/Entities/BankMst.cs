namespace Database_Scaffold.Entities;

public partial class BankMst : BaseEntity
{
    public string BankCd { get; set; } = null!;

    public string BankName { get; set; } = null!;

    public string BankNameKana { get; set; } = null!;

    public virtual ICollection<BankBranchMst> BankBranchMsts { get; } = new List<BankBranchMst>();

    public virtual ICollection<StockholderMst> StockholderMsts { get; } = new List<StockholderMst>();
}
