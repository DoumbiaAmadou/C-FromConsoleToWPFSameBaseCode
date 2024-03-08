using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HouseLib.Rents
{
  public interface IRentService
  {
    public void CreateContract(int idApt, int idTenant, DateOnly startDate, decimal amount, decimal expense, decimal securityDeposit);
    public void DeclareIntervention();
    public void RegistreRestitutionDate(int rentId, DateOnly date);
    public void CreateFacture(int rentId, DateOnly date);
    public void GenerateExitBill(int rentId, DateOnly exitDate);

    public IList<RentBill> SearchBill(DateOnly start, DateOnly endDate);
    public IList<RentBill> LastFacture(DateOnly start, DateOnly endDate);
    public void RentBoard();
  }
}
