namespace HouseLib.Rents
{
  public interface IRentOpeartaion
  {
    public void GenerateFacturation(int years, int mounth);
    public void AddExtraExpense(Intervention intervention);
    public void DeclareRestitutionDate(DateOnly RestitionDate);
    public void BuildRestitution();
  }
}