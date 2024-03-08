
using System.Text;
using HouseLib.Global;

namespace HouseLib.Rents
{
  public class Rent : IRentOpeartaion, INameProperty, IDuplicable<Rent>
  {
    private readonly int appartementId;
    private readonly int tenantId;
    private readonly DateOnly EnterDate;
    private DateOnly ExitDate;

    private readonly decimal SecurityDeposit;
    public readonly Stack<Amount> Amounts = new Stack<Amount>();
    private readonly Dictionary<string, RentBill> RentBill = new Dictionary<string, RentBill>();
    private readonly IList<Intervention> Interventions = new List<Intervention>();
    public static int autoIncrement = 1;
    public int Id { get; }

    public string Name { get; set; } = "Name";

    public Rent(int appartementId, int tenantId, DateOnly startDate, decimal amount, decimal expense, decimal securityDeposit)
    {
      Id = autoIncrement++;
      this.appartementId = appartementId;
      this.tenantId = tenantId;
      EnterDate = startDate;
      Amounts.Push(new Amount(startDate, amount, expense));
      SecurityDeposit = securityDeposit;
    }

    public Rent(Rent x)
    {
      Id = x.Id;
      appartementId = x.appartementId;
      tenantId = x.tenantId;
      EnterDate = x.EnterDate;

      foreach (var a in x.Amounts)
      {
        Amounts.Push(new Amount(a.startDate, a.fixedPrice,
         a.expense));
      }

      //not Clone for check
      ExitDate = x.ExitDate;
      RentBill = x.RentBill;
      Interventions = x.Interventions;

    }

    public decimal GenerateAmount(DateOnly start, DateOnly end)
    {

      var stackCopy = new Stack<Amount>(Amounts);
      decimal total = 0;
      Amount amount;
      var lastdate = end.AddDays(1);
      do
      {
        amount = stackCopy.Pop();

        if (amount.startDate > start)
        {
          total += (amount.GlobalFee() * (lastdate.Day - amount.startDate.Day) / (end.Day));
          lastdate = amount.startDate;
        }
        else
        {
          if (lastdate != end.AddDays(1))
          {
            total += (amount.GlobalFee() * (lastdate.Day - start.Day) / (end.Day));
          }
          else
          {
            total += amount.GlobalFee();
          }

        }

      } while (amount.startDate > start);
      return total;
    }
    public void UpdateAmount(Amount amount)
    {
      Amounts.Push(amount);
    }
    public void AddExtraExpense(Intervention intervention)
    {
      Interventions.Add(intervention);
    }

    public void DeclareRestitutionDate(DateOnly RestitionDate)
    {
      ExitDate = RestitionDate;
    }

    public void BuildRestitution()
    {
      if (ExitDate != DateOnly.MinValue)
      {
        AddBill(ExitDate.AddDays(-ExitDate.Day + 1), ExitDate.AddDays(-ExitDate.Day).AddMonths(1));
      }
    }

    public void GenerateFacturation(int year, int month)
    {
      // idempotence
      if (RentBill.ContainsKey($"{year}-{month}"))
        return;

      var start = new DateOnly(year, month, 1);
      var end = new DateOnly(year, month, DateTime.DaysInMonth(year, month));
      RentBill.TryAdd($"{year}-{month}", AddBill(start, end));

    }
    private RentBill AddBill(DateOnly start, DateOnly end)
    {
      return new RentBill
      {
        RentId = Id,
        end = end,
        start = start,
        Ref = $"FACT_{end.Year}-{end.Month}__{Guid.NewGuid().ToString().Substring(0, 10)}",
        Name = $"Faturation du {end.ToLongDateString()}",
        total = GenerateAmount(start, end),
      };


      //Console.WriteLine(bill);
    }

    public Rent Clone()
    {
      return new Rent(this);
    }
    public IList<RentBill> GetAllBill()
    {
      return RentBill.Values.ToList();
    }
    public string DisplayLastBill()
    {
      StringBuilder s = new();
      return RentBill.Last().Value.ToString();
    }

  }
}

