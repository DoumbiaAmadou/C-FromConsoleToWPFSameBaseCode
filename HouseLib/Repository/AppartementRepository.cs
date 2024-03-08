using System;
using HouseLib.Rents;

namespace HouseLib.Repository
{
  public class AppartementRepository : IRepository<Appartement>
  {
    private Repository<Appartement> innerRent = new Repository<Appartement>();
    public AppartementRepository()
    {
      innerRent.Add(new Appartement(id: 1, name: "Loft", adress: "", nbRooms: 3, superficy: 100m));
    }

    public bool Add(Appartement t)
    {
      return innerRent.Add(t);
    }

    public IList<Appartement> All()
    {
      return innerRent.All();
    }

    public bool Delete(int id)
    {
      return innerRent.Delete(id);
    }

    public Appartement GetById(int id)
    {
      return innerRent.GetById(id);
    }

    public IList<Appartement> Take(int nb)
    {
      return innerRent.Take(nb);
    }

    public bool Update(Appartement t)
    {
      return innerRent.Update(t);
    }
  }
}

