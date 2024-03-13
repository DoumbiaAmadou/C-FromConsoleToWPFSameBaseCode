using HouseLib.Data;
using HouseLib.Logging;
using HouseLib.Rents;

using Microsoft.Extensions.DependencyInjection;

System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("fr-FR");
Thread.CurrentThread.CurrentCulture = ci;
string header = "Rent House";

var builder = new ServiceCollection();

//builder.AddTransient<IDbContextFactory<RentContext>, RentContext>();
builder.AddTransient<IRentContext, RentContext>();
builder.AddSingleton<ILoggingService, LoggingService>();

builder.AddSingleton<IRentService, RentService>();

var provider = builder.BuildServiceProvider();


Console.WriteLine($"{new string('=', header.Count())}{Environment.NewLine}{header}{Environment.NewLine}{new string('=', header.Count())}");

var currentDate = DateOnly.FromDateTime(DateTime.Now);


//var rentservice = provider.GetService<IRentService>();


//if (rentservice == null)
//{
//  Console.WriteLine("Error RentServicenot Found");
//  throw new KeyNotFoundException();
//}


//var aptId = rentservice.AddNewAppartemen("ADRESS", "APT2", 2, 100m);
//var tenantId = rentservice.AddNewTenant("Professor", new DateOnly(1990, 12, 31));
//var (isCreated, rentId) = rentservice.CreateContract(7, 1, new DateOnly(2019, 12, 1), 800, 89, 1600);
//var IsGenerated = rentservice.GenerateExitBill(rentId, currentDate.AddMonths(-1));
//var IsInterventionCreated = rentservice.DeclareIntervention(rentId, new DateOnly(2024, 3, 10), "Ref1", "", 1300, 20.1m);
//IsGenerated = rentservice.GenerateExitBill(rentId, currentDate);
//rentservice.SearchBill(rentId, new DateOnly(2023, 3, 10), new DateOnly(2024, 3, 10));
//Console.ReadKey();
//rentservice.DashBoard();


DateOnly startDate = new DateOnly(2023, 2, 28);
DateOnly endDate = new DateOnly(2024, 3, 13);

// Convert DateOnly to DateTime
DateTime startDateTime = startDate.ToDateTime(new TimeOnly(0, 0, 0));
DateTime endDateTime = endDate.ToDateTime(new TimeOnly(0, 0, 0));

int numberOfDays = (endDateTime - startDateTime).Days;

Console.WriteLine("Number of days between the start date and end date: " + numberOfDays);
