using System.Text;

namespace HouseLib.Rents
{
  public class RentBill : INameProperty
  {

    public int Id { get; set; }
    public int RentId { get; set; }

    public string Name { get; set; } = "Facture";
    public string Ref { get; set; } = "";
    public DateOnly start { get; set; }
    public DateOnly end { get; set; }
    public decimal total { get; set; }

    public bool IsFacturationDate(DateOnly date)
    {
      return (start.Year == date.Year && start.Month == date.Month);
    }

    public override string ToString()
    {
      StringBuilder s = new();
      s.Append($"\t{new string('_', 56)}{Environment.NewLine}");
      s.Append($"\t|{"ID",-15}|{Id,38} |{Environment.NewLine}");
      s.Append($"\t|{new string('-', 55)}|{Environment.NewLine}");
      s.Append($"\t|{"RentID",-15}|{RentId,38} |{Environment.NewLine}");
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