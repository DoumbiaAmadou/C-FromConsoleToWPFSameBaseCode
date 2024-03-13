using FluentAssertions;

namespace TestHouseLib;

public class Rent_Test
{
  [Fact]
  public void GenerateAmount_ThrowInvalidOperation()
  {
    //arrange
    var rent = A.Fake<Rent>();
    //Act

    var action = () => rent.GenerateAmount(new DateOnly(2024, 01, 01), new DateOnly(2024, 03, 01));
    action.Should().Throw<InvalidOperationException>();

  }
  [Fact]
  public void GenerateAmount_Returns_1000()
  {
    //arrange
    var startDate = new DateOnly(2024, 03, 01);
    var endDate = new DateOnly(2024, 03, 31);

    var rent = A.Fake<Rent>();

    rent.Amounts = new List<Amount>{
      new Amount{
       fixedPrice=800,
        expense =200,
        startDate= new DateOnly()
      }
    };

    //Act 
    var result = rent.GenerateAmount(startDate, endDate);
    //Assertion 
    Assert.Equal(1000, result);
  }
  [Fact]
  public void GenerateAmount_Return_MultipleAmount()
  {
    //arrange
    var startDate = new DateOnly(2024, 03, 01);
    var endDate = new DateOnly(2024, 03, 31);

    var rent = A.Fake<Rent>();

    rent.Amounts = new List<Amount>{
      new Amount{
       fixedPrice=800,
        expense =200,
        startDate= new DateOnly(2024,3,1)
      },
      new Amount{
       fixedPrice=1000,
        expense =200,
       startDate= new DateOnly(2024,3,15)

      }
    };

    //Act
    // 
    var result = rent.GenerateAmount(startDate, endDate);
    //Assertion 
    Assert.Equal((float)1_070.967741935483871m, (float)result);
  }
  [Fact]
  public void UpdateAmount_Single()
  {
    //arrange
    var rent = A.Fake<Rent>();
    var amount = A.Fake<Amount>();

    //Act
    rent.UpdateAmount(amount);
    //Assert
    Assert.Single(rent.Amounts);
    Assert.Equal(amount, rent.Amounts.First());
  }
  [Fact]
  public void AddExtraExpsense_Single()
  {
    //arrange
    var rent = A.Fake<Rent>();
    var intervention = A.Fake<Intervention>();

    //Act
    rent.AddExtraExpense(intervention);
    //Assert
    Assert.Single(rent.Interventions);
    Assert.Equal(intervention, rent.Interventions.First());
  }
  [Fact]
  public void DeclareRestitutionDate_ReturnCorrectExitDate()
  {
    //arrange
    var rent = A.Fake<Rent>();
    var restitutionDate = DateOnly.FromDateTime(DateTime.Now);
    //Act
    rent.DeclareRestitutionDate(restitutionDate);
    //Assert

    Assert.Equal(restitutionDate, rent.ExitDate);
  }
  [Fact]
  public void NotBuildRestitutionDate_without_ExitDate()
  {
    //arrange
    var rent = A.Fake<Rent>();

    //Act
    var action = () => rent.BuildRestitutionBill();
    //Assert
    action.Should().Throw<Exception>();
    Assert.Empty(rent.RentBills);
  }
  [Fact]
  public void BuildRestitutionDate_Single()
  {
    //arrange
    var rent = A.Fake<Rent>();
    rent.ExitDate = DateOnly.FromDateTime(DateTime.Now);
    rent.Amounts.Add(new Amount
    {
      expense = 10,
      fixedPrice = 1000,
      startDate = new DateOnly(2024, 01, 01),
    });

    //Act
    var rentbill = rent.BuildRestitutionBill();

    //Assert
    Assert.NotNull(rentbill);
    Assert.IsAssignableFrom<RentBill>(rentbill);
  }
  [Fact]
  public void WhenGenerateFature_MultipleTime_Return_()
  {
    //arrange
    var rent = A.Fake<Rent>();
    rent.Amounts.Add(new Amount
    {
      expense = 10,
      fixedPrice = 1000,
      startDate = new DateOnly(2024, 01, 01),
    });

    //Act
    rent.GenerateFacturation(new DateOnly(2024, 01, 01));
    rent.GenerateFacturation(new DateOnly(2024, 01, 01));
    //......
    //Assert
    Assert.Single(rent.RentBills);
    Assert.Equal(1010, rent.RentBills.First().total);
  }
}
