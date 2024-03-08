using System;
using HouseLib.Global;
using HouseLib.Rents;

namespace HouseLib.Repository
{

  public class Repository<T> : IRepository<T> where T : class, IDuplicable<T>, INameProperty
  {
    //to replace by data Base!
    private IList<T> rentList = new List<T>();
    private IList<T> ProtectedInMemoryCopy() => rentList.Select(x => x.Clone()).ToList();


    public bool Delete(int id)
    {
      var rent = rentList.FirstOrDefault(r => r.Id == id);
      if (rent == null)
      {
        return false;
      }
      //Inmemory remove change this in DB context further!
      return rentList.Remove(rent);
    }

    public bool Add(T t)
    {
      rentList.Add(t);
      return true;
    }

    public IList<T> All()
    {
      return ProtectedInMemoryCopy();
    }

    public T GetById(int id)
    {
      // Throw Exception if Not Found to debug
      T t = rentList.First(x => x.Id == id);

      return t.Clone();
    }

    public IList<T> Take(int nb)
    {
      return rentList.Take(nb).Select(x => x.Clone()).ToList();
    }

    public bool Update(T t)
    {
      throw new NotImplementedException();
    }
  }



}




