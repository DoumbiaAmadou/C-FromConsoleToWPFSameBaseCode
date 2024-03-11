using HouseLib.Rents;
using HouseLib.Tenants;
using Microsoft.EntityFrameworkCore;

namespace HouseLib.Data
{
  public interface IRentContext : IDbContextFactory<RentContext>
  {
    public DbSet<RentBill> RentBills { get; set; }
    public DbSet<Appartement> Appartements { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<Intervention> Interventions { get; set; }

    int Save();
    Task<int> SaveSync();
  }
}

