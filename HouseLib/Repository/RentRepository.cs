using System;
using HouseLib.Rents;
using HouseLib.Tenants;

namespace HouseLib.Repository
{
  public class RentRepository : IRepository<Rent>
  {
    private Repository<Rent> innerRent = new Repository<Rent>();
    private IRepository<Appartement> appartementRepository;
    public RentRepository(IRepository<Appartement> appartementRepository)
    {
      Console.WriteLine("Rent Service build");
      this.appartementRepository = appartementRepository;
      var currentDate = DateOnly.FromDateTime(DateTime.Now);
      innerRent.Add(new Rent(1, 1, currentDate.AddMonths(-2), 1000, 120, 1000));
    }
    public bool Add(Rent t)
    {
      return innerRent.Add(t);
    }

    public IList<Rent> All()
    {
      return innerRent.All();
    }

    public bool Delete(int id)
    {
      return innerRent.Delete(id);
    }

    public Rent GetById(int id)
    {
      return innerRent.GetById(id);
    }

    public IList<Rent> Take(int nb)
    {
      return innerRent.Take(nb);
    }

    public bool Update(Rent t)
    {
      return innerRent.Update(t);
    }
  }
}
