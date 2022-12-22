namespace Database_Scaffold.Entities;

public partial class StockholderTypeMst : BaseEntity
{
    public string StkTypeCd { get; set; } = null!;

    public string StkTypeName { get; set; } = null!;

    public virtual ICollection<StockholderMst> StockholderMsts { get; } = new List<StockholderMst>();
}
