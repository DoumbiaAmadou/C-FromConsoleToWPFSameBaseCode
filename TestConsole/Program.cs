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

//var apt = new Appartement(id: 1, name: "Loft", adress: "", nbRooms: 3, superficy: 100m);

//var tenant1 = new Tenant(1, "AD", DateOnly.Parse("1990 01 01"));
var currentDate = DateOnly.FromDateTime(DateTime.Now);


var rentservice = provider.GetService<IRentService>();


if (rentservice == null)
{
  Console.WriteLine("Error RentServicenot Found");
  throw new KeyNotFoundException();
}


//var aptId = rentservice.AddNewAppartemen("ADRESS", "APT2", 2, 100m);
//var a = rentservice.CreateContract(7, 1, new DateOnly(2019, 12, 1), 800, 89, 1600);

//var a = rentservice.GenerateExitBill(10, currentDate.AddMonths(-1));
//rentservice.GenerateExitBill(3, currentDate);

//var test = rentrepository.GetById(1);

//rentservice.GenerateFacturation(2020, 1);
//test.GenerateFacturation(currentDate.Year, currentDate.Month);
//var test1 = rentrepository.GetById(1);

//rentservice.AddNewTenant("Professor", new DateOnly(1990, 12, 31));
//rentservice.AddIntervention(10, new DateOnly(2024, 3, 10), "REf1", "", 1300, 20.1m);

rentservice.DashBoard();

