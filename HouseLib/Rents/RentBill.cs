namespace HouseLib.Rents
{
  public class RentBill : INameProperty
  {
    private static int autoIncrement = 1;
    public int Id { get; }
    public string Name { get; set; } = "Facture";

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
      return $"Facture: {Id}{Environment.NewLine}{new string('-', 20)} {Environment.NewLine}{Name}{Environment.NewLine}Du:{start} au  {end} {Environment.NewLine}Total: {total} {Environment.NewLine}";
    }
  }
}