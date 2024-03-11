using System.ComponentModel.DataAnnotations;
using HouseLib;
using HouseLib.Data;
using HouseLib.Logging;
using HouseLib.Rents;
using HouseLib.Tenants;
using Microsoft.EntityFrameworkCore;

public class RentService : IRentService
{
  private ILoggingService loggerService;
  private IRentContext rentContext;

  public RentService(IRentContext rentContext, ILoggingService loggerService)
  {
    this.loggerService = loggerService;
    this.rentContext = rentContext;
  }

  public int AddNewTenant(string name, DateOnly date)
  {
    var newTenant = new Tenant
    {
      Name = name,
      DateOfbirth = date
    };
    rentContext.Tenants.Add(newTenant);
    rentContext.Save();
    loggerService.Log($"Tenant Id-{{{newTenant.Id}}} added!");
    return newTenant.Id;
  }

  public int AddNewAppartemen(string adress, string name, int nbRoms, decimal superficy)
  {
    var newAppatement = new Appartement
    {
      Adress = adress,
      Name = name,
      NbRooms = nbRoms,
      Superficy = superficy
    };
    rentContext.Appartements.Add(newAppatement);
    rentContext.Save();
    return newAppatement.Id;
  }

  public (bool, int) CreateContract(int appartementId, int tenantId
                                   , DateOnly startDate, decimal amount, decimal expense
                                    , decimal securityDeposit)
  {
    var isTenant = rentContext.Tenants.Any(x => x.Id == tenantId);
    var isApptExist = rentContext.Appartements.Any(x => x.Id == appartementId);
    if (!isTenant || !isApptExist)
    {
      loggerService.Log(" No TenantId Or AppartementId Found!", LogLevel.DEBUG);

      return (false, -1);
    }
    var rent = new Rent
    {
      AppartementId = appartementId,
      TenantId = tenantId,
      EnterDate = startDate,
      SecurityDeposit = securityDeposit,
    };
    var newAmount = new Amount
    {
      expense = expense,
      fixedPrice = amount,
      startDate = startDate,

    };

    rent.Amounts.Add(newAmount);
    rentContext.Rents.Add(rent);
    rentContext.Save();
    loggerService.Log($"contract {{{rent.Id}}} created! {Environment.NewLine} " +
     $"amount:{newAmount.fixedPrice}" +
     $"Expense:{newAmount.expense}}} ", LogLevel.INFO);
    return (true, rent.Id);
  }

  public bool DeclareIntervention()
  {
    throw new NotImplementedException();
  }
  public IList<RentBill> LastFacture(int rentId, DateOnly start, DateOnly endDate)
  {
    throw new NotImplementedException();
  }
  public IList<RentBill> SearchBill(int rentId, DateOnly start, DateOnly endDate)
  {
    throw new NotImplementedException();
  }

  public bool CreateFacture(int rentId, DateOnly date)
  {
    var rent = rentContext.Rents.First(x => x.Id == rentId);
    rent.GenerateFacturation(date);
    rentContext.Save();
    loggerService.Log($"contract {{{rent.Id}}} created! {Environment.NewLine} " +
     $"amount:{rent.Amounts.Last().fixedPrice}" +
     $"Expense:{rent.Amounts.Last().expense}}} ");
    return true;

  }

  public bool GenerateExitBill(int rentId, DateOnly exitDate)
  {
    var now = DateTime.Now;
    var rent = rentContext.Rents.Include(x => x.RentBills).Include(x => x.Amounts).First(x => x.Id == rentId);
    rent.ExitDate = exitDate;
    var startDate = new DateOnly(exitDate.Year, exitDate.Month, 1);
    var isAlreadyExist = rent.RentBills.FirstOrDefault(x => x.start.CompareTo(startDate) == 0);
    if (isAlreadyExist != null)
    {
      loggerService.Log($"Bill Already Exist", LogLevel.ERROR);
      return false;
    }

    var rentbill = rent.AddBill(new DateOnly(exitDate.Year, exitDate.Month, 1), exitDate);
    rent.RentBills.Add(rentbill);
    rentContext.Save();

    return true;
  }

  public bool RegistreRestitutionDate(int rentId, DateOnly date)
  {
    var rent = rentContext.Rents.First(x => x.Id == rentId);
    rent.ExitDate = date;
    rent.DeclareRestitutionDate(date);
    rentContext.Save();
    return true;
  }

  public void DashBoard()
  {
    Console.WriteLine($"\t <<<<<<< All Rent Facture   >>>>>>>");

    Console.WriteLine();
    foreach (var rent in rentContext.Rents.Include(x => x.RentBills).ToList())
    {
      Console.WriteLine($"----- Rent:{rent.Id} -----");
      foreach (var bill in rent.GetAllBill())
      {

        Console.WriteLine(bill);
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    Console.WriteLine($"\t <<<<<<< \t  End \t  >>>>>>>");
  }

  public void GenerateFacturation(int year, int month)
  {
    foreach (var rent in rentContext.Rents.Include(x => x.RentBills).Include(x => x.Amounts))
    {
      if (rent.ExitDate == default(DateOnly))
      {

        rent.GenerateFacturation(new DateOnly(year, month, 1));
        rentContext.Save();
      }
    }
  }

  public bool AddIntervention(int rentId, DateOnly date, string reference, string CompagnyName, decimal fee, decimal tax)
  {
    var rent = rentContext.Rents.Include(x => x.Interventions).FirstOrDefault(x => x.Id == rentId);
    if (rent == null)
    {
      loggerService.Log("RentId not Found", LogLevel.ERROR);
      return false;
    }
    rent.Interventions.Add(new Intervention
    {
      CompagnyName = CompagnyName,
      Date = date,
      Fee = fee,
      Ref = reference,
      Tax = tax,
    });
    rentContext.Save();
    return true;
  }
}