using System;
using HouseLib.Tenants;

namespace HouseLib.Repository
{
  public class TenantRespository : IRepository<Tenant>
  {
    private readonly Repository<Tenant> innerTenantList = new();

    public TenantRespository()
    {
    }

    public bool Add(Tenant t)
    {
      return innerTenantList.Add(t);
    }

    public IList<Tenant> All()
    {
      return innerTenantList.All();
    }

    public bool Delete(int id)
    {
      return innerTenantList.Delete(id);
    }

    public Tenant GetById(int id)
    {
      return innerTenantList.GetById(id);
    }

    public IList<Tenant> Take(int nb)
    {
      return innerTenantList.Take(nb);
    }

    public bool Update(Tenant t)
    {
      return innerTenantList.Update(t);
    }
  }
}

