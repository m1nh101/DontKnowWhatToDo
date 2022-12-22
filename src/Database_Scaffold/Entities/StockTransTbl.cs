namespace Database_Scaffold.Entities;

public partial class StockTransTbl : BaseEntity
{
    public long Id { get; set; }

    public string? ToStkCd { get; set; }

    public DateOnly StkTransDate { get; set; }

    public int StkNumber { get; set; }

    public int StkUnitPrice { get; set; }

    public string? FromStkCd { get; set; }

    public int FiscalYearCd { get; set; }

    public virtual FiscalYearMst FiscalYearCdNavigation { get; set; } = null!;

    public virtual StockholderMst? FromStkCdNavigation { get; set; }

    public virtual StockholderMst? ToStkCdNavigation { get; set; }
}
