﻿namespace HouseLib.Rents
{
  public interface IRentOpeartaion
  {
    public void GenerateFacturation(DateOnly date);
    public void AddExtraExpense(Intervention intervention);
    public void DeclareRestitutionDate(DateOnly RestitionDate);
    public RentBill BuildRestitutionBill();
    public string DisplayLastBill();
  }
}