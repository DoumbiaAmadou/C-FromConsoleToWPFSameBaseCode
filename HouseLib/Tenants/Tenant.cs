
using HouseLib.Global;

namespace HouseLib.Tenants
{
  public class Tenant : INameProperty, IDuplicable<Tenant>
  {
    public int Id { get; }

    public string Name { get; set; }

    public readonly DateOnly DateOfbirth;
    public Tenant(int id, string name, DateOnly dateOfbirth)
    {
      Id = id;
      Name = name;
      DateOfbirth = dateOfbirth;
    }

    public Tenant Clone()
    {
      return new Tenant(Id, Name, DateOfbirth);
    }
  }
}

