using HouseLib;
using HouseLib.Logging;
using HouseLib.Rents;
using HouseLib.Repository;
using HouseLib.Tenants;
using Microsoft.Extensions.DependencyInjection;

System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("fr-FR");
System.Threading.Thread.CurrentThread.CurrentCulture = ci;
string header = "Rent House";

var builder = new ServiceCollection();

builder.AddSingleton<IRepository<Tenant>, TenantRespository>();
builder.AddSingleton<IRepository<Appartement>, AppartementRepository>();
builder.AddSingleton<IRepository<Rent>, RentRepository>();
builder.AddSingleton<ILoggingService, LoggingService>();

builder.AddSingleton<IRentService, RentService>();

var provider = builder.BuildServiceProvider();

Console.WriteLine("INIT APP");


//Console.WriteLine($"{header}{Environment.NewLine}{new string('_', header.Count())}");

//var apt = new Appartement(id: 1, name: "Loft", adress: "", nbRooms: 3, superficy: 100m);

//var tenant1 = new Tenant(1, "AD", DateOnly.Parse("1990 01 01"));
var currentDate = DateOnly.FromDateTime(DateTime.Now);
//var rent = new Rent(apt, tenant1, currentDate.AddMonths(-2), 1000, 120, 1000);

var rentservice = provider.GetService<IRentService>();
var rentrepository = provider.GetService<IRepository<Rent>>();
if (rentservice == null || rentrepository == null)
{
  return;
}
//rentservice.RegistreRestitutionDate(1, currentDate);
rentservice.GenerateExitBill(1, currentDate.AddMonths(-1));
rentservice.GenerateExitBill(1, currentDate);
var test = rentrepository.GetById(1);
test.GenerateFacturation(currentDate.Year, currentDate.Month);
test.GenerateFacturation(currentDate.Year, currentDate.Month);
var test1 = rentrepository.GetById(1);
rentservice.RentBoard();


Console.ReadKey();
