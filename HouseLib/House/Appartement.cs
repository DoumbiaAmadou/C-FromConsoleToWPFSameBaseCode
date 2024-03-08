using System;
using System.Xml.Linq;
using HouseLib.Global;

namespace HouseLib
{
  public class Appartement : INameProperty, IDuplicable<Appartement>
  {
    public int Id { get; }
    public string Name { get; set; }

    public readonly string Adress;
    public readonly int NbRooms;
    public readonly decimal Superficy;


    public Appartement(int id, string name, string adress, int nbRooms, decimal superficy)
    {
      Id = id;
      Name = name;
      Adress = adress;
      NbRooms = nbRooms;
      Superficy = superficy;
    }

    public Appartement(Appartement appartement)
    {
      Id = appartement.Id;
      Name = appartement.Name;
      Adress = appartement.Adress;
      NbRooms = appartement.NbRooms;
      Superficy = appartement.Superficy;
    }


    public Appartement Clone()
    {
      return new Appartement(this);
    }
  }
}

