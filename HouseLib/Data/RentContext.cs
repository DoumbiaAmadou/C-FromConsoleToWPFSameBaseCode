using System;
using HouseLib.Rents;
using HouseLib.Tenants;
using Microsoft.EntityFrameworkCore;

namespace HouseLib.Data
{
  public class RentContext : DbContext, IRentContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RentDB.db")}");
      base.OnConfiguring(optionsBuilder);
    }

    public int Save()
    {
      return base.SaveChanges();
    }
    public Task<int> SaveSync()
    {
      return Task.Run(() => base.SaveChangesAsync());
    }

    public RentContext CreateDbContext()
    {
      return this;
    }

    public DbSet<Amount> Amounts { get; set; }
    public DbSet<RentBill> RentBills { get; set; }
    public DbSet<Appartement> Appartements { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<Intervention> Interventions { get; set; }

  }
}

