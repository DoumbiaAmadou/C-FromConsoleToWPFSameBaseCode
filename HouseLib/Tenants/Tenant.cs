using System;
using System.Security.Cryptography;

namespace HouseLib.Tenants
{
    public class Tenant : INameProperty
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
    }
}

