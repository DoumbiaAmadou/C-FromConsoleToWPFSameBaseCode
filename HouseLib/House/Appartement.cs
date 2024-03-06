using System;
namespace HouseLib
{
  public class Appartement : INameProperty
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

  }
}

