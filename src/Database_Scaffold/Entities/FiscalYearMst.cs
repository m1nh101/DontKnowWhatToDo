namespace Database_Scaffold.Entities;

public partial class FiscalYearMst : BaseEntity
{
    public int FiscalYearCd { get; set; }

    public DateOnly FiscalYearStartDate { get; set; }

    public DateOnly FiscalYearEndDate { get; set; }

    public DateOnly? StockGmScheduleDate { get; set; }

    public DateOnly? StockPaymentScheduleDate { get; set; }

    public string? YearCd { get; set; }

    public double? StockConversionFactor { get; set; }

    public int? StockUnitPrice { get; set; }

    public int? NormalDividendPrice { get; set; }

    public int? SpecialDividendPrice { get; set; }

    public double? TaxRate { get; set; }

    public virtual ICollection<StockTransTbl> StockTransTbls { get; } = new List<StockTransTbl>();

    public virtual YearJpnMst? YearCdNavigation { get; set; }
}
