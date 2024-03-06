using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using HouseLib.Tenants;

namespace HouseLib.Rents
{
  public class Rent : IRentOpeartaion
  {
    private Appartement Appartement;
    private Tenant Tenant;
    private readonly DateOnly EnterDate;
    private DateOnly ExitDate;
    private readonly decimal SecurityDeposit;
    private readonly Stack<Amount> Amounts = new Stack<Amount>();
    private readonly IList<RentBill> RentBill = new List<RentBill>();
    private readonly IList<Intervention> Interventions = new List<Intervention>();

    public Rent(Appartement apt, Tenant tenant, DateOnly startDate, decimal amount, decimal expense, decimal securityDeposit)
    {
      Tenant = tenant;
      Appartement = apt;
      EnterDate = startDate;
      Amounts.Push(new Amount(startDate, amount, expense));
      SecurityDeposit = securityDeposit;
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
      var start = new DateOnly(year, month, 1);
      var end = new DateOnly(year, month, DateTime.DaysInMonth(year, month));
      AddBill(start, end);

    }
    private void AddBill(DateOnly start, DateOnly end)
    {
      var bill = new RentBill
      {
        end = end,
        start = start,
        Name = $"Faturation du {end.ToLongDateString()}",
        total = GenerateAmount(start, end),
      };
      RentBill.Add(bill);
      Console.WriteLine($"=> AddBill (){Environment.NewLine}");
      Console.WriteLine(bill);
    }
  }
}

