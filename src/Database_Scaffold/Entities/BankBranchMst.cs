namespace Database_Scaffold.Entities;

public partial class BankBranchMst : BaseEntity
{
    public string BankCd { get; set; } = null!;

    public string BankBranchCd { get; set; } = null!;

    public string BankBranchName { get; set; } = null!;

    public string BankBranchNameKana { get; set; } = null!;

    public virtual BankMst BankCdNavigation { get; set; } = null!;

    public virtual ICollection<StockholderMst> StockholderMsts { get; } = new List<StockholderMst>();
}
