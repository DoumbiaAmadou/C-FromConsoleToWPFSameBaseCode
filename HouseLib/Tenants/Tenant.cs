
using System.ComponentModel.DataAnnotations.Schema;
using HouseLib.Global;

namespace HouseLib.Tenants
{
  public class Tenant : INameProperty
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public DateOnly DateOfbirth { get; set; }
  }
}

