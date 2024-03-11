using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using HouseLib.Global;

namespace HouseLib
{
  public class Appartement : INameProperty
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Adress { get; set; } = "";
    public int NbRooms { get; set; }
    public decimal Superficy { get; set; }

  }
}

