namespace HouseLib.Rents
{
  public class Amount
  {
    public int Id { get; set; }
    public DateOnly startDate { get; set; }
    public decimal fixedPrice { get; set; }
    public decimal expense { get; set; }

    public bool isFacturate(DateOnly date)
    {
      return date.Month == startDate.Month && date.Year == startDate.Year;
    }
    public decimal GlobalFee()
    {
      return fixedPrice + expense;
    }
  }
}