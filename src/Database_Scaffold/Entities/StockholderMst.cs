using System;
using System.Collections.Generic;

namespace Database_Scaffold.Entities;

public partial class StockholderMst : BaseEntity
{
    public string StkCd { get; set; } = null!;

    public string StkName { get; set; } = null!;

    public string? StkNameKana { get; set; }

    public string? StkTypeCd { get; set; }

    public DateOnly? Birthday { get; set; }

    public DateOnly? JoinDate { get; set; }

    public string? StkZipcode1 { get; set; }

    public string? StkZipcode2 { get; set; }

    public string? StkAddress1 { get; set; }

    public string? StkAddress2 { get; set; }

    public string? BankCd { get; set; }

    public string? BankBranchCd { get; set; }

    public string? AccountNo { get; set; }

    public string? MynumberCd { get; set; }

    public string? Mynumber { get; set; }

    public virtual BankBranchMst? BankBranchCdNavigation { get; set; }

    public virtual BankMst? BankCdNavigation { get; set; }

    public virtual StockholderTypeMst? StkTypeCdNavigation { get; set; }

    public virtual ICollection<StockTransTbl> StockTransTblFromStkCdNavigations { get; } = new List<StockTransTbl>();

    public virtual ICollection<StockTransTbl> StockTransTblToStkCdNavigations { get; } = new List<StockTransTbl>();
}
