
using HouseLib.Services;

namespace HouseLib.Rents {
  public interface IRentService : TenantRoleService {

    public (bool isCreacted, int Id) CreateContract(int appartementId, int tenantId, DateOnly startDate, decimal amount, decimal expense, decimal securityDeposit);
    public bool CreateFacture(int rentId, DateOnly date);
    public bool GenerateExitBill(int rentId, DateOnly exitDate);
    public void DashBoard();
    public int AddNewAppartemen(string adress, string name, int nbRoms, decimal superficy);
    public int AddNewTenant(string name, DateOnly date);
    public void GenerateFacturation(int year, int month);
    bool DeclareIntervention(int rentId, DateOnly date, string reference, string compagnyName, decimal fee, decimal tax);

  }
}
