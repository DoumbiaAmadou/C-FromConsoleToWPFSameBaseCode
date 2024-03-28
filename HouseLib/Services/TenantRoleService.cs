
using HouseLib.Rents;

namespace HouseLib.Services {
  public interface TenantRoleService {
    public IList<RentBill> LastFacture(int rentId, DateOnly start, DateOnly endDate);
    public IList<RentBill> SearchBill(int RentId, DateOnly start, DateOnly endDate);
    public bool RegistreRestitutionDate(int rentId, DateOnly date);
  }
}

