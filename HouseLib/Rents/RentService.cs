using HouseLib.Logging;
using HouseLib.Rents;
using HouseLib.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RentService : IRentService
{
  private ILoggingService loggerService;
  private IRepository<Rent> rentreposiry;

  public RentService(ILoggingService loggerService, IRepository<Rent> rentreposiry)
  {
    this.loggerService = loggerService;
    this.rentreposiry = rentreposiry;
  }


  public void CreateContract(int idApt, int idTenant, DateOnly startDate, decimal amount, decimal expense, decimal securityDeposit)
  {
    throw new NotImplementedException();
  }

  public void CreateFacture(int rentId, DateOnly date)
  {
    throw new NotImplementedException();
  }

  public void DeclareIntervention()
  {
    throw new NotImplementedException();
  }

  public void GenerateExitBill(int rentId, DateOnly exitDate)
  {
    var now = DateTime.Now;
    var rent = rentreposiry.GetById(rentId);
    rent.GenerateFacturation(now.Year, now.Month - 1);
  }

  public IList<RentBill> LastFacture(DateOnly start, DateOnly endDate)
  {
    throw new NotImplementedException();
  }

  public void RegistreRestitutionDate(int rentId, DateOnly date)
  {
    var rent = rentreposiry.GetById(rentId);
    rent.DeclareRestitutionDate(date);

  }

  public IList<RentBill> SearchBill(DateOnly start, DateOnly endDate)
  {
    throw new NotImplementedException();
  }

  public void RentBoard()
  {
    Console.WriteLine($"======= All Rent Facture   =======");

    Console.WriteLine();
    foreach (var rent in rentreposiry.All())
    {
      Console.WriteLine($"Rent:{rent.Id}-----");
      foreach (var bill in rent.GetAllBill())
      {

        Console.WriteLine(bill);
        Console.WriteLine();
        Console.WriteLine();
      }
      Console.WriteLine();

      Console.WriteLine();
    }

    Console.WriteLine($"\t ======= End  =======");
  }
}