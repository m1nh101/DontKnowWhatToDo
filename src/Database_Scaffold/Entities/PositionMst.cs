namespace Database_Scaffold.Entities;

public partial class PositionMst : BaseEntity
{
    public string PositionCd { get; set; } = null!;

    public string PositionName { get; set; } = null!;

    public int? PosDisplayOrder { get; set; }
}
