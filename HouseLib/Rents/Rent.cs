
using System.Linq;
using System.Text;
using HouseLib.Global;

namespace HouseLib.Rents
{
  public class Rent : IRentOpeartaion, INameProperty
  {
    public int AppartementId { get; set; }
    public int TenantId { get; set; }
    public DateOnly EnterDate { get; set; }
    public DateOnly ExitDate { get; set; }

    public decimal SecurityDeposit { get; set; }
    public List<Amount> Amounts { get; set; } = new List<Amount>();
    public List<RentBill> RentBills { get; set; } = new List<RentBill>();
    public IList<Intervention> Interventions { get; set; } = new List<Intervention>();

    public int Id { get; set; }
    public string Name { get; set; } = "Name";



    public decimal GenerateAmount(DateOnly start, DateOnly end)
    {
      if (Amounts.Count < 1)
      {
        return 0;
      }
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
          if (lastdate.CompareTo(end.AddDays(1)) != 0)
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
      Amounts.Add(amount);
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

    public void GenerateFacturation(DateOnly date)
    {
      int year = date.Year;
      int month = date.Month;
      // idempotence
      if (RentBills.FirstOrDefault(x => x.IsFacturationDate(date)) != null)
      {
        return;
      }

      var start = new DateOnly(date.Year, date.Month, 1);
      var end = new DateOnly(year, month, DateTime.DaysInMonth(year, month));
      RentBills.Add(AddBill(start, end));

    }
    public RentBill AddBill(DateOnly start, DateOnly end)
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
    }


    public IList<RentBill> GetAllBill()
    {
      return RentBills;
    }
    public string DisplayLastBill()
    {
      return RentBills.Last().ToString();
    }

  }
}

