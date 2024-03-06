using HouseLib;
using HouseLib.Rents;
using HouseLib.Tenants;

System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("fr-FR");
System.Threading.Thread.CurrentThread.CurrentCulture = ci;
string header = "Rent House";
Console.WriteLine($"{header}{Environment.NewLine}{new string('_', header.Count())}");

var apt = new Appartement(id: 1, name: "Loft", adress: "", nbRooms: 3, superficy: 100m);

var tenant1 = new Tenant(1, "AD", DateOnly.Parse("1990 01 01"));
var currentDate = DateOnly.FromDateTime(DateTime.Now);
var rent = new Rent(apt, tenant1, currentDate.AddMonths(-2), 1000, 120, 1000);

rent.GenerateFacturation(currentDate.Year, currentDate.Month);
Console.ReadKey();
