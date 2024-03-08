using System.Text;

namespace HouseLib.Rents
{
  public class RentBill : INameProperty
  {
    private static int autoIncrement = 1;
    public int Id { get; }
    public string Name { get; set; } = "Facture";
    public string Ref { get; set; } = "";
    public DateOnly start;
    public DateOnly end;
    public decimal total;

    public int RentId;

    public RentBill()
    {
      Id = autoIncrement++;
    }
    public override string ToString()
    {
      StringBuilder s = new();
      s.Append($"\t{new string('_', 56)}{Environment.NewLine}");
      s.Append($"\t|{"RentID",-15}|{Id,38} |{Environment.NewLine}");
      s.Append($"\t|{new string('-', 55)}|{Environment.NewLine}");
      s.Append($"\t|{"Ref",-15}|{Ref,39}|{Environment.NewLine}");
      s.Append($"\t|{new string('-', 55)}|{Environment.NewLine}");
      s.Append($"\t|{"Name",-15}|{Name,39}|{Environment.NewLine}");
      s.Append($"\t|{new string('-', 55)}|{Environment.NewLine}");
      s.Append($"\t|{"Start Date",-15}|{start,39}|{Environment.NewLine}");
      s.Append($"\t|{new string('-', 55)}|{Environment.NewLine}");
      s.Append($"\t|{"End Date",-15}|{end,39}|{Environment.NewLine}");
      s.Append($"\t|{new string('-', 55)}|{Environment.NewLine}");
      s.Append($"\t|{"Total",-15}|{total,39}|{Environment.NewLine}");
      s.Append($"\t{new string('-', 56)}{Environment.NewLine}");
      return s.ToString();
    }
  }
}