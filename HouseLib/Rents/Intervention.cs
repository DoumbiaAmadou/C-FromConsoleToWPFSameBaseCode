namespace HouseLib.Rents
{
  public class Intervention
  {
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string Ref { get; set; } = "";
    public string CompagnyName { get; set; } = "Internal";
    public decimal Fee { get; set; }
    public decimal Tax { get; set; }
    public float TaxePourcentage { get; set; }
  }
}