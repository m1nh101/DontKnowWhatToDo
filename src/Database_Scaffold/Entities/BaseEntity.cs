namespace Database_Scaffold.Entities;

public abstract class BaseEntity
{
  public short AvailFlg { get; set; }

  public short DeleteFlg { get; set; }

  public int? RegistBy { get; set; }

  public DateTime RegistDate { get; set; }

  public int? UpdateBy { get; set; }

  public DateTime UpdateDate { get; set; }

}
